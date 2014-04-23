using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.Data.Filtering;
using DevExpress.Xpo;

namespace YAGCI_SHIPPING.Data.Sp_
{



    [NonPersistent]
    public class Sp_DepoKalanFiili : PersistentBase
    {
        decimal fSONUC;
        public decimal SONUC
        {
            get { return fSONUC; }
            set { SetPropertyValue<decimal>("SONUC", ref fSONUC, value); }
        }
        public Sp_DepoKalanFiili(Session session) : base(session) { }
        public Sp_DepoKalanFiili() : base(Session.DefaultSession) { }
        public override void AfterConstruction() { base.AfterConstruction(); }
    }

    [NonPersistent]
    public class Sp_DepoKalanSevkEdilebilir : PersistentBase
    {
        decimal fSONUC;
        public decimal SONUC
        {
            get { return fSONUC; }
            set { SetPropertyValue<decimal>("SONUC", ref fSONUC, value); }
        }
        public Sp_DepoKalanSevkEdilebilir(Session session) : base(session) { }
        public Sp_DepoKalanSevkEdilebilir() : base(Session.DefaultSession) { }
        public override void AfterConstruction() { base.AfterConstruction(); }
    }

    [NonPersistent]
    public class Sp_DepoKalanSevkEdilebilirEksiAsgari : PersistentBase
    {
        decimal fSONUC;
        public decimal SONUC
        {
            get { return fSONUC; }
            set { SetPropertyValue<decimal>("SONUC", ref fSONUC, value); }
        }
        public Sp_DepoKalanSevkEdilebilirEksiAsgari(Session session) : base(session) { }
        public Sp_DepoKalanSevkEdilebilirEksiAsgari() : base(Session.DefaultSession) { }
        public override void AfterConstruction() { base.AfterConstruction(); }
    }

    [NonPersistent]
    public class Sp_DepoKalanAsgari : PersistentBase
    {
        decimal fSONUC;
        public decimal SONUC
        {
            get { return fSONUC; }
            set { SetPropertyValue<decimal>("SONUC", ref fSONUC, value); }
        }
        public Sp_DepoKalanAsgari(Session session) : base(session) { }
        public Sp_DepoKalanAsgari() : base(Session.DefaultSession) { }
        public override void AfterConstruction() { base.AfterConstruction(); }
    }


    [NonPersistent]
    public class Sp_NoAl : PersistentBase
    {
        string fColumn0;
        public string Column0
        {
            get { return fColumn0; }
            set { SetPropertyValue<string>("Column0", ref fColumn0, value); }
        }
        public Sp_NoAl(Session session) : base(session) { }
        public Sp_NoAl() : base(Session.DefaultSession) { }
        public override void AfterConstruction() { base.AfterConstruction(); }
    }

    [NonPersistent]
    public class Sp_SonKurAl : PersistentBase
    {
        decimal fKUR;
        public decimal KUR
        {
            get { return fKUR; }
            set { SetPropertyValue<decimal>("KUR", ref fKUR, value); }
        }
        public Sp_SonKurAl(Session session) : base(session) { }
        public Sp_SonKurAl() : base(Session.DefaultSession) { }
        public override void AfterConstruction() { base.AfterConstruction(); }
    }
    

    public static class SPS
    {

        public static DevExpress.Xpo.DB.SelectedData ExecSp_DepoKalanFiili(Session session, int STOCKREF, string FIRMA, string DONEM, int INV)
        {
            return session.ExecuteSproc("Sp_DepoKalanFiili", new OperandValue(STOCKREF), new OperandValue(FIRMA), new OperandValue(DONEM), new OperandValue(INV));
        }

        public static System.Collections.Generic.ICollection<Sp_DepoKalanFiili> ExecSp_DepoKalanFiiliIntoObjects(Session session, int STOCKREF, string FIRMA, string DONEM, int INV)
        {
            return session.GetObjectsFromSproc<Sp_DepoKalanFiili>("Sp_DepoKalanFiili", new OperandValue(STOCKREF), new OperandValue(FIRMA), new OperandValue(DONEM), new OperandValue(INV));
        }

        public static XPDataView ExecSp_DepoKalanFiiliIntoDataView(Session session, int STOCKREF, string FIRMA, string DONEM, int INV)
        {
            DevExpress.Xpo.DB.SelectedData sprocData = session.ExecuteSproc("Sp_DepoKalanFiili", new OperandValue(STOCKREF), new OperandValue(FIRMA), new OperandValue(DONEM), new OperandValue(INV));
            return new XPDataView(session.Dictionary, session.GetClassInfo(typeof(Sp_DepoKalanFiili)), sprocData);
        }
        public static void ExecSp_DepoKalanFiiliIntoDataView(XPDataView dataView, Session session, int STOCKREF, string FIRMA, string DONEM, int INV)
        {
            DevExpress.Xpo.DB.SelectedData sprocData = session.ExecuteSproc("Sp_DepoKalanFiili", new OperandValue(STOCKREF), new OperandValue(FIRMA), new OperandValue(DONEM), new OperandValue(INV));
            dataView.PopulateProperties(session.GetClassInfo(typeof(Sp_DepoKalanFiili)));
            dataView.LoadData(sprocData);
        }

