using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using InTheHand.Net.Bluetooth;
using InTheHand.Net.Sockets;

/// <summary>
/// Bluetooth デバイス探索、ペアリングを行うアプリのデモ。
/// </summary>
namespace BluetoothDemo
{
    public partial class Form_main : Form
    {
        BluetoothClient bc;
        BluetoothClient bcAsync;
        public Form_main()
        {
            InitializeComponent();
            // BluetoothClient オブジェクトの生成
            bc = new BluetoothClient();
            // 未ペアリングデバイスを探索する際の所要時間を設定。デフォルトは10秒。
            bc.InquiryLength = new TimeSpan(0, 0, 5); // この場合は5秒
            // 非同期BluetoothClient オブジェクトの生成
            bcAsync = new BluetoothClient();
            // 未ペアリングデバイスを探索する際の所要時間を設定。デフォルトは10秒。
            bcAsync.InquiryLength = new TimeSpan(0, 0, 2); // この場合は5秒
            // ペアリングリクエストが発生した場合、引数のメソッドをコールバックする。
            BluetoothWin32Authentication authenticator = new BluetoothWin32Authentication(Win32AuthCallbackHandler);

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// ペアリングとサービスのインストールを実施。
        /// </summary>
        /// <param name="deviceInfo">対象のデバイス</param>
        /// <returns></returns>
        private bool Pairing(BluetoothDeviceInfo deviceInfo)
        {
            // ペアリングリクエスト。完了するまで待ち合わせる。
            bool paired = BluetoothSecurity.PairRequest(deviceInfo.DeviceAddress, null);

            // ペアリング失敗したらそこで終了
            if (!paired)
            {
                return false;
            }

            deviceInfo = new BluetoothDeviceInfo(deviceInfo.DeviceAddress);

            // ペアリングしたデバイスが対応しているサービス一覧を取得し、リストに記憶する。
            List<Guid> serviceGuidList = new List<Guid>();

            // L2CapProtocolにてGetServiceRecordsを実行するとデバイスが利用可能なサービス一覧を取得できる。
            ServiceRecord[] serviceinfo = deviceInfo.GetServiceRecords(BluetoothService.L2CapProtocol);
            foreach (var record in serviceinfo)
            {
                // サービスレコードをテキストでダンプ
                //ServiceRecordUtilities.Dump(Console.Error, record);
                // 取得したサービスレコードのうち、ServiceDescription のレコードを取得する。
                ServiceAttribute sdpRecord = record.GetAttributeById(InTheHand.Net.Bluetooth.AttributeIds.UniversalAttributeId.ServiceDescription);
                if (sdpRecord != null)
                {
                    // サービスのGuidを取得
                    serviceGuidList.Add(sdpRecord.Value.GetValueAsElementArray()[0].GetValueAsUuid());
                }
            }
            // サービスのインストール
            foreach (Guid service in serviceGuidList)
            {
                try
                {
                    // 個々のServiceに対し、有効を設定する。
                    deviceInfo.SetServiceState(service, true, true);
                }
                catch (Exception ex)
                {
                    Console.Error.WriteLine(ex.Message);
                    Console.Error.WriteLine(ex.StackTrace);
                }
            }

            return true;
        }

        /// <summary>
        /// ペアリングボタンクリック
        /// listBoxNonPairで選択されているデバイスとペアリングを実施。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_pairing_Click(object sender, EventArgs e)
        {
            BluetoothDeviceInfo deviceInfo = (BluetoothDeviceInfo)listBoxNonPair.SelectedItem;
            if(deviceInfo != null)
            {
                Pairing(deviceInfo);
            }
        }

        private void Btlist_refresh()
        {
            // Bluetoothデバイスの探索を行う。
            // 引数：
            // int maxDevices    : 探索するデバイスの最大数。指定の数で探索を打ち切る。
            // bool authenticated: trueだと認証済み（ペアリング済み）のデバイス、falseだと認証していないデバイスを結果に含める。
            // bool remembered   : trueだとホストに記録済みのデバイスのみを結果に含める（認証したことのあるデバイス以外無視すると同じ？）
            // bool unknown      : falseだと詳細のわからないデバイスを結果に含めない。

            // 未ペアリングのデバイスを探索し、結果を返す
            BluetoothDeviceInfo[] devices_nonpaired = bc.DiscoverDevices(32, false, false, true);
            // ペアリング済みのデバイスを探索し、結果を返す
            BluetoothDeviceInfo[] devices_paired = bc.DiscoverDevices(32, true, false, false);

            bindingSource_nonPair.DataSource = devices_nonpaired;
            bindingSource_Paired.DataSource = devices_paired;
            // ListBoxの設定
            listBoxNonPair.DisplayMember = "DeviceName";
            listBoxPaired.DisplayMember = "DeviceName";
        }

        /// <summary>
        /// 非同期で未ペアリングデバイスを探索する
        /// </summary>
        private void Btlist_refrashAsync()
        {
            // 探索を開始。探索時間経過後コールバックメソッドが実行される。
            bcAsync.BeginDiscoverDevices(32, false, true, true, true, RefrashAsyncCallbackHandler,"non-paired");
            bcAsync.BeginDiscoverDevices(32, true, true, false, false, RefrashAsyncCallbackHandler, "paired");
        }

        /// <summary>
        /// 非同期デバイス探索後コールバック
        /// </summary>
        /// <param name="ar"></param>
        private void RefrashAsyncCallbackHandler(IAsyncResult ar)
        {
            if (ar.IsCompleted)
            {
                BluetoothDeviceInfo[] devices = bcAsync.EndDiscoverDevices(ar);
                if((string)ar.AsyncState == "non-paired") { 
                    Invoke((MethodInvoker)(()=>{
                        bindingSource_nonPair.DataSource = devices;
                        listBoxNonPair.DisplayMember = "DeviceName";
                    }));
                    // non-pair側のみ継続条件をつける。こちらのほうが遅いので。
                    if (Toggle_RefrashAsync.Checked)
                    {
                        bcAsync.BeginDiscoverDevices(32, false, false, true, true, RefrashAsyncCallbackHandler, "non-paired");
                    }
                }
                else if ((string)ar.AsyncState == "paired")
                {
                    Invoke((MethodInvoker)(() => {
                        bindingSource_Paired.DataSource = devices;
                        listBoxPaired.DisplayMember = "DeviceName";
                    }));
                }
            }
        }

        /// <summary>
        /// 対象のデバイス情報をプロパティグリッドに表示させる
        /// </summary>
        /// <param name="deviceInfo"></param>
        private void SetDeviceInfoToPropertyGrid(BluetoothDeviceInfo deviceInfo)
        {
            propertyGrid1.SelectedObject = deviceInfo;
        }

        /// <summary>
        /// ペアリングリクエストが発生した際に呼び出される。
        /// </summary>
        private void Win32AuthCallbackHandler(Object sender, BluetoothWin32AuthenticationEventArgs e)
        {
            // pinの設定。デバイスによっては必須。
            e.Pin = "0000";
            // ペアリングの了承・拒否を設定できる。trueにしてメソッドを返すとペアリング了承にできる。
            e.Confirm = true;
        }
        /// <summary>
        /// refrashボタンクリック
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_refresh_Click(object sender, EventArgs e)
        {
            Btlist_refresh();
        }

        /// <summary>
        /// クリックしたアイテムをプロパティグリッドに表示する
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listBox_Click(object sender, EventArgs e)
        {
            SetDeviceInfoToPropertyGrid((BluetoothDeviceInfo)((ListBox)sender).SelectedItem);
        }

        /// <summary>
        /// RefreshAsync
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Toggle_RefrashAsync_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox obj = (CheckBox)sender;
            if (obj.Checked)
            {
                Btlist_refrashAsync();
            }
        }

        /// <summary>
        /// 引数デバイスのペアリング解除
        /// </summary>
        /// <param name="deviceInfo"></param>
        /// <returns></returns>
        private bool RemovePairing(BluetoothDeviceInfo deviceInfo)
        {
            return BluetoothSecurity.RemoveDevice(deviceInfo.DeviceAddress);
        }

        /// <summary>
        /// removeボタンクリック
        /// listBoxPairedで選択されているデバイスとペアリングを解除する
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_remove_Click(object sender, EventArgs e)
        {
            BluetoothDeviceInfo deviceInfo = (BluetoothDeviceInfo)listBoxPaired.SelectedItem;
            if(deviceInfo != null)
            {
                RemovePairing(deviceInfo);
            }
        }
    }
}
