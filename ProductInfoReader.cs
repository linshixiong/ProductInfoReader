using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.IO;
using System.Net.NetworkInformation;
using System.Collections;
using Microsoft.Win32;
using System.Threading;


namespace ProductInfoReader
{
    class ProductInfoReader
    {
        public static string getWifiMacAddress()
        {
            string strMac = null;
            NetworkInterface[] interfaces = NetworkInterface.GetAllNetworkInterfaces();
            foreach (NetworkInterface ni in interfaces)
            {
                if (ni.NetworkInterfaceType == NetworkInterfaceType.Wireless80211)
                {
                    strMac = ni.GetPhysicalAddress().ToString();
                    strMac = formatMacAddress(strMac);
                    break;
                }
            }
            return strMac;
        }

        public static string getBluetoothMacAddress()
        {
            string strMac = null;
            NetworkInterface[] interfaces = NetworkInterface.GetAllNetworkInterfaces();
            foreach (NetworkInterface ni in interfaces)
            {
                if (ni.NetworkInterfaceType == NetworkInterfaceType.Ethernet && (ni.Name.Contains("Bluetooth") || ni.Description.Contains("Bluetooth")))
                {
                    strMac = ni.GetPhysicalAddress().ToString();
                    strMac = formatMacAddress(strMac);
                    break;
                }
            }
            return strMac;

        }


        public static string getSerialNumber()
        {
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            process.StartInfo.FileName = "wmic.exe";
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.CreateNoWindow = true;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.RedirectStandardInput = true;
            process.Start();

            process.StandardInput.WriteLine("bios get serialnumber");
            process.StandardInput.WriteLine("exit");
            process.StandardInput.AutoFlush = true;

            StreamReader reader = process.StandardOutput;
            string line = reader.ReadLine();
            while (!reader.EndOfStream)
            {
                line = reader.ReadLine().Trim();
                if (line.Length > 0)
                {
                    break;
                }
            }
            process.WaitForExit();
            reader.Close();
            process.Close();

            return line.StartsWith("To be filled") ? null : line;
        }

        public static string getIMEI()
        {
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            process.StartInfo.FileName = "netsh.exe";
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.CreateNoWindow = true;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.RedirectStandardInput = true;
            process.Start();

            process.StandardInput.WriteLine("mbn show interface");
            process.StandardInput.WriteLine("exit");
            process.StandardInput.AutoFlush = true;

            StreamReader reader = process.StandardOutput;

            string line = reader.ReadLine();
            int index = 0;
            string result = "";
            while (!reader.EndOfStream)
            {
                line = reader.ReadLine().Trim();
                index++;
                if (index==10)
                {

                    result = line.Split(':')[1].Trim() ; 
                   
                    break;
                }
            }
            process.WaitForExit();
            reader.Close();
            process.Close();

            
            return result;
        }



        public static string GetWindowsProductKey()
        {
            var key = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine,
                                          RegistryView.Default);
            const string keyPath = @"Software\Microsoft\Windows NT\CurrentVersion";
            var digitalProductId = (byte[])key.OpenSubKey(keyPath).GetValue("DigitalProductId");

            var isWin8OrUp =
                (Environment.OSVersion.Version.Major == 6 && System.Environment.OSVersion.Version.Minor >= 2)
                ||
                (Environment.OSVersion.Version.Major > 6);

            var productKey = isWin8OrUp ? DecodeProductKeyWin8AndUp(digitalProductId) : DecodeProductKey(digitalProductId);
            return productKey;
        }

        public static Int64 GetWindowsProductId()
        {
            var key = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine,
                                          RegistryView.Default);
            const string keyPath = @"Software\Microsoft\Windows NT\CurrentVersion";
            string productId = (string)key.OpenSubKey(keyPath).GetValue("ProductId");

            productId= productId.Replace("-", "");
            if (productId.Length == 20)
            {
                productId = productId.Substring(2, 13);
                
                return Convert.ToInt64(productId);
            }
            else
            {
                return 0;
            }
        }


        private static string formatMacAddress(string strMac)
        {
            
            StringBuilder macAddress = new StringBuilder();
            for (int i = 0; i < 6; i++)
            {
                if (i == 5)
                {
                    macAddress.Append(strMac.Substring(i*2 , 2));
                }
                else
                {
                    macAddress.Append(strMac.Substring(i*2, 2) + "-");
                }

            }
           return macAddress.ToString();
        }

        private static string DecodeProductKey(byte[] digitalProductId)
        {
            const int keyStartIndex = 52;
            const int keyEndIndex = keyStartIndex + 15;
            var digits = new[]
            {
                'B', 'C', 'D', 'F', 'G', 'H', 'J', 'K', 'M', 'P', 'Q', 'R',
                'T', 'V', 'W', 'X', 'Y', '2', '3', '4', '6', '7', '8', '9',
            };
            const int decodeLength = 29;
            const int decodeStringLength = 15;
            var decodedChars = new char[decodeLength];
            var hexPid = new ArrayList();
            for (var i = keyStartIndex; i <= keyEndIndex; i++)
            {
                hexPid.Add(digitalProductId[i]);
            }
            for (var i = decodeLength - 1; i >= 0; i--)
            {
                // Every sixth char is a separator.
                if ((i + 1) % 6 == 0)
                {
                    decodedChars[i] = '-';
                }
                else
                {
                    // Do the actual decoding.
                    var digitMapIndex = 0;
                    for (var j = decodeStringLength - 1; j >= 0; j--)
                    {
                        var byteValue = (digitMapIndex << 8) | (byte)hexPid[j];
                        hexPid[j] = (byte)(byteValue / 24);
                        digitMapIndex = byteValue % 24;
                        decodedChars[i] = digits[digitMapIndex];
                    }
                }
            }
            return new string(decodedChars);
        }

        private static string DecodeProductKeyWin8AndUp(byte[] digitalProductId)
        {
            var key = String.Empty;
            const int keyOffset = 52;
            var isWin8 = (byte)((digitalProductId[66] / 6) & 1);
            digitalProductId[66] = (byte)((digitalProductId[66] & 0xf7) | (isWin8 & 2) * 4);

            const string digits = "BCDFGHJKMPQRTVWXY2346789";
            int last = 0;
            for (var i = 24; i >= 0; i--)
            {
                var current = 0;
                for (var j = 14; j >= 0; j--)
                {
                    current = current * 256;
                    current = digitalProductId[j + keyOffset] + current;
                    digitalProductId[j + keyOffset] = (byte)(current / 24);
                    current = current % 24;
                    last = current;
                }
                key = digits[current] + key;
            }

            var keypart1 = key.Substring(1, last);
            var keypart2 = key.Substring(last + 1, key.Length - (last + 1));
            key = keypart1 + "N" + keypart2;

            for (var i = 5; i < key.Length; i += 6)
            {
                key = key.Insert(i, "-");
            }

            return key;
        }
    }
}
