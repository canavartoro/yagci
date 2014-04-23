using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.Xpo;
using System.Drawing;
using System.Xml.Serialization;
using System.ComponentModel;

namespace YAGCI_SHIPPING.Data.Tables
{
    [Persistent(@"KULLANICI")]
    public class KULLANICI : XPObject
    {


        KULLANICIGRUP fGRUPID;
        [Association(@"KULLANICI.GRUPID_KULLANICIGRUP")]             
        public KULLANICIGRUP GRUPID
        {
            get { return fGRUPID; }
            set { SetPropertyValue<KULLANICIGRUP>("GRUPID", ref fGRUPID, value); }
        }

        int fGRUP;
        [NonPersistent]
        public int GRUP
        {
            get 
            {
                try
                {
                    if (!IsLoading)
                        return fGRUPID != null ? fGRUPID.Oid : 0;
                }
                catch (ObjectDisposedException) { }
                catch (Exception) { }
                return fGRUP; 
            }
            set 
            { 
                SetPropertyValue<int>("GRUP", ref fGRUP, value);
                if (!IsSaving && !IsLoading)
                {
                    SetPropertyValue<KULLANICIGRUP>("GRUPID", ref fGRUPID, Session.GetObjectByKey<KULLANICIGRUP>(value));
                }
            }
        }

        int fKeyID;
        public int KeyID
        {
            get { return fKeyID; }
            set { SetPropertyValue<int>("KeyID", ref fKeyID, value); }
        }
        int fParentID;
        public int ParentID
        {
            get { return fParentID; }
            set { SetPropertyValue<int>("ParentID", ref fParentID, value); }
        }
        int fSIRKETREF;
        public int SIRKETREF
        {
            get { return fSIRKETREF; }
            set { SetPropertyValue<int>("SIRKETREF", ref fSIRKETREF, value); }
        }
        int fMUSTERI_GRUBU;
        public int MUSTERI_GRUBU
        {
            get { return fMUSTERI_GRUBU; }
            set { SetPropertyValue<int>("MUSTERI_GRUBU", ref fMUSTERI_GRUBU, value); }
        }
        string fFRMNO;
        [Size(50)]
        public string FRMNO
        {
            get { return fFRMNO; }
            set { SetPropertyValue<string>("FRMNO", ref fFRMNO, value); }
        }
        string fFIRMA;
        [Size(50)]
        public string FIRMA
        {
            get { return fFIRMA; }
            set { SetPropertyValue<string>("FIRMA", ref fFIRMA, value); }
        }
        DateTime fGIRIS_TARIHI;
        public DateTime GIRIS_TARIHI
        {
            get { return fGIRIS_TARIHI; }
            set { SetPropertyValue<DateTime>("GIRIS_TARIHI", ref fGIRIS_TARIHI, value); }
        }
        string fSICIL_NO;
        [Size(50)]
        public string SICIL_NO
        {
            get { return fSICIL_NO; }
            set { SetPropertyValue<string>("SICIL_NO", ref fSICIL_NO, value); }
        }
        string fCALISTIGI_FIRMA;
        [Size(50)]
        public string CALISTIGI_FIRMA
        {
            get { return fCALISTIGI_FIRMA; }
            set { SetPropertyValue<string>("CALISTIGI_FIRMA", ref fCALISTIGI_FIRMA, value); }
        }
        string fDEPARTMANI;
        [Size(50)]
        public string DEPARTMANI
        {
            get { return fDEPARTMANI; }
            set { SetPropertyValue<string>("DEPARTMANI", ref fDEPARTMANI, value); }
        }

        public bool ENTEGRASYON { get; set; }


        public DB.MOD KULTUR { get; set; }

