using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Management;
using System.IO;
using System.Windows.Forms;

namespace YAGCI_SHIPPING.Kls
{
    class Lisans
    {
        const string Key = "Canavar.Toro@Cakabo";
        public static bool LISANSLI = false;
        public static DateTime LISANS_TARIH = DateTime.Now;

        private static string HDDSerialNumber()
        {
            string serial = null;
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_PhysicalMedia");
            foreach (ManagementObject disk in searcher.Get())
            {
                if (disk["SerialNumber"] == null)
                    serial = "TANIMSIZ";
                else
                {
                    serial = disk["SerialNumber"].ToString();
                    break;
                }
            }
            return serial;
        }

        private static string HashMd5(string MD5)
        {
            System.Text.UTF8Encoding ue = new System.Text.UTF8Encoding();
            byte[] bytes = ue.GetBytes(MD5);

            // encrypt bytes
            System.Security.Cryptography.MD5CryptoServiceProvider md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
            byte[] hashBytes = md5.ComputeHash(bytes);

            string hashString = "";

            for (int i = 0; i < hashBytes.Length; i++)
            {
                hashString += Convert.ToString(hashBytes[i], 16).PadLeft(2, '0');
            }

            return hashString.PadLeft(16, '0');
        }

        private static string Sifrele(string kaynak, string anahtar)
        {
            string filtre = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string hedef = "";
            int XOR = 0;
            for (int i = 0; i < anahtar.Length; i++)
                XOR = XOR + (int)(anahtar[i] * 10);
            for (int i = 0; i < kaynak.Length; i++)
            {
                hedef += filtre[(((int)kaynak[i] ^ XOR) % filtre.Length)];
            }
            return hedef;
        }

        public static bool LisansDogrula(string lisans)
        {
            if (lisans.Length < 16)
            {
                LISANSLI = false;
                return false;
            }
            string kod = ((HashMd5(HDDSerialNumber())).ToUpper()).Substring(0, 16);
            string sonuc = Sifrele(kod.ToUpper(), Key);
            if (lisans == sonuc)
            {
                LISANSLI = true;
                return true;
            }
            LISANSLI = false;
            return false;
        }

        public static string LisansKontrol()
        {
            string lisans = "";
            FileStream fs;
            BinaryReader br;
            try
            {
                FileInfo fi = new FileInfo(Application.StartupPath + "\\Lisans.inc");
                if (fi.Exists)
                    LISANS_TARIH = fi.CreationTime;
                fs = new FileStream(fi.FullName, FileMode.OpenOrCreate);
                br = new BinaryReader(fs);
                for (int i = 0; i < 16; i++)
                    lisans += br.ReadChar().ToString();
                br.Close();
                fs.Close();
            }
            catch
            {
                lisans = "";
            }
            return lisans;
        }

        public static string UrunAnahtari()
        {
            return HashMd5(HDDSerialNumber()).ToUpper();
        }

        public static string CreateKey(string kod)
        {
            string sonuc = Sifrele(kod.ToUpper().TrimEnd().TrimStart(), Key);
            return sonuc;
        }
    }
}
