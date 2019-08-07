﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Management;
using System.Windows;

namespace Kiosk.license
{
    class Security
    {

        private static String SALT = "15E99F77CA57B6ADE994F3F13C31BB2A";
        private static String path = @"C:\ezitech\license.txt";
        private static String path2 = @"C:\ezitech\";



        public static Boolean licenceChecker()
        {
            if (!File.Exists(path))
            {
                System.IO.Directory.CreateDirectory(path2);
                return false;
            }
            else
            {
                string licence = File.ReadAllText(path);
                return checkLicenceValidity(licence);
            }

        }


        private static Boolean checkLicenceValidity(String licence)
        {
            //add to version2
            string client_key = G.client_key;
            client_key = "xxx" + client_key + "yyy";
            licence = Crypt.DecryptString(licence, client_key);
            //add to version2

            String key = licence.Substring(0, 16);
            String encrypted = licence.Substring(16, licence.Length - 16);

            String hashPart = Crypt.DecryptString(encrypted, key);
            if (hashPart == (getHash(G.client_key + key + SALT)) + key)
            {
                return true;
            }

            return false;
        }


        private static String getSystemData()
        {
            String data =
            Environment.ProcessorCount + "/" +
            Environment.MachineName + "/" +
            getCpuInfo() +
            Environment.UserName + "/";
            //+ Environment.GetLogicalDrives().Length;

            return data;
        }


        public static String getClientKey()
        {
            String id = String.Empty;
            byte hashCount = Convert.ToByte(getHash(SALT + getSystemData() + SALT)[5]);

            for (int i = -1; i < (hashCount % 7); i += 2)
            {
                id = getHash(SALT + getSystemData() + SALT);
            }
            return id.Substring(3, 10);

        }


        private static String getCpuInfo()
        {
            string cpuInfo = string.Empty;
            ManagementClass mc = new ManagementClass("win32_processor");
            ManagementObjectCollection moc = mc.GetInstances();

            foreach (ManagementObject mo in moc)
            {
                cpuInfo = mo.Properties["processorID"].Value.ToString();
                break;
            }
            return cpuInfo;
        }


        private static string getHash(string input)
        {

            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("X2"));
                }
                return sb.ToString();
            }
        }
    }
}
