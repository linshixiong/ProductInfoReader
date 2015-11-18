using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;
using System.Collections;
using System.Configuration;
using System.Data.SqlClient;
using System.Threading;


namespace ProductInfoReader
{
    public partial class FormMain : Form
    {
        private string dbType;
        private string dbSource;
        private string dbName;
        private string dbUserId;
        private string dbPassword;
        private bool dbIntegratedSecurity;

        private bool enableWifiMacAddress;
        private bool enableBluetoothMacAddress;
        private bool enableImei;

        private string product_key;
        private Int64 product_id;
        private string sn;
        private string wifi_mac_address;
        private string bluetooth_mac_address;
        private string imei;

        public delegate void MyDelegate(int a);

        private const int MSG_CHECK_CONNECTION_END = 0;
        private const int MSG_COMMIT_END = 1;
        private const int MSG_UPDATE_PRODUCT_KEY = 2;
        private const int MSG_UPDATE_SN = 3;
        private const int MSG_UPDATE_WIFI_MAC = 4;
        private const int MSG_UPDATE_BT_MAC = 5;
        private const int MSG_UPDATE_IMEI = 6;

        public FormMain()
        {
            InitializeComponent();
            if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings["app_name"]))
            {
                this.Text = ConfigurationManager.AppSettings["app_name"];
            }

            try
            {
                this.enableWifiMacAddress = Convert.ToBoolean(ConfigurationManager.AppSettings["enable_wifi_mac_address"]);
            }
            catch (FormatException) { }
            try
            {
                this.enableBluetoothMacAddress = Convert.ToBoolean(ConfigurationManager.AppSettings["enable_bluetooth_mac_address"]);
            }
            catch (FormatException) { }

            try
            {
                this.enableImei = Convert.ToBoolean(ConfigurationManager.AppSettings["enable_imei"]);
            }
            catch (FormatException) { }
            try
            {
                this.dbIntegratedSecurity = Convert.ToBoolean(ConfigurationManager.AppSettings["db_integrated_security"]);
            }
            catch (FormatException) { }

            this.textBoxWifiMacAddress.Enabled = enableWifiMacAddress;
            this.buttonWifiMacAddress.Enabled = enableWifiMacAddress;
            this.labelWifi.Enabled = enableWifiMacAddress;
            this.textBoxBluetoothMacAddress.Enabled = enableBluetoothMacAddress;
            this.buttonBluetoothMacAddress.Enabled = enableBluetoothMacAddress;
            this.labelBluetooth.Enabled = enableBluetoothMacAddress;
            this.textBoxImei.Enabled = enableImei;
            this.buttonImei.Enabled = enableImei;
            this.labelIMEI.Enabled = enableImei;

            this.dbType = ConfigurationManager.AppSettings["db_type"];
            this.dbSource = ConfigurationManager.AppSettings["db_host"];
            this.dbName = ConfigurationManager.AppSettings["db_name"];
            this.dbUserId = ConfigurationManager.AppSettings["db_user"];
            this.dbPassword = ConfigurationManager.AppSettings["db_password"];