        string fUNVANI;
        [Size(75)]
        public string UNVANI
        {
            get { return fUNVANI; }
            set { SetPropertyValue<string>("UNVANI", ref fUNVANI, value); }
        }
        int fKATEGORI;
        public int KATEGORI
        {
            get { return fKATEGORI; }
            set { SetPropertyValue<int>("KATEGORI", ref fKATEGORI, value); }
        }
        string fMAIL_ADRESI;
        [Size(50)]
        public string MAIL_ADRESI
        {
            get { return fMAIL_ADRESI; }
            set { SetPropertyValue<string>("MAIL_ADRESI", ref fMAIL_ADRESI, value); }
        }
        string fADI;
        [Size(50)]
        public string ADI
        {
            get { return fADI; }
            set { SetPropertyValue<string>("ADI", ref fADI, value); }
        }
        string fSOYADI;
        [Size(50)]
        public string SOYADI
        {
            get { return fSOYADI; }
            set { SetPropertyValue<string>("SOYADI", ref fSOYADI, value); }
        }
        string fPROGRAM_KULLANICISI;
        [Size(10)]
        public string PROGRAM_KULLANICISI
        {
            get { return fPROGRAM_KULLANICISI; }
            set { SetPropertyValue<string>("PROGRAM_KULLANICISI", ref fPROGRAM_KULLANICISI, value); }
        }
        string fMENU_KISITLAMASI;
        [Size(5)]
        public string MENU_KISITLAMASI
        {
            get { return fMENU_KISITLAMASI; }
            set { SetPropertyValue<string>("MENU_KISITLAMASI", ref fMENU_KISITLAMASI, value); }
        }
        string fMUSTERI_KISITLAMASI;
        [Size(5)]
        public string MUSTERI_KISITLAMASI
        {
            get { return fMUSTERI_KISITLAMASI; }
            set { SetPropertyValue<string>("MUSTERI_KISITLAMASI", ref fMUSTERI_KISITLAMASI, value); }
        }
        string fTC_KIKLIK_NO;
        [Size(50)]
        public string TC_KIKLIK_NO
        {
            get { return fTC_KIKLIK_NO; }
            set { SetPropertyValue<string>("TC_KIKLIK_NO", ref fTC_KIKLIK_NO, value); }
        }
        double fONAY_MAX_BUTCE;
        public double ONAY_MAX_BUTCE
        {
            get { return fONAY_MAX_BUTCE; }
            set { SetPropertyValue<double>("ONAY_MAX_BUTCE", ref fONAY_MAX_BUTCE, value); }
        }
        string fADRES;
        [Size(255)]
        public string ADRES
        {
            get { return fADRES; }
            set { SetPropertyValue<string>("ADRES", ref fADRES, value); }
        }
        string fPOSTA_KODU;
        [Size(50)]
        public string POSTA_KODU
        {
            get { return fPOSTA_KODU; }
            set { SetPropertyValue<string>("POSTA_KODU", ref fPOSTA_KODU, value); }
        }
        string fIL;
        [Size(50)]
        public string IL
        {
            get { return fIL; }
            set { SetPropertyValue<string>("IL", ref fIL, value); }
        }
        string fILCE;
        [Size(50)]
        public string ILCE
        {
            get { return fILCE; }
            set { SetPropertyValue<string>("ILCE", ref fILCE, value); }
        }
        string fCEP_TELEFONU;
        [Size(20)]
        public string CEP_TELEFONU
        {
            get { return fCEP_TELEFONU; }
            set { SetPropertyValue<string>("CEP_TELEFONU", ref fCEP_TELEFONU, value); }
        }
        string fEV_TELEFONU;
        [Size(20)]
        public string EV_TELEFONU
        {
            get { return fEV_TELEFONU; }
            set { SetPropertyValue<string>("EV_TELEFONU", ref fEV_TELEFONU, value); }
        }
        string fVERGI_NO;
        [Size(50)]
        public string VERGI_NO
        {
            get { return fVERGI_NO; }
            set { SetPropertyValue<string>("VERGI_NO", ref fVERGI_NO, value); }
        }
        string fSSK_NO;
        [Size(50)]
        public string SSK_NO
        {
            get { return fSSK_NO; }
            set { SetPropertyValue<string>("SSK_NO", ref fSSK_NO, value); }
        }
        string fNOTUM;
        [Size(50)]
        public string NOTUM
        {
            get { return fNOTUM; }
            set { SetPropertyValue<string>("NOTUM", ref fNOTUM, value); }
        }
        byte[] fRESIM;
        public byte[] RESIM
        {
            get { return fRESIM; }
            set { SetPropertyValue<byte[]>("RESIM", ref fRESIM, value); }
        }
        string fPWORD;
        [Size(50), PasswordPropertyText(true)]
        public string PWORD
        {
            get { return fPWORD; }
            set { SetPropertyValue<string>("PWORD", ref fPWORD, value); }
        }

