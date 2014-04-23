using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.IO;
using System.Linq;
using DevExpress.Data.Filtering;
using DevExpress.Xpo;

namespace YAGCI_SHIPPING.Formlar
{
    public partial class FaturaSorgula : DevExpress.XtraEditors.XtraForm
    {
        public FaturaSorgula()
        {
            InitializeComponent();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            try
            {
                #region Kayitlari gonder
                using (UnitOfWork work = new UnitOfWork())
                {
                    work.BeginTransaction();

                    XPQuery<Data.Tables.FORMGENERIC> datalar = new XPQuery<Data.Tables.FORMGENERIC>(work);
                    List<Data.Tables.FORMGENERIC> dataList = (from x in datalar
                                                              where x.AKTARILDI == false
                                                              orderby x.FORMNAME
                                                              select x).ToList();
                    serv.FORMGENERIC[] dataArr = new serv.FORMGENERIC[dataList.Count];
                    for (int i = 0; i < dataList.Count - 1; i++)
                    {
                        dataArr[i] = new serv.FORMGENERIC();
                        dataArr[i].FORMNAME = dataList[i].FORMNAME;
                        dataArr[i].KULLANICIID = dataList[i].KULLANICIID;
                        dataArr[i].TARIH = dataList[i].TARIH;
                        dataArr[i].Values = dataList[i].Values;
                        dataArr[i].FIRMAID = dataList[i].FIRMAID;
                        dataArr[i].XFormId = dataList[i].FORMID;

                        dataList[i].AKTARILDI = true;
                        dataList[i].Save();

                    }
                    YAGCI_SHIPPING.serv.ServisResult rest = Kls.Gnl.Servis.KayitlariAl(dataArr);
                    if (rest != null && rest.Durum == false)
                    {
                        Kls.Dlg.Hata(string.Format("Sunucu hatas,:{0}", rest.Sonuc));
                    }

                    work.CommitTransaction();
                }
                #endregion

                #region Guncelleme
                serv.GENERIC[] frm = Kls.Gnl.Servis.FormlariAl();

                //DB.XP.Crs.ExecuteNonQuery(" TRUNCATE TABLE GENERIC ");

                foreach (serv.GENERIC x in frm)
                {
                    Data.Tables.GENERIC fg = DB.XP.Crs.FindObject<YAGCI_SHIPPING.Data.Tables.GENERIC>(CriteriaOperator.Parse(" FORMNAME = ? AND CONTROLYYPE = ? AND TEXT = ? ", x.FORMNAME, x.CONTROLYYPE, x.TEXT));
                    if (fg == null)
                    {
                        fg = new YAGCI_SHIPPING.Data.Tables.GENERIC(DB.XP.Crs);
                    }
                    fg.CAPTION = x.CAPTION;
                    fg.COLCOUNT = x.COLCOUNT;
                    fg.CONTROLYYPE = (DB.Control)Enum.Parse(typeof(DB.Control), x.CONTROLYYPE.ToString());
                    fg.DOCK = (DockStyle)Enum.Parse(typeof(DockStyle), x.DOCK.ToString());
                    fg.FORM = DB.XP.Crs.FindObject<Data.Tables.FORMLAR>(CriteriaOperator.Parse(" BASLIK = ?", x.FORMNAME));
                    fg.FORMNAME = x.FORMNAME;
                    fg.HEADER = x.HEADER;
                    fg.HSIZE = x.HSIZE;
                    fg.HSIZE1 = x.HSIZE1;

                    fg.COLUMNS = x.COLUMNS;

                    fg.ICONEFILE = x.ICONEFILE;
                    fg.LANDSCAPE = x.LANDSCAPE;
                    fg.NAME = x.NAME;
                    fg.ORDER = x.ORDER;
                    fg.REPOITEMS = x.REPOITEMS;
                    fg.REPOTYPE = (Formlar.FormOzellikler.Sekiller)Enum.Parse(typeof(Formlar.FormOzellikler.Sekiller), x.REPOTYPE.ToString());
                    fg.ROWCOUNT = x.ROWCOUNT;
                    fg.SIZES = x.SIZES;
                    fg.TEXT = x.TEXT;

                    fg.WSIZE = x.WSIZE;
                    fg.WSIZE1 = x.WSIZE1;
                    fg.XPOS = x.XPOS;
                    fg.YPOS = x.YPOS;
                    fg.Save();
                }


                foreach (var fname in frm.GroupBy(x => x.FORMNAME))
                {
                    Data.Tables.FORMLAR xFrm = DB.XP.Crs.FindObject<Data.Tables.FORMLAR>(CriteriaOperator.Parse(" BASLIK = ?", frm.Where(c => c.FORMNAME == fname.Key.ToString()).First().FORMNAME));
                    if (xFrm == null)
                    {
                        xFrm = new Data.Tables.FORMLAR(DB.XP.Crs);
                        xFrm.BASLIK = frm.Where(c => c.FORMNAME == fname.Key.ToString()).First().FORMNAME;
                        xFrm.AD = frm.Where(c => c.FORMNAME == fname.Key.ToString()).First().FORMNAME;
                        xFrm.NAMESPACE = "YAGCI_SHIPPING.Formlar.FormGENERIC";
                        xFrm.RESIM = "_1377905062_stock_task";
                        xFrm.USTID = frm.Where(c => c.FORMNAME == fname.Key.ToString()).First().USTFORMID;
                        //xFrm.GENERICID = (byte)fg.Oid;

                        Data.Tables.KULLANICIGRUPDETAYLARI kulgd = new Data.Tables.KULLANICIGRUPDETAYLARI(DB.XP.Crs);
                        kulgd.GRUPID = DB.XP.Crs.GetObjectByKey<Data.Tables.KULLANICIGRUP>(1);
                        kulgd.Save();

                        xFrm.KULLANICIGRUPDETAYLARIs.Add(kulgd);
                        xFrm.Save();

                        var snc = new XPCollection<Data.Tables.GENERIC>(DB.XP.Crs, CriteriaOperator.Parse(" FORMNAME = (?) ", xFrm.AD));
                        foreach (Data.Tables.GENERIC g in snc)
                        {
                            g.FORMID = xFrm.Oid;
                            g.Save();
                        }
                    }                                                                                
                } 
                #endregion

                Kls.Dlg.Bilgi("İşlem Tamamlandı");

            }
            catch (Exception ee)
            {
                Kls.Dlg.Hata(ee);
            }

        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            timer1.Enabled = false;

            progressBarControl1.Increment(5);


            if (progressBarControl1.Position == 100)
            {
                timer1.Enabled = false;
                progressBarControl1.Position = 0;

                Random rr = new Random();
                labelControl8.Text = rr.Next(8) + " Adet Kayıt İndirildi..";


                //Kls.Response rs = Kls.Gnl.Wrk.EfaturaIslemleri(Kls.ISLEMLER.Login);

                //Kls.Dlg.Hata("Sonuç : " + rs.Sonuc.ToString() + "\nMesaj : " + rs.Mesaj + "\nSESSIONID : " + rs.SESSIONID);

                return;
            }

            timer1.Enabled = true;

        }

        private void FaturaSorgula_Load(object sender, EventArgs e)
        {
            dtBas.DateTime = DateTime.Now;
            txtUUID.Text = YAGCI_SHIPPING.Properties.Settings.Default.YAGCI_SHIPPING_serv_serv;
        }


    }
}