        public static DevExpress.Xpo.DB.SelectedData ExecSp_DepoKalanSevkEdilebilir(Session session, int STOCKREF, string FIRMA, string DONEM, int INV)
        {
            return session.ExecuteSproc("Sp_DepoKalanSevkEdilebilir", new OperandValue(STOCKREF), new OperandValue(FIRMA), new OperandValue(DONEM), new OperandValue(INV));
        }

        public static System.Collections.Generic.ICollection<Sp_DepoKalanSevkEdilebilir> ExecSp_DepoKalanSevkEdilebilirIntoObjects(Session session, int STOCKREF, string FIRMA, string DONEM, int INV)
        {
            return session.GetObjectsFromSproc<Sp_DepoKalanSevkEdilebilir>("Sp_DepoKalanSevkEdilebilir", new OperandValue(STOCKREF), new OperandValue(FIRMA), new OperandValue(DONEM), new OperandValue(INV));
        }

        public static XPDataView ExecSp_DepoKalanSevkEdilebilirIntoDataView(Session session, int STOCKREF, string FIRMA, string DONEM, int INV)
        {
            DevExpress.Xpo.DB.SelectedData sprocData = session.ExecuteSproc("Sp_DepoKalanSevkEdilebilir", new OperandValue(STOCKREF), new OperandValue(FIRMA), new OperandValue(DONEM), new OperandValue(INV));
            return new XPDataView(session.Dictionary, session.GetClassInfo(typeof(Sp_DepoKalanSevkEdilebilir)), sprocData);
        }
        public static void ExecSp_DepoKalanSevkEdilebilirIntoDataView(XPDataView dataView, Session session, int STOCKREF, string FIRMA, string DONEM, int INV)
        {
            DevExpress.Xpo.DB.SelectedData sprocData = session.ExecuteSproc("Sp_DepoKalanSevkEdilebilir", new OperandValue(STOCKREF), new OperandValue(FIRMA), new OperandValue(DONEM), new OperandValue(INV));
            dataView.PopulateProperties(session.GetClassInfo(typeof(Sp_DepoKalanSevkEdilebilir)));
            dataView.LoadData(sprocData);
        }

        public static DevExpress.Xpo.DB.SelectedData ExecSp_DepoKalanSevkEdilebilirEksiAsgari(Session session, int STOCKREF, string FIRMA, string DONEM, int INV)
        {
            return session.ExecuteSproc("Sp_DepoKalanSevkEdilebilirEksiAsgari", new OperandValue(STOCKREF), new OperandValue(FIRMA), new OperandValue(DONEM), new OperandValue(INV));
        }

        public static System.Collections.Generic.ICollection<Sp_DepoKalanSevkEdilebilirEksiAsgari> ExecSp_DepoKalanSevkEdilebilirEksiAsgariIntoObjects(Session session, int STOCKREF, string FIRMA, string DONEM, int INV)
        {
            return session.GetObjectsFromSproc<Sp_DepoKalanSevkEdilebilirEksiAsgari>("Sp_DepoKalanSevkEdilebilirEksiAsgari", new OperandValue(STOCKREF), new OperandValue(FIRMA), new OperandValue(DONEM), new OperandValue(INV));
        }

        public static XPDataView ExecSp_DepoKalanSevkEdilebilirEksiAsgariIntoDataView(Session session, int STOCKREF, string FIRMA, string DONEM, int INV)
        {
            DevExpress.Xpo.DB.SelectedData sprocData = session.ExecuteSproc("Sp_DepoKalanSevkEdilebilirEksiAsgari", new OperandValue(STOCKREF), new OperandValue(FIRMA), new OperandValue(DONEM), new OperandValue(INV));
            return new XPDataView(session.Dictionary, session.GetClassInfo(typeof(Sp_DepoKalanSevkEdilebilirEksiAsgari)), sprocData);
        }
        public static void ExecSp_DepoKalanSevkEdilebilirEksiAsgariIntoDataView(XPDataView dataView, Session session, int STOCKREF, string FIRMA, string DONEM, int INV)
        {
            DevExpress.Xpo.DB.SelectedData sprocData = session.ExecuteSproc("Sp_DepoKalanSevkEdilebilirEksiAsgari", new OperandValue(STOCKREF), new OperandValue(FIRMA), new OperandValue(DONEM), new OperandValue(INV));
            dataView.PopulateProperties(session.GetClassInfo(typeof(Sp_DepoKalanSevkEdilebilirEksiAsgari)));
            dataView.LoadData(sprocData);
        }

