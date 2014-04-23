using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.Xpo;
using System.Xml.Serialization;

namespace YAGCI_SHIPPING.Data.Tables
{
    [Persistent(@"SURECHAREKET")]
    public class SURECHAREKET : XPObject
    {
             
        public Nullable<int> PRJID { get; set; }
             
        public Nullable<int> ITEMID { get; set; }

        decimal fMIKTAR;
        public decimal MIKTAR
        {
            get { return fMIKTAR; }
            set { SetPropertyValue<decimal>("MIKTAR", ref fMIKTAR, value); }
        }

        [DbType("datetime NOT ")]
        public Nullable<DateTime> TARIH
        {
            get;
            set;
        }

        [DbType("int NOT ")]
        public Nullable<int> KULID
        {
            get;
            set;
        }

        int fONAYLAYACAK;
        public int ONAYLAYACAK
        {
            get { return fONAYLAYACAK; }
            set { SetPropertyValue<int>("ONAYLAYACAK", ref fONAYLAYACAK, value); }
        }
        int fPERSID;
        public int PERSID
        {
            get { return fPERSID; }
            set { SetPropertyValue<int>("PERSID", ref fPERSID, value); }
        }


        bool fYONETIMKARARI;
        public bool YONETIMKARARI
        {
            get { return fYONETIMKARARI; }
            set { SetPropertyValue<bool>("YONETIMKARARI", ref fYONETIMKARARI, value); }
        }

        bool fSOZLESME;
        public bool SOZLESME
        {
            get { return fSOZLESME; }
            set { SetPropertyValue<bool>("SOZLESME", ref fSOZLESME, value); }
        }

        bool fIHALE;
        public bool IHALE
        {
            get { return fIHALE; }
            set { SetPropertyValue<bool>("IHALE", ref fIHALE, value); }
        }

        [DbType("int NOT ")]
        public Nullable<int> SURECID
        {
            get;
            set;
        }
        
        [DbType("varchar(32) NOT ")]
        public string MODUL
        {
            get;
            set;
        }

        DB.KullaniciIslemleri fISLEM;
        public DB.KullaniciIslemleri ISLEM
        {
            get { return fISLEM; }
            set { SetPropertyValue<DB.KullaniciIslemleri>("ISLEM", ref fISLEM, value); }
        }


        int fTEKLIFID;
        public int TEKLIFID
        {
            get { return fTEKLIFID; }
            set { SetPropertyValue<int>("TEKLIFID", ref fTEKLIFID, value); }
        }


       
        public Nullable<short> CARDTYPE { get; set; }
      
        public Nullable<short> FIRMANO { get; set; }
       
        public Nullable<int> UNISETREF { get; set; }

        public SURECHAREKET(Session session) : base(session) { }
        public SURECHAREKET() : base(Session.DefaultSession) { }
        public override void AfterConstruction() { base.AfterConstruction(); }
    }

            

    public class FORM1 : XPObject
    {


        public string FORM_BASLIK { get; set; }
        public string FORM_NAME { get; set; }

        public int KULLANICI_ID { get; set; }

        public DateTime TARIH { get; set; }

        public string ALAN1 { get; set; }
        public string ALAN2 { get; set; }


        public string ALAN3 { get; set; }
        public string ALAN4 { get; set; }
        public string ALAN5 { get; set; }
        public string ALAN6 { get; set; }
        public string ALAN7 { get; set; }
        public string ALAN8 { get; set; }


        [Size(255)]
        public string ACIKLAMA { get; set; }
        
 

        public FORM1(Session session) : base(session) { }
        public FORM1() : base(Session.DefaultSession) { }
        public override void AfterConstruction() { base.AfterConstruction(); }
    }

    public class FORMHAREKET : XPObject
    {

        public string FORM_TURU { get; set; }
        public string FORM_BASLIK { get; set; }
        public string FORM_NAME { get; set; }

        public bool DOLDUMU { get; set; }


        public FORMHAREKET(Session session) : base(session) { }
        public FORMHAREKET() : base(Session.DefaultSession) { }
        public override void AfterConstruction() { base.AfterConstruction(); }
    }

    [DeferredDeletion(false),OptimisticLocking(false)]
    public class FORMGENERIC : XPObject
    {
        public string FORMNAME { get; set; }
        public int KULLANICIID { get; set; }
        public DateTime TARIH { get; set; }
       
        [Size(4096)]
        public string Values { get; set; }

        public int FIRMAID { get; set; }

        //public int FORMID { get; set; }

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
        [XmlIgnore(), Association(@"FORMGENERIC.FORMLAR.FORM"), NoForeignKey, Persistent("FORMID")]
        public FORMLAR FORM
        {
            get { return fFORMLAR; }
            set { SetPropertyValue<FORMLAR>("FORM", ref fFORMLAR, value); }
        }

        //[PersistentAlias("Iif(FORM is null, 0, FORM.Oid)")]
        [NonPersistent]
        public int FORMID
        {
            get
            {
                try
                {
                    //if (!IsLoading)
                    //    return Convert.ToInt32(EvaluateAlias("FORMID"));
                    if (!IsLoading && fFORMLAR != null)
                        return fFORMLAR.Oid;
                }
                catch (ObjectDisposedException) { }
                catch (Exception) { }
                return 0;
            }
            set
            {
            }
        }
 
        public FORMGENERIC(Session session) : base(session) { }
        public FORMGENERIC() : base(Session.DefaultSession) { }
        public override void AfterConstruction() { base.AfterConstruction(); }
    }
}