using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace YS
{
    /// <summary>
    /// Summary description for serv
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class serv : System.Web.Services.WebService
    {
        [WebMethod]
        public List<YAGCI_SHIPPING.Data.Tables.FORMGENERIC> KayitlariAl()
        {
            DevExpress.Xpo.XPCollection<YAGCI_SHIPPING.Data.Tables.FORMGENERIC> frms =
                new DevExpress.Xpo.XPCollection<YAGCI_SHIPPING.Data.Tables.FORMGENERIC>(XP.Crs);
            List<YAGCI_SHIPPING.Data.Tables.FORMGENERIC> lisresp = frms.ToList();
            return lisresp;
        }

        [WebMethod]
        public List<YAGCI_SHIPPING.Data.Tables.GENERIC> FormlariAl()
        {
            DevExpress.Xpo.XPCollection<YAGCI_SHIPPING.Data.Tables.GENERIC> frms =
                new DevExpress.Xpo.XPCollection<YAGCI_SHIPPING.Data.Tables.GENERIC>(XP.Crs);
            List<YAGCI_SHIPPING.Data.Tables.GENERIC> lisresp = frms.ToList();
            return lisresp;
        }

        [WebMethod]
        public ServisResult FormDataAktar(List<YAGCI_SHIPPING.Data.Tables.FORMGENERIC> data)
        {
            try
            {
                if (data != null && data.Count > 0)
                {
                    foreach (YAGCI_SHIPPING.Data.Tables.FORMGENERIC frm in data)
                    {
                        frm.Save();
                    }
                }
            }
            catch (Exception exc)
            {
                return new ServisResult(exc.Message);
            }
            return new ServisResult(true);
        }
    }

    public class ServisResult
    {
        public ServisResult()
        {
            this.Durum = false;
            this.Sonuc = "";
        }

        public ServisResult(bool drm)
        {
            this.Durum = drm;
            this.Sonuc = "";
        }

        public ServisResult(string err)
        {
            this.Durum = false;
            this.Sonuc = err;
        }

        public bool Durum { get; set; }
        public string Sonuc { get; set; }

        public override string ToString()
        {
            return string.Format("Sonuc:{0} Bilgi:{1}", Durum, Sonuc);
        }
    }
}