        public static DevExpress.Xpo.DB.SelectedData ExecSp_DepoKalanAsgari(Session session, int STOCKREF, string FIRMA, string DONEM, int INV)
        {
            return session.ExecuteSproc("Sp_DepoKalanAsgari", new OperandValue(STOCKREF), new OperandValue(FIRMA), new OperandValue(DONEM), new OperandValue(INV));
        }

        public static System.Collections.Generic.ICollection<Sp_DepoKalanAsgari> ExecSp_DepoKalanAsgariIntoObjects(Session session, int STOCKREF, string FIRMA, string DONEM, int INV)
        {
            return session.GetObjectsFromSproc<Sp_DepoKalanAsgari>("Sp_DepoKalanAsgari", new OperandValue(STOCKREF), new OperandValue(FIRMA), new OperandValue(DONEM), new OperandValue(INV));
        }

        public static XPDataView ExecSp_DepoKalanAsgariIntoDataView(Session session, int STOCKREF, string FIRMA, string DONEM, int INV)
        {
            DevExpress.Xpo.DB.SelectedData sprocData = session.ExecuteSproc("Sp_DepoKalanAsgari", new OperandValue(STOCKREF), new OperandValue(FIRMA), new OperandValue(DONEM), new OperandValue(INV));
            return new XPDataView(session.Dictionary, session.GetClassInfo(typeof(Sp_DepoKalanAsgari)), sprocData);
        }
        public static void ExecSp_DepoKalanAsgariIntoDataView(XPDataView dataView, Session session, int STOCKREF, string FIRMA, string DONEM, int INV)
        {
            DevExpress.Xpo.DB.SelectedData sprocData = session.ExecuteSproc("Sp_DepoKalanAsgari", new OperandValue(STOCKREF), new OperandValue(FIRMA), new OperandValue(DONEM), new OperandValue(INV));
            dataView.PopulateProperties(session.GetClassInfo(typeof(Sp_DepoKalanAsgari)));
            dataView.LoadData(sprocData);
        }

        public static DevExpress.Xpo.DB.SelectedData ExecSp_NoAl(Session session, string KOD, int Lenth)
        {
            return session.ExecuteSproc("Sp_NoAl", new OperandValue(KOD), new OperandValue(Lenth));
        }

        public static System.Collections.Generic.ICollection<Sp_NoAl> ExecSp_NoAlIntoObjects(Session session, string KOD, int Lenth)
        {
            return session.GetObjectsFromSproc<Sp_NoAl>("Sp_NoAl", new OperandValue(KOD), new OperandValue(Lenth));
        }

        public static XPDataView ExecSp_NoAlIntoDataView(Session session, string KOD, int Lenth)
        {
            DevExpress.Xpo.DB.SelectedData sprocData = session.ExecuteSproc("Sp_NoAl", new OperandValue(KOD), new OperandValue(Lenth));
            return new XPDataView(session.Dictionary, session.GetClassInfo(typeof(Sp_NoAl)), sprocData);
        }
        public static void ExecSp_NoAlIntoDataView(XPDataView dataView, Session session, string KOD, int Lenth)
        {
            DevExpress.Xpo.DB.SelectedData sprocData = session.ExecuteSproc("Sp_NoAl", new OperandValue(KOD), new OperandValue(Lenth));
            dataView.PopulateProperties(session.GetClassInfo(typeof(Sp_NoAl)));
            dataView.LoadData(sprocData);
        }

        public static DevExpress.Xpo.DB.SelectedData ExecSp_SonKurAl(Session session, short CARDTYPE)
        {
            return session.ExecuteSproc("Sp_SonKurAl", new OperandValue(CARDTYPE));
        }

        public static System.Collections.Generic.ICollection<Sp_SonKurAl> ExecSp_SonKurAlIntoObjects(Session session, short CARDTYPE)
        {
            return session.GetObjectsFromSproc<Sp_SonKurAl>("Sp_SonKurAl", new OperandValue(CARDTYPE));
        }

        public static XPDataView ExecSp_SonKurAlIntoDataView(Session session, short CARDTYPE)
        {
            DevExpress.Xpo.DB.SelectedData sprocData = session.ExecuteSproc("Sp_SonKurAl", new OperandValue(CARDTYPE));
            return new XPDataView(session.Dictionary, session.GetClassInfo(typeof(Sp_SonKurAl)), sprocData);
        }
        public static void ExecSp_SonKurAlIntoDataView(XPDataView dataView, Session session, short CARDTYPE)
        {
            DevExpress.Xpo.DB.SelectedData sprocData = session.ExecuteSproc("Sp_SonKurAl", new OperandValue(CARDTYPE));
            dataView.PopulateProperties(session.GetClassInfo(typeof(Sp_SonKurAl)));
            dataView.LoadData(sprocData);
        }
    }


}