        public bool KAPTAN { get; set; }

        DateTime fAYRILIS_TARIHI;
        public DateTime AYRILIS_TARIHI
        {
            get { return fAYRILIS_TARIHI; }
            set { SetPropertyValue<DateTime>("AYRILIS_TARIHI", ref fAYRILIS_TARIHI, value); }
        }

   

        public KULLANICI(Session session) : base(session) { }
        public KULLANICI() : base(Session.DefaultSession) { }
        public override void AfterConstruction() { base.AfterConstruction(); }
    }

    [Persistent(@"FORMLAR"),DeferredDeletion(false),OptimisticLocking(false)]
    public class FORMLAR : XPObject
    {     
        string fAD;
        [Size(36)]
        public string AD
        {
            get { return fAD; }
            set { SetPropertyValue<string>("AD", ref fAD, value); }
        }
        string fBASLIK;
        [Size(64)]
        public string BASLIK
        {
            get { return fBASLIK; }
            set { SetPropertyValue<string>("BASLIK", ref fBASLIK, value); }
        }
        string fNAMESPACE;
        [Size(64)]
        public string NAMESPACE
        {
            get { return fNAMESPACE; }
            set { SetPropertyValue<string>("NAMESPACE", ref fNAMESPACE, value); }
        }

        string fRESIM;
        [Size(64)]
        public string RESIM
        {
            get { return fRESIM; }
            set { SetPropertyValue<string>("RESIM", ref fRESIM, value); }
        }

        public int USTID { get; set; }

        public bool ISSUREC { get; set; }

        public byte SIRANO { get; set; }

        public byte GENERICID { get; set; }

        public bool LANDSCAPE { get; set; }

        [Association(@"FORMGENERIC.FORMLAR.FORM"), NoForeignKey]
        public XPCollection<FORMGENERIC> FORMGENERICS
        {
            get { return GetCollection<FORMGENERIC>(@"FORMGENERICS"); }
        }

        [Association(@"GENERIC.FORMLAR.FORM"), NoForeignKey]
        public XPCollection<GENERIC> GENERICS
        {
            get { return GetCollection<GENERIC>(@"GENERICS"); }
        }        

        [Association(@"KULLANICIGRUPDETAYLARI.FORMID_FORMLAR")]
        public XPCollection<KULLANICIGRUPDETAYLARI> KULLANICIGRUPDETAYLARIs
        {
            get { return GetCollection<KULLANICIGRUPDETAYLARI>(@"KULLANICIGRUPDETAYLARIs"); }
        }
        public FORMLAR(Session session) : base(session) { }
        public FORMLAR() : base(Session.DefaultSession) { }
        public override void AfterConstruction() { base.AfterConstruction(); }
    }

    [Persistent(@"KULLANICIGRUPDETAYLARI"),DeferredDeletion(false),OptimisticLocking(false)]
    public class KULLANICIGRUPDETAYLARI : XPObject
    {

