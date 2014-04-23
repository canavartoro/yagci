 
    using Microsoft.Win32;
    using System;

    public class TRegister
    {
        private RegistryKey hKey;
        private string hKeyName;

        public TRegister()
        {
        }

        public TRegister(RegistryKey pkey)
        {
            this.hKey = pkey;
        }

        public TRegister(string keyname)
        {
            this.hKeyName = keyname;
        }

        //public RegistryKey GetKeyByName(RegistryHive hive, string path)
        //{
        //    if (hive == -2147483648)
        //    {
        //        return Registry.ClassesRoot.OpenSubKey(path, true);
        //    }
        //    if (hive == -2147483643)
        //    {
        //        return Registry.CurrentConfig.OpenSubKey(path, true);
        //    }
        //    if (hive != -2147483647)
        //    {
        //        if (hive == -2147483642)
        //        {
        //            return Registry.DynData.OpenSubKey(path, true);
        //        }
        //        if (hive == -2147483646)
        //        {
        //            return Registry.LocalMachine.OpenSubKey(path, true);
        //        }
        //        if (hive == -2147483644)
        //        {
        //            return Registry.PerformanceData.OpenSubKey(path, true);
        //        }
        //        if (hive == -2147483645)
        //        {
        //            return Registry.Users.OpenSubKey(path, true);
        //        }
        //    }
        //    return Registry.CurrentUser.OpenSubKey(path, true);
        //}

        public string ReadRegister(string key, string dvalue)
        {
            try
            {
                if (Registry.CurrentUser.OpenSubKey("Barset") == null)
                {
                    return null;
                }
                RegistryKey key2 = Registry.CurrentUser.OpenSubKey("Barset");
                string str = key2.GetValue(key, dvalue).ToString();
                key2.Close();
                return str;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public string ReadRegister(string name, string key, string dvalue)
        {
            try
            {
                if (Registry.CurrentUser.OpenSubKey("Barset") == null)
                {
                    return null;
                }
                RegistryKey key2 = Registry.CurrentUser.OpenSubKey("Barset");
                RegistryKey key3 = key2.OpenSubKey(name, true);
                if (key3 == null)
                {
                    key2.Close();
                    return null;
                }
                if (key3.GetValue(key) == null)
                {
                    return null;
                }
                string str = key3.GetValue(key).ToString();
                key3.Close();
                key2.Close();
                return str;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public bool WriteRegister(string key, string svalue)
        {
            try
            {
                if (Registry.CurrentUser.OpenSubKey("Barset", true) == null)
                {
                    Registry.CurrentUser.CreateSubKey("Barset");
                }
                Registry.CurrentUser.OpenSubKey("Barset", true).SetValue(key, svalue);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool WriteRegister(string name, string key, string svalue)
        {
            try
            {
                if (Registry.CurrentUser.OpenSubKey("Barset", true) == null)
                {
                    Registry.CurrentUser.CreateSubKey("Barset");
                }
                RegistryKey key2 = Registry.CurrentUser.OpenSubKey("Barset", true);
                if (key2.OpenSubKey(name, true) == null)
                {
                    key2.CreateSubKey(name);
                }
                key2.OpenSubKey(name, true).SetValue(key, svalue);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
 

