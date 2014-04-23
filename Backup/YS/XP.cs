using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DevExpress.Xpo;
using DevExpress.Xpo.DB;

namespace YS
{
    public static class XP
    {
        static DevExpress.Xpo.Session _session = null;

        public static void Connect(string ConnStr)
        {
            DevExpress.Xpo.Metadata.XPDictionary dictionary = new DevExpress.Xpo.Metadata.ReflectionDictionary();
            XpoDefault.DataLayer = XpoDefault.GetDataLayer(ConnStr, AutoCreateOption.DatabaseAndSchema);
            _session = new DevExpress.Xpo.Session(XpoDefault.DataLayer);
            try
            {   //db versiyonu farkliysa kendisi gunceller zaten
                _session.UpdateSchema();

            }
            catch (Exception ee)
            {
            }

        }

        public static DevExpress.Xpo.Session Crs { get { return _session; } }
    }
}