        KULLANICIGRUP fGRUPID;
        [Browsable(false)]
        [Association(@"KULLANICIGRUPDETAYLARI.GRUPID_KULLANICIGRUP")]
        public KULLANICIGRUP GRUPID
        {
            get { return fGRUPID; }
            set { SetPropertyValue<KULLANICIGRUP>("GRUPID", ref fGRUPID, value); }
        }
        FORMLAR fFORMID;
        [Browsable(false)]
        [Association(@"KULLANICIGRUPDETAYLARI.FORMID_FORMLAR")]
        public FORMLAR FORMID
        {
            get { return fFORMID; }
            set { SetPropertyValue<FORMLAR>("FORMID", ref fFORMID, value); }
        }

        [PersistentAlias("Iif(FORMID is null, '', FORMID.BASLIK)")]
        public string BASLIK
        {
            get
            {
                try
                {
                    if (!IsLoading)
                        return Convert.ToString(EvaluateAlias("BASLIK"));
                }
                catch (ObjectDisposedException) { }
                catch (Exception) { }
                return "";
            } 
        }

        int fFORM;
        [NonPersistent]
        public int FORM
        {
            get
            {
                try
                {
                    if (!IsLoading)
                        return fFORMID != null ? fFORMID.Oid : 0;
                }
                catch (ObjectDisposedException) { }
                catch (Exception) { }
                return fFORM;
            }
            set
            {
                SetPropertyValue<int>("FORM", ref fFORM, value);
                if (!IsSaving && !IsLoading)
                {
                    SetPropertyValue<FORMLAR>("FORMID", ref fFORMID, Session.GetObjectByKey<FORMLAR>(value));
                }
            }
        }

        bool fKAYDETME;
        public bool KAYDETME
        {
            get { return fKAYDETME; }
            set { SetPropertyValue<bool>("KAYDETME", ref fKAYDETME, value); }
        }
        bool fSILME;
        public bool SILME
        {
            get { return fSILME; }
            set { SetPropertyValue<bool>("SILME", ref fSILME, value); }
        }
        bool fGUNCELLEME;
        public bool GUNCELLEME
        {
            get { return fGUNCELLEME; }
            set { SetPropertyValue<bool>("GUNCELLEME", ref fGUNCELLEME, value); }
        }
        bool fIZLEME;
        public bool IZLEME
        {
            get { return fIZLEME; }
            set { SetPropertyValue<bool>("IZLEME", ref fIZLEME, value); }
        }
        public KULLANICIGRUPDETAYLARI(Session session) : base(session) { }
        public KULLANICIGRUPDETAYLARI() : base(Session.DefaultSession) { }
        public override void AfterConstruction() { base.AfterConstruction(); }
    }
 
    [Persistent(@"KULLANICIGRUP"),DeferredDeletion(false),OptimisticLocking(false)]
    public class KULLANICIGRUP : XPObject
    {

        string fGRUPAD;
        [Size(64)]
        public string GRUPAD
        {
            get { return fGRUPAD; }
            set { SetPropertyValue<string>("GRUPAD", ref fGRUPAD, value); }
        }
        [Association(@"KULLANICI.GRUPID_KULLANICIGRUP")]
        public XPCollection<KULLANICI> KULLANICIs
        {
            get { return GetCollection<KULLANICI>(@"KULLANICIs"); }
        }
        [Association(@"KULLANICIGRUPDETAYLARI.GRUPID_KULLANICIGRUP")]
        public XPCollection<KULLANICIGRUPDETAYLARI> KULLANICIGRUPDETAYLARIs
        {
            get { return GetCollection<KULLANICIGRUPDETAYLARI>(@"KULLANICIGRUPDETAYLARIs"); }
        }
     
        public KULLANICIGRUP(Session session) : base(session) { }
        public KULLANICIGRUP() : base(Session.DefaultSession) { }
        public override void AfterConstruction() { base.AfterConstruction(); }
    }
     