            this.textBoxDbHost.Text = dbSource;
            this.textBoxDbName.Text = dbName;
            this.textBoxDbUser.Text = dbUserId;
            this.textBoxDbPassword.Text = dbPassword;


        }




        private void buttonGetProductKey_Click(object sender, EventArgs e)
        {
            buttonGetProductKey.Enabled = false;
            buttonGetProductKey.Text = "读取中..";
            Thread thread = new Thread(new ThreadStart(getProductKey));
            thread.Start();
        }


        private void buttonSN_Click(object sender, EventArgs e)
        {
            buttonSN.Enabled = false;
            buttonSN.Text = "读取中..";
            Thread thread = new Thread(new ThreadStart(getSN));
            thread.Start();
        }

        private void buttonWifiMacAddress_Click(object sender, EventArgs e)
        {
            buttonWifiMacAddress.Enabled = false;
            buttonWifiMacAddress.Text = "读取中..";
            Thread thread = new Thread(new ThreadStart(getWifiMacAddress));
            thread.Start();
        }

        private void buttonBluetoothMacAddress_Click(object sender, EventArgs e)
        {
            buttonBluetoothMacAddress.Enabled = false;
            buttonBluetoothMacAddress.Text = "读取中..";
            Thread thread = new Thread(new ThreadStart(getBluetoothMacAddress));
            thread.Start();
        }

        private void buttonImei_Click(object sender, EventArgs e)
        {
            buttonImei.Enabled = false;
            buttonImei.Text = "读取中..";
            Thread thread = new Thread(new ThreadStart(getImei));
            thread.Start();
        }

        private void buttonCommit_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(textBoxProductKey.Text))
            {
                MessageBox.Show("无效的密钥！", "提交失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(textBoxSN.Text))
            {
                MessageBox.Show("无效的序列号！", "提交失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (enableWifiMacAddress && String.IsNullOrEmpty(textBoxWifiMacAddress.Text))
            {
                MessageBox.Show("无效的WIFI MAC地址！", "提交失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (enableBluetoothMacAddress && String.IsNullOrEmpty(textBoxBluetoothMacAddress.Text))
            {
                MessageBox.Show("无效的蓝牙MAC地址！", "提交失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (enableImei && String.IsNullOrEmpty(textBoxImei.Text))
            {
                MessageBox.Show("无效的IMEI号！", "提交失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Thread thread = new Thread(new ThreadStart(commitData));
            this.buttonConnect.Enabled = false;
            this.buttonCommit.Enabled = false;
            this.buttonCommit.Text = "提交中..";
            thread.Start();
        }


        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonConnect_Click(object sender, EventArgs e)
        {


            Thread thread = new Thread(new ThreadStart(checkDatabaseConnection));
            this.buttonConnect.Enabled = false;
            this.buttonCommit.Enabled = false;
            this.buttonConnect.Text = "测试中..";
            thread.Start();
        }

        private void getProductKey()
        {
            try
            {
                this.product_key = ProductInfoReader.GetWindowsProductKey();
                this.product_id = ProductInfoReader.GetWindowsProductId();
                //MessageBox.Show(product_id.ToString());
                this.Invoke(new MyDelegate(updateUI), MSG_UPDATE_PRODUCT_KEY);
            }
            catch (Exception)
            {
            }
        }

        private void getSN()
        {
            try
            {
                this.sn = ProductInfoReader.getSerialNumber();
                this.Invoke(new MyDelegate(updateUI), MSG_UPDATE_SN);
            }
            catch (Exception)
            {
            }
        }

        private void getWifiMacAddress()
        {
            try
            {
                this.wifi_mac_address = ProductInfoReader.getWifiMacAddress();
                this.Invoke(new MyDelegate(updateUI), MSG_UPDATE_WIFI_MAC);
            }
            catch (Exception)
            {
            }
        }


        private void getBluetoothMacAddress()
        {
            try
            {
                this.bluetooth_mac_address = ProductInfoReader.getBluetoothMacAddress();
                this.Invoke(new MyDelegate(updateUI), MSG_UPDATE_BT_MAC);
            }
            catch (Exception)
            {
            }
        }

        private void getImei()
        {
            try
            {
                this.imei = ProductInfoReader.getIMEI();
                this.Invoke(new MyDelegate(updateUI), MSG_UPDATE_IMEI);
            }
            catch (Exception)
            {
            }
        }

        private void checkDatabaseConnection()
        {
            try
            {
                DBHelper helper = new DBHelper(dbType, dbSource, dbUserId, dbPassword, dbName, dbIntegratedSecurity);
                int resut = Convert.ToInt32(helper.ExecuteScalar("select count(ID) from [PostKey]", CommandType.Text, null));
                MessageBox.Show("数据库连接正常", "测试数据库连接", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("数据库连接失败!\n" + ex.Message, "测试数据库连接", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Invoke(new MyDelegate(updateUI), MSG_CHECK_CONNECTION_END);
            }

        }

        private void getDeviceDataState()
        {

        }

        private void updateData()
        {

        }

        private void commitData()
        {
            try
            {
                DBHelper helper = new DBHelper(dbType, dbSource, dbUserId, dbPassword, dbName, dbIntegratedSecurity);

                List<IDbDataParameter> sqlParamList = new List<IDbDataParameter>();

                sqlParamList.Add(new SqlParameter("@SN", this.textBoxSN.Text));

                object result = helper.ExecuteScalar(@"SELECT [IsValid] FROM [PostKey] 
                                    where [sn]=@SN", CommandType.Text, sqlParamList.ToArray());

                bool isValid = result == null ? false : Convert.ToBoolean(result);

                sqlParamList = new List<IDbDataParameter>();
                sqlParamList.Add(new SqlParameter("@KEY", this.textBoxProductKey.Text));
                sqlParamList.Add(new SqlParameter("@SN", this.textBoxSN.Text));
                sqlParamList.Add(new SqlParameter("@WIFI", this.textBoxWifiMacAddress.Text));
                sqlParamList.Add(new SqlParameter("@BT", this.textBoxBluetoothMacAddress.Text));
                sqlParamList.Add(new SqlParameter("@IMEI", this.textBoxImei.Text));
                sqlParamList.Add(new SqlParameter("@POST_TIME", DateTime.Now));
                sqlParamList.Add(new SqlParameter("@ProductKeyID", this.product_id));
                int count = 0;
                if (result == null )
                {
                    count = helper.ExecuteNonQuery(@"INSERT INTO [PostKey] 
                            ([key],[sn],[wifiMac],[bluetoothMac],[imei],[post_time],[ProductKeyID])
                             VALUES
                            (@KEY,@SN,@WIFI,@BT,@IMEI,@POST_TIME,@ProductKeyID)", CommandType.Text, sqlParamList.ToArray());

                }
                else if(!isValid)
                {
                    count = helper.ExecuteNonQuery(@"UPDATE [PostKey] SET
                            [key]=@KEY,[wifiMac]=@WIFI,[bluetoothMac]=@BT,[imei]=@IMEI,[ProductKeyID]= @ProductKeyID ,[LatestModifiedDate]=@POST_TIME,[IsValid]='true' 
                            WHERE [sn]=@SN", CommandType.Text, sqlParamList.ToArray());
                }
                else
                {
                    MessageBox.Show("无法重复提交相同的序列号！", "提交失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (count > 0)
                {
                    MessageBox.Show("提交成功", "操作结果", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "提交失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Invoke(new MyDelegate(updateUI), MSG_COMMIT_END);
            }
        }

        private void updateUI(int value)
        {
            switch (value)
            {
                case MSG_CHECK_CONNECTION_END:
                    this.buttonConnect.Enabled = true;
                    this.buttonConnect.Text = "测试连接";
                    this.buttonCommit.Enabled = true;
                    break;
                case MSG_COMMIT_END:
                    this.buttonConnect.Enabled = true;
                    this.buttonCommit.Text = "提交";
                    this.buttonCommit.Enabled = true;
                    break;
                case MSG_UPDATE_PRODUCT_KEY:
                    this.textBoxProductKey.Text = product_key;
                    this.buttonGetProductKey.Enabled = true;
                    this.buttonGetProductKey.Text = "读取";
                    break;
                case MSG_UPDATE_SN:
                    this.textBoxSN.Text = sn;
                    this.buttonSN.Enabled = true;
                    this.buttonSN.Text = "读取";
                    break;
                case MSG_UPDATE_WIFI_MAC:
                    this.textBoxWifiMacAddress.Text = wifi_mac_address;
                    this.buttonWifiMacAddress.Enabled = true;
                    this.buttonWifiMacAddress.Text = "读取";
                    break;
                case MSG_UPDATE_BT_MAC:
                    this.textBoxBluetoothMacAddress.Text = bluetooth_mac_address;
                    this.buttonBluetoothMacAddress.Enabled = true;
                    this.buttonBluetoothMacAddress.Text = "读取";
                    break;
                case MSG_UPDATE_IMEI:
                    this.textBoxImei.Text = imei;
                    this.buttonImei.Enabled = true;
                    this.buttonImei.Text = "读取";
                    break;
                default:
                    break;

            }

        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            buttonGetProductKey.Enabled = false;
            buttonGetProductKey.Text = "读取中..";
            Thread thread1 = new Thread(new ThreadStart(getProductKey));
            thread1.Start();

            buttonSN.Enabled = false;
            buttonSN.Text = "读取中..";
            Thread thread2 = new Thread(new ThreadStart(getSN));
            thread2.Start();

            if (enableWifiMacAddress)
            {
                buttonWifiMacAddress.Enabled = false;
                buttonWifiMacAddress.Text = "读取中..";
                Thread thread3 = new Thread(new ThreadStart(getWifiMacAddress));
                thread3.Start();
            }
            if (enableBluetoothMacAddress)
            {
                buttonBluetoothMacAddress.Enabled = false;
                buttonBluetoothMacAddress.Text = "读取中..";
                Thread thread4 = new Thread(new ThreadStart(getBluetoothMacAddress));
                thread4.Start();
            }
            if (enableImei)
            {
                buttonImei.Enabled = false;
                buttonImei.Text = "读取中..";
                Thread thread5 = new Thread(new ThreadStart(getImei));
                thread5.Start();
            }
        }

    }
}
