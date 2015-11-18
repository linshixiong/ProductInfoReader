namespace ProductInfoReader
{
    partial class FormMain
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonConnect = new System.Windows.Forms.Button();
            this.textBoxDbPassword = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBoxDbUser = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.textBoxDbName = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxDbHost = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label = new System.Windows.Forms.Label();
            this.textBoxProductKey = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.buttonClose = new System.Windows.Forms.Button();
            this.buttonSN = new System.Windows.Forms.Button();
            this.textBoxSN = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.buttonCommit = new System.Windows.Forms.Button();
            this.buttonImei = new System.Windows.Forms.Button();
            this.textBoxImei = new System.Windows.Forms.TextBox();
            this.labelIMEI = new System.Windows.Forms.Label();
            this.buttonBluetoothMacAddress = new System.Windows.Forms.Button();
            this.textBoxBluetoothMacAddress = new System.Windows.Forms.TextBox();
            this.labelBluetooth = new System.Windows.Forms.Label();
            this.buttonWifiMacAddress = new System.Windows.Forms.Button();
            this.textBoxWifiMacAddress = new System.Windows.Forms.TextBox();
            this.labelWifi = new System.Windows.Forms.Label();
            this.buttonGetProductKey = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.buttonConnect);
            this.groupBox1.Controls.Add(this.textBoxDbPassword);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.textBoxDbUser);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.textBoxDbName);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.textBoxDbHost);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(622, 81);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "数据库信息";
            // 
            // buttonConnect
            // 
            this.buttonConnect.Location = new System.Drawing.Point(542, 20);
            this.buttonConnect.Name = "buttonConnect";
            this.buttonConnect.Size = new System.Drawing.Size(62, 51);
            this.buttonConnect.TabIndex = 5;
            this.buttonConnect.Text = "测试连接";
            this.buttonConnect.UseVisualStyleBackColor = true;
            this.buttonConnect.Click += new System.EventHandler(this.buttonConnect_Click);
            // 
            // textBoxDbPassword
            // 
            this.textBoxDbPassword.Location = new System.Drawing.Point(346, 48);
            this.textBoxDbPassword.Name = "textBoxDbPassword";
            this.textBoxDbPassword.PasswordChar = '*';
            this.textBoxDbPassword.ReadOnly = true;
            this.textBoxDbPassword.Size = new System.Drawing.Size(190, 21);
            this.textBoxDbPassword.TabIndex = 4;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(309, 51);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(29, 12);
            this.label7.TabIndex = 6;
            this.label7.Text = "密码";
            // 
            // textBoxDbUser
            // 
            this.textBoxDbUser.Location = new System.Drawing.Point(77, 47);
            this.textBoxDbUser.Name = "textBoxDbUser";
            this.textBoxDbUser.ReadOnly = true;
            this.textBoxDbUser.Size = new System.Drawing.Size(190, 21);
            this.textBoxDbUser.TabIndex = 3;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(30, 51);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 12);
            this.label8.TabIndex = 4;
            this.label8.Text = "用户名";
            // 
            // textBoxDbName
            // 
            this.textBoxDbName.Location = new System.Drawing.Point(346, 21);
            this.textBoxDbName.Name = "textBoxDbName";
            this.textBoxDbName.ReadOnly = true;
            this.textBoxDbName.Size = new System.Drawing.Size(190, 21);
            this.textBoxDbName.TabIndex = 2;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(273, 24);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 12);
            this.label6.TabIndex = 2;
            this.label6.Text = "数据库名称";
            // 
            // textBoxDbHost
            // 
            this.textBoxDbHost.Location = new System.Drawing.Point(77, 20);
            this.textBoxDbHost.Name = "textBoxDbHost";
            this.textBoxDbHost.ReadOnly = true;
            this.textBoxDbHost.Size = new System.Drawing.Size(190, 21);
            this.textBoxDbHost.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 24);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 0;
            this.label5.Text = "服务器地址";
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Location = new System.Drawing.Point(42, 28);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(29, 12);
            this.label.TabIndex = 1;
            this.label.Text = "密钥";
            // 
            // textBoxProductKey
            // 
            this.textBoxProductKey.BackColor = System.Drawing.Color.White;
            this.textBoxProductKey.Font = new System.Drawing.Font("黑体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBoxProductKey.Location = new System.Drawing.Point(77, 23);
            this.textBoxProductKey.Name = "textBoxProductKey";
            this.textBoxProductKey.ReadOnly = true;
            this.textBoxProductKey.Size = new System.Drawing.Size(440, 24);
            this.textBoxProductKey.TabIndex = 7;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.buttonClose);
            this.groupBox2.Controls.Add(this.buttonSN);
            this.groupBox2.Controls.Add(this.textBoxSN);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.buttonCommit);
            this.groupBox2.Controls.Add(this.buttonImei);
            this.groupBox2.Controls.Add(this.textBoxImei);
            this.groupBox2.Controls.Add(this.labelIMEI);
            this.groupBox2.Controls.Add(this.buttonBluetoothMacAddress);
            this.groupBox2.Controls.Add(this.textBoxBluetoothMacAddress);
            this.groupBox2.Controls.Add(this.labelBluetooth);
            this.groupBox2.Controls.Add(this.buttonWifiMacAddress);
            this.groupBox2.Controls.Add(this.textBoxWifiMacAddress);
            this.groupBox2.Controls.Add(this.labelWifi);
            this.groupBox2.Controls.Add(this.buttonGetProductKey);
            this.groupBox2.Controls.Add(this.textBoxProductKey);
            this.groupBox2.Controls.Add(this.label);
            this.groupBox2.Location = new System.Drawing.Point(12, 108);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(622, 349);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "设备信息";
            // 
            // buttonClose
            // 
            this.buttonClose.Font = new System.Drawing.Font("黑体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonClose.Location = new System.Drawing.Point(20, 287);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(115, 43);
            this.buttonClose.TabIndex = 17;
            this.buttonClose.Text = "关闭";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // buttonSN
            // 
            this.buttonSN.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonSN.Location = new System.Drawing.Point(532, 72);
            this.buttonSN.Name = "buttonSN";
            this.buttonSN.Size = new System.Drawing.Size(75, 23);
            this.buttonSN.TabIndex = 8;
            this.buttonSN.Text = "读取";
            this.buttonSN.UseVisualStyleBackColor = true;
            this.buttonSN.Click += new System.EventHandler(this.buttonSN_Click);
            // 
            // textBoxSN
            // 
            this.textBoxSN.BackColor = System.Drawing.Color.White;
            this.textBoxSN.Font = new System.Drawing.Font("黑体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBoxSN.Location = new System.Drawing.Point(77, 71);
            this.textBoxSN.Name = "textBoxSN";
            this.textBoxSN.ReadOnly = true;
            this.textBoxSN.Size = new System.Drawing.Size(440, 24);
            this.textBoxSN.TabIndex = 8;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(30, 76);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(41, 12);
            this.label9.TabIndex = 14;
            this.label9.Text = "序列号";
            // 
            // buttonCommit
            // 
            this.buttonCommit.Font = new System.Drawing.Font("黑体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonCommit.Location = new System.Drawing.Point(492, 287);
            this.buttonCommit.Name = "buttonCommit";
            this.buttonCommit.Size = new System.Drawing.Size(115, 43);
            this.buttonCommit.TabIndex = 16;
            this.buttonCommit.Text = "提交";
            this.buttonCommit.UseVisualStyleBackColor = true;
            this.buttonCommit.Click += new System.EventHandler(this.buttonCommit_Click);
            // 
            // buttonImei
            // 
            this.buttonImei.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonImei.Location = new System.Drawing.Point(533, 228);
            this.buttonImei.Name = "buttonImei";
            this.buttonImei.Size = new System.Drawing.Size(75, 23);
            this.buttonImei.TabIndex = 11;
            this.buttonImei.Text = "读取";
            this.buttonImei.UseVisualStyleBackColor = true;
            this.buttonImei.Click += new System.EventHandler(this.buttonImei_Click);
            // 
            // textBoxImei
            // 
            this.textBoxImei.BackColor = System.Drawing.Color.White;
            this.textBoxImei.Font = new System.Drawing.Font("黑体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBoxImei.Location = new System.Drawing.Point(77, 227);
            this.textBoxImei.Name = "textBoxImei";
            this.textBoxImei.ReadOnly = true;
            this.textBoxImei.Size = new System.Drawing.Size(440, 24);
            this.textBoxImei.TabIndex = 11;
            // 
            // labelIMEI
            // 
            this.labelIMEI.AutoSize = true;
            this.labelIMEI.Location = new System.Drawing.Point(42, 230);
            this.labelIMEI.Name = "labelIMEI";
            this.labelIMEI.Size = new System.Drawing.Size(29, 12);
            this.labelIMEI.TabIndex = 10;
            this.labelIMEI.Text = "IMEI";
            // 
            // buttonBluetoothMacAddress
            // 
            this.buttonBluetoothMacAddress.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonBluetoothMacAddress.Location = new System.Drawing.Point(533, 175);
            this.buttonBluetoothMacAddress.Name = "buttonBluetoothMacAddress";
            this.buttonBluetoothMacAddress.Size = new System.Drawing.Size(75, 23);
            this.buttonBluetoothMacAddress.TabIndex = 10;
            this.buttonBluetoothMacAddress.Text = "读取";
            this.buttonBluetoothMacAddress.UseVisualStyleBackColor = true;
            this.buttonBluetoothMacAddress.Click += new System.EventHandler(this.buttonBluetoothMacAddress_Click);
            // 
            // textBoxBluetoothMacAddress
            // 
            this.textBoxBluetoothMacAddress.BackColor = System.Drawing.Color.White;
            this.textBoxBluetoothMacAddress.Font = new System.Drawing.Font("黑体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBoxBluetoothMacAddress.Location = new System.Drawing.Point(77, 174);
            this.textBoxBluetoothMacAddress.Name = "textBoxBluetoothMacAddress";
            this.textBoxBluetoothMacAddress.ReadOnly = true;
            this.textBoxBluetoothMacAddress.Size = new System.Drawing.Size(440, 24);
            this.textBoxBluetoothMacAddress.TabIndex = 10;
            // 
            // labelBluetooth
            // 
            this.labelBluetooth.AutoSize = true;
            this.labelBluetooth.Location = new System.Drawing.Point(24, 179);
            this.labelBluetooth.Name = "labelBluetooth";
            this.labelBluetooth.Size = new System.Drawing.Size(47, 12);
            this.labelBluetooth.TabIndex = 7;
            this.labelBluetooth.Text = "蓝牙MAC";
            // 
            // buttonWifiMacAddress
            // 
            this.buttonWifiMacAddress.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonWifiMacAddress.Location = new System.Drawing.Point(533, 121);
            this.buttonWifiMacAddress.Name = "buttonWifiMacAddress";
            this.buttonWifiMacAddress.Size = new System.Drawing.Size(75, 23);
            this.buttonWifiMacAddress.TabIndex = 9;
            this.buttonWifiMacAddress.Text = "读取";
            this.buttonWifiMacAddress.UseVisualStyleBackColor = true;
            this.buttonWifiMacAddress.Click += new System.EventHandler(this.buttonWifiMacAddress_Click);
            // 
            // textBoxWifiMacAddress
            // 
            this.textBoxWifiMacAddress.BackColor = System.Drawing.Color.White;
            this.textBoxWifiMacAddress.Font = new System.Drawing.Font("黑体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBoxWifiMacAddress.Location = new System.Drawing.Point(77, 120);
            this.textBoxWifiMacAddress.Name = "textBoxWifiMacAddress";
            this.textBoxWifiMacAddress.ReadOnly = true;
            this.textBoxWifiMacAddress.Size = new System.Drawing.Size(440, 24);
            this.textBoxWifiMacAddress.TabIndex = 9;
            // 
            // labelWifi
            // 
            this.labelWifi.AutoSize = true;
            this.labelWifi.Location = new System.Drawing.Point(18, 129);
            this.labelWifi.Name = "labelWifi";
            this.labelWifi.Size = new System.Drawing.Size(53, 12);
            this.labelWifi.TabIndex = 4;
            this.labelWifi.Text = "WIFI MAC";
            // 
            // buttonGetProductKey
            // 
            this.buttonGetProductKey.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonGetProductKey.Location = new System.Drawing.Point(533, 23);
            this.buttonGetProductKey.Name = "buttonGetProductKey";
            this.buttonGetProductKey.Size = new System.Drawing.Size(75, 23);
            this.buttonGetProductKey.TabIndex = 7;
            this.buttonGetProductKey.Text = "读取";
            this.buttonGetProductKey.UseVisualStyleBackColor = true;
            this.buttonGetProductKey.Click += new System.EventHandler(this.buttonGetProductKey_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(646, 469);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Emdoor Product Info Reader";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.TextBox textBoxProductKey;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button buttonCommit;
        private System.Windows.Forms.Button buttonImei;
        private System.Windows.Forms.TextBox textBoxImei;
        private System.Windows.Forms.Label labelIMEI;
        private System.Windows.Forms.Button buttonBluetoothMacAddress;
        private System.Windows.Forms.TextBox textBoxBluetoothMacAddress;
        private System.Windows.Forms.Label labelBluetooth;
        private System.Windows.Forms.Button buttonWifiMacAddress;
        private System.Windows.Forms.TextBox textBoxWifiMacAddress;
        private System.Windows.Forms.Label labelWifi;
        private System.Windows.Forms.Button buttonGetProductKey;
        private System.Windows.Forms.TextBox textBoxDbPassword;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBoxDbUser;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBoxDbName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxDbHost;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button buttonSN;
        private System.Windows.Forms.TextBox textBoxSN;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Button buttonConnect;
    }
}

