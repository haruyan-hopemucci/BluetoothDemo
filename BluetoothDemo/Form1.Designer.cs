namespace BluetoothDemo
{
    partial class Form_main
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.listBoxNonPair = new System.Windows.Forms.ListBox();
            this.bindingSource_nonPair = new System.Windows.Forms.BindingSource(this.components);
            this.listBoxPaired = new System.Windows.Forms.ListBox();
            this.bindingSource_Paired = new System.Windows.Forms.BindingSource(this.components);
            this.button_refresh = new System.Windows.Forms.Button();
            this.button_pairing = new System.Windows.Forms.Button();
            this.propertyGrid1 = new System.Windows.Forms.PropertyGrid();
            this.button_remove = new System.Windows.Forms.Button();
            this.Toggle_RefrashAsync = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource_nonPair)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource_Paired)).BeginInit();
            this.SuspendLayout();
            // 
            // listBoxNonPair
            // 
            this.listBoxNonPair.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.listBoxNonPair.DataSource = this.bindingSource_nonPair;
            this.listBoxNonPair.FormattingEnabled = true;
            this.listBoxNonPair.ItemHeight = 20;
            this.listBoxNonPair.Location = new System.Drawing.Point(22, 42);
            this.listBoxNonPair.Margin = new System.Windows.Forms.Padding(5);
            this.listBoxNonPair.Name = "listBoxNonPair";
            this.listBoxNonPair.Size = new System.Drawing.Size(197, 284);
            this.listBoxNonPair.TabIndex = 0;
            this.listBoxNonPair.Click += new System.EventHandler(this.listBox_Click);
            // 
            // listBoxPaired
            // 
            this.listBoxPaired.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.listBoxPaired.DataSource = this.bindingSource_Paired;
            this.listBoxPaired.FormattingEnabled = true;
            this.listBoxPaired.ItemHeight = 20;
            this.listBoxPaired.Location = new System.Drawing.Point(229, 42);
            this.listBoxPaired.Margin = new System.Windows.Forms.Padding(5);
            this.listBoxPaired.Name = "listBoxPaired";
            this.listBoxPaired.Size = new System.Drawing.Size(197, 324);
            this.listBoxPaired.TabIndex = 1;
            this.listBoxPaired.Click += new System.EventHandler(this.listBox_Click);
            // 
            // button_refresh
            // 
            this.button_refresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button_refresh.Location = new System.Drawing.Point(22, 379);
            this.button_refresh.Margin = new System.Windows.Forms.Padding(5);
            this.button_refresh.Name = "button_refresh";
            this.button_refresh.Size = new System.Drawing.Size(125, 38);
            this.button_refresh.TabIndex = 2;
            this.button_refresh.Text = "Refresh";
            this.button_refresh.UseVisualStyleBackColor = true;
            this.button_refresh.Click += new System.EventHandler(this.button_refresh_Click);
            // 
            // button_pairing
            // 
            this.button_pairing.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button_pairing.Location = new System.Drawing.Point(157, 379);
            this.button_pairing.Margin = new System.Windows.Forms.Padding(5);
            this.button_pairing.Name = "button_pairing";
            this.button_pairing.Size = new System.Drawing.Size(125, 38);
            this.button_pairing.TabIndex = 3;
            this.button_pairing.Text = "Pairing";
            this.button_pairing.UseVisualStyleBackColor = true;
            this.button_pairing.Click += new System.EventHandler(this.button_pairing_Click);
            // 
            // propertyGrid1
            // 
            this.propertyGrid1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.propertyGrid1.Location = new System.Drawing.Point(443, 42);
            this.propertyGrid1.Name = "propertyGrid1";
            this.propertyGrid1.Size = new System.Drawing.Size(288, 377);
            this.propertyGrid1.TabIndex = 4;
            // 
            // button_remove
            // 
            this.button_remove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button_remove.Location = new System.Drawing.Point(292, 379);
            this.button_remove.Margin = new System.Windows.Forms.Padding(5);
            this.button_remove.Name = "button_remove";
            this.button_remove.Size = new System.Drawing.Size(125, 38);
            this.button_remove.TabIndex = 3;
            this.button_remove.Text = "Remove";
            this.button_remove.UseVisualStyleBackColor = true;
            this.button_remove.Click += new System.EventHandler(this.button_remove_Click);
            // 
            // Toggle_RefrashAsync
            // 
            this.Toggle_RefrashAsync.Appearance = System.Windows.Forms.Appearance.Button;
            this.Toggle_RefrashAsync.Location = new System.Drawing.Point(22, 335);
            this.Toggle_RefrashAsync.Name = "Toggle_RefrashAsync";
            this.Toggle_RefrashAsync.Size = new System.Drawing.Size(125, 36);
            this.Toggle_RefrashAsync.TabIndex = 5;
            this.Toggle_RefrashAsync.Text = "RefrashAsync";
            this.Toggle_RefrashAsync.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Toggle_RefrashAsync.UseVisualStyleBackColor = true;
            this.Toggle_RefrashAsync.CheckedChanged += new System.EventHandler(this.Toggle_RefrashAsync_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 20);
            this.label1.TabIndex = 6;
            this.label1.Text = "NonPaired";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(229, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 20);
            this.label2.TabIndex = 7;
            this.label2.Text = "Paired";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(439, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 20);
            this.label3.TabIndex = 8;
            this.label3.Text = "Properties";
            // 
            // Form_main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(743, 431);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Toggle_RefrashAsync);
            this.Controls.Add(this.propertyGrid1);
            this.Controls.Add(this.button_remove);
            this.Controls.Add(this.button_pairing);
            this.Controls.Add(this.button_refresh);
            this.Controls.Add(this.listBoxPaired);
            this.Controls.Add(this.listBoxNonPair);
            this.Font = new System.Drawing.Font("Meiryo UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "Form_main";
            this.Text = "Form_main";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource_nonPair)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource_Paired)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxNonPair;
        private System.Windows.Forms.ListBox listBoxPaired;
        private System.Windows.Forms.Button button_refresh;
        private System.Windows.Forms.Button button_pairing;
        private System.Windows.Forms.PropertyGrid propertyGrid1;
        private System.Windows.Forms.Button button_remove;
        private System.Windows.Forms.BindingSource bindingSource_nonPair;
        private System.Windows.Forms.BindingSource bindingSource_Paired;
        private System.Windows.Forms.CheckBox Toggle_RefrashAsync;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}

