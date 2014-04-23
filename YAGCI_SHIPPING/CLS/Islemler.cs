using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace YAGCI_SHIPPING.Kls
{
    class Islemler
    {
        public string BuyutTemizle(string STR)
        {
            return STR
                .Replace(",", "")
                .Replace("'", "")
                .ToUpper().Trim();
        }


        public static object CloneObj(object src, object trgt)
        {
            if (src == null || trgt == null) return trgt;

            PropertyInfo[] src_ps = src.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);
            PropertyInfo[] trgt_ps = trgt.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);

            foreach (PropertyInfo srcp in src_ps)
            {
                PropertyInfo trg = trgt_ps.Where(x => x.Name == srcp.Name).First();

                if (!trg.CanWrite) continue;
                trg.SetValue(trgt, srcp.GetValue(src, null), null);
            }

            return trgt;
        }

    }

    public enum Hareketler
    {
        MalKabul = 1,
        Yukleme = 2,
        Satis = 3,
    }

    
}