    [Persistent(@"FIRMALAR"),DeferredDeletion(false),OptimisticLocking(false)]
    public class FIRMALAR : XPObject
    {      
        string fFRMCODE;
        [Size(24)]
        public string FRMCODE
        {
            get { return fFRMCODE; }
            set { SetPropertyValue<string>("FRMCODE", ref fFRMCODE, value); }
        }
        string fFRMNAME;
        [Size(127)]
        public string FRMNAME
        {
            get { return fFRMNAME; }
            set { SetPropertyValue<string>("FRMNAME", ref fFRMNAME, value); }
        }
        string fVERGINO;
        [Size(50)]
        public string VERGINO
        {
            get { return fVERGINO; }
            set { SetPropertyValue<string>("VERGINO", ref fVERGINO, value); }
        }
        string fVERGIDAIRESI;
        [Size(50)]
        public string VERGIDAIRESI
        {
            get { return fVERGIDAIRESI; }
            set { SetPropertyValue<string>("VERGIDAIRESI", ref fVERGIDAIRESI, value); }
        }
        string fPOSTAKODU;
        [Size(50)]
        public string POSTAKODU
        {
            get { return fPOSTAKODU; }
            set { SetPropertyValue<string>("POSTAKODU", ref fPOSTAKODU, value); }
        }
        string fADRES;
        [Size(255)]
        public string ADRES
        {
            get { return fADRES; }
            set { SetPropertyValue<string>("ADRES", ref fADRES, value); }
        }
        string fIL;
        [Size(50)]
        public string IL
        {
            get { return fIL; }
            set { SetPropertyValue<string>("IL", ref fIL, value); }
        }
        string fILCE;
        [Size(50)]
        public string ILCE
        {
            get { return fILCE; }
            set { SetPropertyValue<string>("ILCE", ref fILCE, value); }
        }
        string fTELEFON;
        [Size(50)]
        public string TELEFON
        {
            get { return fTELEFON; }
            set { SetPropertyValue<string>("TELEFON", ref fTELEFON, value); }
        }
        string fFAX;
        [Size(50)]
        public string FAX
        {
            get { return fFAX; }
            set { SetPropertyValue<string>("FAX", ref fFAX, value); }
        }
        string fMAIL;
        [Size(127)]
        public string MAIL
        {
            get { return fMAIL; }
            set { SetPropertyValue<string>("MAIL", ref fMAIL, value); }
        }
        string fILGILI;
        [Size(50)]
        public string ILGILI
        {
            get { return fILGILI; }
            set { SetPropertyValue<string>("ILGILI", ref fILGILI, value); }
        }
        string fNOTLAR;
        [Size(255)]
        public string NOTLAR
        {
            get { return fNOTLAR; }
            set { SetPropertyValue<string>("NOTLAR", ref fNOTLAR, value); }
        }
        public FIRMALAR(Session session) : base(session) { }
        public FIRMALAR() : base(Session.DefaultSession) { }
        public override void AfterConstruction() { base.AfterConstruction(); }
    }
   
    [Persistent(@"TANIMLAR")]
    public class TANIMLAR : XPObject
    {
        [Size(16)]
        public string TIP { get; set; }

        [Size(32)]
        public string KOD { get; set; }

        [Size(64)]
        public string AD { get; set; }

        [NonPersistent]
        public bool Sec { get; set; }


        public TANIMLAR(Session session) : base(session) { }
        public TANIMLAR() : base(Session.DefaultSession) { }
        public override void AfterConstruction() { base.AfterConstruction(); }

    }

    [Persistent(@"GENERIC")]
    public class GENERIC : XPObject
    {
        public DB.Control CONTROLYYPE { get; set; }
        public Formlar.FormOzellikler.Sekiller REPOTYPE { get; set; }
        public System.Windows.Forms.DockStyle DOCK { get; set; }

