using System;
using System.Linq;
using DevExpress.Xpo;
using DevExpress.Data.Filtering;
using DevExpress.Xpo.DB;

namespace YAGCI_SHIPPING.DB
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
                XPQuery<YAGCI_SHIPPING.Data.Tables.FORMLAR> xfrm = new XPQuery<YAGCI_SHIPPING.Data.Tables.FORMLAR>(_session);
                var xCount = (from x in xfrm select new { x.Oid }).Count();
                if (xCount < 1)
                {
                    using (UnitOfWork wrk = new UnitOfWork())
                    {
                        YAGCI_SHIPPING.Data.Tables.KULLANICIGRUP grp = wrk.FindObject<YAGCI_SHIPPING.Data.Tables.KULLANICIGRUP>(CriteriaOperator.Parse(" GRUPAD = ? ", "1"));
                        if (grp == null)
                        {
                            grp = new YAGCI_SHIPPING.Data.Tables.KULLANICIGRUP(wrk);
                            grp.GRUPAD = "1";
                            grp.Save();
                        }

                        YAGCI_SHIPPING.Data.Tables.FORMLAR F1 = new YAGCI_SHIPPING.Data.Tables.FORMLAR(wrk);
                        F1.AD = "KL FORMLARI";
                        F1.BASLIK = "KL FORMLARI";
                        F1.Save();

                        YAGCI_SHIPPING.Data.Tables.KULLANICIGRUPDETAYLARI grpdet1 = new YAGCI_SHIPPING.Data.Tables.KULLANICIGRUPDETAYLARI(wrk);
                        grpdet1.GRUPID = grp;
                        grpdet1.FORMID = F1;
                        grpdet1.Save();

                        YAGCI_SHIPPING.Data.Tables.FORMLAR F2 = new YAGCI_SHIPPING.Data.Tables.FORMLAR(wrk);
                        F2.AD = "GEMÝ FORMLARI";
                        F2.BASLIK = "GEMÝ FORMLARI";
                        F2.Save();

                        YAGCI_SHIPPING.Data.Tables.KULLANICIGRUPDETAYLARI grpdet2 = new YAGCI_SHIPPING.Data.Tables.KULLANICIGRUPDETAYLARI(wrk);
                        grpdet2.GRUPID = grp;
                        grpdet2.FORMID = F2;
                        grpdet2.Save();

                        YAGCI_SHIPPING.Data.Tables.FORMLAR F3 = new YAGCI_SHIPPING.Data.Tables.FORMLAR(wrk);
                        F3.AD = "PLANLI BAKIM FORMLARI";
                        F3.BASLIK = "PLANLI BAKIM FORMLARI";
                        F3.Save();

                        YAGCI_SHIPPING.Data.Tables.KULLANICIGRUPDETAYLARI grpdet3 = new YAGCI_SHIPPING.Data.Tables.KULLANICIGRUPDETAYLARI(wrk);
                        grpdet3.GRUPID = grp;
                        grpdet3.FORMID = F3;
                        grpdet3.Save();

                        YAGCI_SHIPPING.Data.Tables.FORMLAR F4 = new YAGCI_SHIPPING.Data.Tables.FORMLAR(wrk);
                        F4.AD = "ÞÝRKET";
                        F4.BASLIK = "ÞÝRKET";
                        F4.Save();

                        YAGCI_SHIPPING.Data.Tables.KULLANICIGRUPDETAYLARI grpdet4 = new YAGCI_SHIPPING.Data.Tables.KULLANICIGRUPDETAYLARI(wrk);
                        grpdet4.GRUPID = grp;
                        grpdet4.FORMID = F4;
                        grpdet4.Save();

                        YAGCI_SHIPPING.Data.Tables.FORMLAR F5 = new YAGCI_SHIPPING.Data.Tables.FORMLAR(wrk);
                        F5.AD = "ISPS FORMLARI";
                        F5.BASLIK = "ISPS FORMLARI";
                        F5.Save();

                        YAGCI_SHIPPING.Data.Tables.KULLANICIGRUPDETAYLARI grpdet5 = new YAGCI_SHIPPING.Data.Tables.KULLANICIGRUPDETAYLARI(wrk);
                        grpdet5.GRUPID = grp;
                        grpdet5.FORMID = F5;
                        grpdet5.Save();

                        wrk.CommitChanges();
                    }
                }
            }
            catch (Exception ee)
            {

                Kls.Dlg.Hata(ee.Message);
            }
            
        }

        public static DevExpress.Xpo.Session Crs { get { return _session; } }
    }


    public enum Donem : byte
    {
        YIL = 0,
        DONEM = 1,
        AYLIK = 2
    }

    public enum MOD : byte
    {
        Client = 0,
        Server = 1,
    }

    public enum TalepDurumlari : byte
    {
        Oneri = 0,
        Beklemede = 1,
        Onaylandi = 2,
        Iptal = 3,
        Red = 4,
        Onaylandi_AmbarKontrol = 5
    }

    public enum KullaniciIslemleri : byte
    {
        OneriEkle = 0,
        Kaydet = 1,
        Onayla = 2,
        Red = 3,
        Sil = 4,
        Iptal = 5,
        TeklifEkle = 6,
        FirmaTeklifiEkle = 7,
        TeklifTalepEslestir = 8,
        TalebinTeklifiSil = 9,
        TeklifiOnayla = 10,
        YkkEkle = 11,
        SozlesmeEkle = 12,
        BolmeIslemi = 13,
        OdenekAktrim = 14
    }


    public enum SatirDurumlari : byte
    {
        AmbaraGitti = 1,
        DepatmanaGitti = 2,
        AmbarKarsiladi = 3,
        SatinAlmada = 4,
        SatinAlmaBekliyor = 5
    }

    public enum AmbarDurumlari : byte
    {
        Bekleyenler = 1,
        Rezerve = 2,  //  (ambar fiþi ile rezerve ambarýna)
        Karsilandi = 3,       // (sarf fiþi ile sarf edilecek)
        Onaylandi = 4,
    }


    public enum Control : byte
    {
        UGrid = 0,
        ULabel = 1,
        UMText = 2,
        UText = 3,
        UVGrid = 4,
        ULabels = 5,
        UIcone = 6
    }

    public enum RepositoryType : byte
    {
        UGrid = 0,
        ULabel = 1,
        UMText = 2,
        UText = 3,
        UVGrid = 4
    }
 
}