        public int XPOS { get; set; }
        public int YPOS { get; set; }
        public int HSIZE { get; set; }
        public int WSIZE { get; set; }
        public int COLCOUNT { get; set; }
        public int ROWCOUNT { get; set; }

        [Size(512)]
        public string REPOITEMS { get; set; }

        [Size(512)]
        public string COLUMNS { get; set; }

        [Size(64)]
        public string HEADER { get; set; }

        [Size(64)]
        public string FORMNAME { get; set; }

        [Size(64)]
        public string CAPTION { get; set; }

        [Size(1024)]
        public string TEXT { get; set; }

        public int ORDER { get; set; }

        [PersistentAlias("Iif(FORM is null, 0, FORM.Oid)")]
        public int FORMID
        {
            get
            {
                try
                {
                    if (!IsLoading)
                        return Convert.ToInt32(EvaluateAlias("FORMID"));
                    //if (!IsLoading && fFORMLAR != null)
                    //    return fFORMLAR.Oid;
                }
                catch (ObjectDisposedException) { }
                catch (Exception) { }
                return 0;
            }
            set
            {
                if (!IsLoading)
                {
                    SetPropertyValue<FORMLAR>("FORM", ref fFORMLAR, Session.GetObjectByKey<FORMLAR>(value));
                }
            }
        }

        [PersistentAlias("Iif(FORM is null, 0, FORM.USTID)")]
        public int USTFORMID
        {
            get
            {
                try
                {
                    if (!IsLoading)
                        return Convert.ToInt32(EvaluateAlias("USTFORMID"));
                    //if (!IsLoading && fFORMLAR != null)
                    //    return fFORMLAR.Oid;
                }
                catch (ObjectDisposedException) { }
                catch (Exception) { }
                return 0;
            }
            set
            {
            }
        }

        FORMLAR fFORMLAR;
        [XmlIgnore(), Association(@"GENERIC.FORMLAR.FORM"), NoForeignKey, Persistent("FORMID")]
        public FORMLAR FORM
        {
            get { return fFORMLAR; }
            set { SetPropertyValue<FORMLAR>("FORM", ref fFORMLAR, value); }
        }

        public int HSIZE1 { get; set; }
        public int WSIZE1 { get; set; }

        [Size(32)]
        public string NAME { get; set; }

        [Size(512)]
        public string SIZES { get; set; }

        public bool LANDSCAPE { get; set; }

        public byte[] ICONEFILE { get; set; }

        public GENERIC(Session session) : base(session) { }
        public GENERIC() : base(Session.DefaultSession) { }
        public override void AfterConstruction() { base.AfterConstruction(); }
    }


    [Persistent(@"test")]
    public class test : XPObject
    {
        public string cc { get; set; }
        public DateTime dtt { get; set; }

        public test(Session session) : base(session) { }
        public test() : base(Session.DefaultSession) { }
        public override void AfterConstruction() { base.AfterConstruction(); }
    }

    [Persistent(@"REVIZYON")]
    public class REVIZYON : XPObject
    {
        public string CODE { get; set; }
        [Size(255)]
        public string NAME { get; set; }

        public DateTime DT { get; set; }

        public DateTime Rev1 { get; set; }
        public DateTime Rev2 { get; set; }
        public DateTime Rev3 { get; set; }
        public DateTime Rev4 { get; set; }
        public DateTime Rev5 { get; set; }
        public DateTime Rev6 { get; set; }
        public DateTime Rev7 { get; set; }
        public DateTime Rev8 { get; set; }
        public DateTime Rev9 { get; set; }
        public DateTime Rev10 { get; set; }
        public DateTime Rev11 { get; set; }
        public DateTime Rev12 { get; set; }
        [Size(255)]
        public string NAMESPACE { get; set; }

        public REVIZYON(Session session) : base(session) { }
        public REVIZYON() : base(Session.DefaultSession) { }
        public override void AfterConstruction() { base.AfterConstruction(); }
    }
}
