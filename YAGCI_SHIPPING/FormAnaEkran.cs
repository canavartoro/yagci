using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Collections;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.Xpo;
using DevExpress.Data.Filtering;
using YAGCI_SHIPPING.Kls;

namespace YAGCI_SHIPPING.Formlar
{
    public partial class FormAnaEkran : DevExpress.XtraEditors.XtraForm
    {
        public FormAnaEkran()
        {
            InitializeComponent();

            Kls.Gnl.TaskBar = brTaskBar;
        }

       
        private void MainMenu_Load(object sender, EventArgs e)
        {

            Lisans.LisansDogrula(Lisans.LisansKontrol());

           //string ss= new TRegister().ReadRegister("x0001DevexTema", "VS2010");

           defaultLookAndFeel1.LookAndFeel.SetSkinStyle(Kls.Gnl.IniData.Read("DevexTema", "VS2010"));


            DB.XP.Connect(Properties.Settings.Default.constr);

#if DEBUG
            Gnl.AktifKullanici = DB.XP.Crs.FindObject<Data.Tables.KULLANICI>(CriteriaOperator.Parse(" ADI = ? And PWORD = ?", "UMÝT", "1"));
            if (object.ReferenceEquals(Gnl.AktifKullanici, null))
                Kls.Dlg.Hata("Test kullanicisi tanimli degil!");

            Gnl.AktifFirma = DB.XP.Crs.GetObjectByKey<Data.Tables.FIRMALAR>(1);
            if (object.ReferenceEquals(Gnl.AktifFirma, null))
                Kls.Dlg.Hata("Test firmasi tanimli degil!");
                
#else
            if (new FormLogin().ShowDialog() != DialogResult.OK)
                System.Diagnostics.Process.GetCurrentProcess().Kill();
#endif

            barSubItemTema.Enabled =
                barSubItem2.Enabled =
                                      Properties.Settings.Default.ProgramMod > 0;
            

            //var snc1 = new XPCollection<Data.Tables.KULLANICI>(DB.XP.Crs).Where(x => x.ADI == "LOGO" && x.PWORD == "1");

            //if (snc1 == null || snc1.Count() < 1)
            //    throw new Exception("Bilgiler dogru deil , kontrol ediniz..!");

            // Gnl.AktifKullanici = snc1.ToList()[0];

            // Data.Views.vLOGO_FIRMALAR frm = new XPCollection<Data.Views.vLOGO_FIRMALAR>(CriteriaOperator.Parse("LOGICALREF", 1)).First();

            //if (frm == null)
            //    throw new Exception("Firma seçilmemiþ , kontrol ediniz..!");

            //Gnl.AktifFirma = frm;
 

            try
            {

                Formlar();

                this.Text = string.Format("{0} v{1} {2}", Gnl.AktifFirma.FRMNAME, Program.Versiyon, Lisans.LISANSLI ? "" : "(DEMO)");

                //this.WindowState = FormWindowState.Maximized;

                //lblHarcamaNoktasi.Text = "(" + Kls.Gnl.AktifFirma.NR.ToString().PadLeft(3, '0') + ")" + "- (" + Kls.Gnl.AktifFirma.DONEM.PadLeft(3, '0') + ")";
                lblKullanici.Text = Kls.Gnl.AktifKullanici.ADI;
                if (!Kls.Gnl.AktifKullanici.ENTEGRASYON)
                    barButtonItem25.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                if (Kls.Gnl.AktifKullanici.KULTUR == YAGCI_SHIPPING.DB.MOD.Client)
                {
                    barButtonItem30.Visibility =
                    barSubItem2.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                }

                this.WindowState = FormWindowState.Maximized;                
            }
            catch (Exception ex)
            {
                Kls.Dlg.Hata(ex);
            }                   
        }

        public void Formlar()
        {
            var snc =
               new XPCollection<Data.Tables.KULLANICIGRUPDETAYLARI>(DB.XP.Crs).Where(x => x.GRUPID.KULLANICIs.Where(y => y.Oid == Kls.Gnl.AktifKullanici.Oid).Count() > 0).ToArray();

            if (snc == null || snc.Count() < 1)
                throw new Exception("yetki bilgileri alinamadi.");

            Kls.Gnl.AktifKullaniciYetkileri = snc.ToArray();

            System.Resources.ResourceManager temp = new
                System.Resources.ResourceManager("YAGCI_SHIPPING.Properties.Resources", typeof(YAGCI_SHIPPING.Properties.Resources).Assembly);

            nvMenuler.Groups.Clear();

            foreach (var ust in snc.Where(x => x.FORMID.USTID == 0))
            {
                var nav = nvMenuler.Groups.Add(new DevExpress.XtraNavBar.NavBarGroup(ust.FORMID.BASLIK));
                nav.Expanded = false;                

                foreach (Data.Tables.KULLANICIGRUPDETAYLARI menu in Kls.Gnl.AktifKullaniciYetkileri.Where(x => x.FORMID.USTID == ust.FORMID.Oid).OrderBy(y => y.FORMID.SIRANO))
                {
                    if (Gnl.AktifKullanici.KULTUR == DB.MOD.Client && menu.FORMID.BASLIK.Equals("SIRKET FORMLARI"))
                        continue;
                    else
                    {
                        DevExpress.XtraNavBar.NavBarItem itm = new DevExpress.XtraNavBar.NavBarItem();
                        itm.Caption = menu.FORMID.BASLIK;
                        itm.Tag = menu;
                        nav.ItemLinks.Add(itm);
                        itm.SmallImage =
                        (System.Drawing.Bitmap)temp.GetObject(menu.FORMID.RESIM);
                    }
                }
            }
        }

        private void nvMenuler_LinkPressed(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {

            try
            {
                Data.Tables.KULLANICIGRUPDETAYLARI menu = e.Link.Item.Tag as Data.Tables.KULLANICIGRUPDETAYLARI;

                foreach (Form oFrm in this.MdiChildren)
                {
                    if (oFrm.Text == menu.FORMID.BASLIK)
                    {
                        if (oFrm.WindowState == FormWindowState.Minimized)
                            oFrm.WindowState = FormWindowState.Normal;

                        oFrm.Activate();
                        return;
                    }
                }               

                Gui.BaseForm frm = (Gui.BaseForm)Activator.CreateInstance(Type.GetType(menu.FORMID.NAMESPACE));
                frm.WindowState = FormWindowState.Maximized;
                frm.MdiParent = this;
                frm.Text = menu.FORMID.BASLIK;
                frm.SurecId = menu.FORMID.ISSUREC ? (byte)menu.FORMID.Oid : (byte)0;
                frm.ID = menu.FORMID.Oid;
                
                frm.Show();
            }
            catch (Exception ex)
            {
                Kls.Dlg.Hata(ex);              
            }            
        }

        

        private void barButtonItem6_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            Kls.Gnl.DefLookFeel1 = defaultLookAndFeel1;
            new Formlar.Ayarlar.Ayar() { MdiParent = this }.Show();
        }

        private void barButtonItem15_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //new Ayarlar.FormYkkListe() { }.ShowDialog();
        }

        private void barButtonItem16_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //new Ayarlar.FormIhaleUsulleri() {  }.ShowDialog();
        }

        private void barButtonItem18_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
           // new Ayarlar.FormOdenekListe() {  }.ShowDialog();
        }

        private void barButtonItem17_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //new Ayarlar.FormAlimListe() { }.ShowDialog();
        }

        private void barButtonItem19_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            new Formlar.FormKullanici() { MdiParent = this }.Show(); 
        }

        private void barButtonItem20_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            
        }

        private void barButtonItem21_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //new Sozlesme.FormSozlesmeParametreleri() { }.ShowDialog();
        }

        private void barButtonItem22_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //new Sozlesme.FormSozlesmeGiris() { MdiParent = this }.Show();
        }

        private void barButtonItem23_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
           // new Ayarlar.FormOdenekAktarim() { MdiParent = this }.Show();
        }

        private void barButtonItem24_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            new Formlar.FormYapilanlar() { MdiParent = this }.Show();
        }

        private void barButtonItem25_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            new Formlar.FaturaSorgula() { MdiParent = this }.Show();
        }

        private void barButtonItem26_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            
        }

        private void barButtonItem28_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                new Formlar.FormFirmalar() { MdiParent = this }.Show();
            }
            catch (Exception exc)
            {
                Kls.Dlg.Hata(exc);
            }
        }

        private void barButtonItem29_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            #region
            /*
            var lns = new XPCollection<Data.Tables.FORM1>(DB.XP.Crs).ToArray();

            if (new Popup.Secim()
            {
                SetData = lns,
                VisibleColumns = new string[] { "TARIH", "FORM_BASLIK", "ACIKLAMA" }
            }.ShowDialog() != DialogResult.OK)
                return;

            Data.Tables.FORM1 fr1 = Kls.Gnl.SelectedRow as Data.Tables.FORM1;

            if (fr1 == null) return;

            FormGENELKART gk = new FormGENELKART();
            gk.MdiParent = this;

            gk.row.Properties.Value = fr1.TARIH;
            gk.row1.Properties.Value = fr1.ALAN1;
            gk.row2.Properties.Value = fr1.ALAN2;

            gk.editorRow1.Properties.Value = fr1.ALAN3;
            gk.editorRow2.Properties.Value = fr1.ALAN4;
            gk.editorRow3.Properties.Value = fr1.ALAN5;
            gk.row3.Properties.Value = fr1.ALAN6;
            gk.row11.Properties.Value = fr1.ALAN7;
            gk.row21.Properties.Value = fr1.ALAN8;

            gk.memoEdit1.Text = fr1.ACIKLAMA;
            gk.textEdit1.Tag = fr1;
            gk.Show();
            */
            #endregion

            try
            {
                new Formlar.FormArsiv() { MdiParent = this }.Show();
            }
            catch (Exception exc)
            {
                Kls.Dlg.Hata(exc);
            }
        }

        private void formuDüzenleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void barButtonItem30_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            new FormDesing() { MdiParent = this, FrmAnaEkran = this }.Show();
        }


        public void Refresh12()
        {
            try
            {

                nvMenuler.Groups.Clear();

                var snc =
                   new XPCollection<Data.Tables.KULLANICIGRUPDETAYLARI>(DB.XP.Crs).Where(x => x.GRUPID.KULLANICIs.Where(y => y.Oid == Kls.Gnl.AktifKullanici.Oid).Count() > 0).ToArray();

                if (snc == null || snc.Count() < 1)
                    throw new Exception("yetki bilgileri alinamadi.");

                Kls.Gnl.AktifKullaniciYetkileri = snc.ToArray();

                System.Resources.ResourceManager temp = new
                    System.Resources.ResourceManager("YAGCI_SHIPPING.Properties.Resources", typeof(YAGCI_SHIPPING.Properties.Resources).Assembly);

                foreach (var ust in snc.Where(x => x.FORMID.USTID == 0))
                {
                    var nav = nvMenuler.Groups.Add(new DevExpress.XtraNavBar.NavBarGroup(ust.FORMID.BASLIK));
                    nav.Expanded = false;

                    foreach (Data.Tables.KULLANICIGRUPDETAYLARI menu in Kls.Gnl.AktifKullaniciYetkileri.Where(x => x.FORMID.USTID == ust.FORMID.Oid).OrderBy(y => y.FORMID.SIRANO))
                    {
                        DevExpress.XtraNavBar.NavBarItem itm = new DevExpress.XtraNavBar.NavBarItem();
                        itm.Caption = menu.FORMID.BASLIK;
                        itm.Tag = menu;
                        nav.ItemLinks.Add(itm);
                        itm.SmallImage =
                        (System.Drawing.Bitmap)temp.GetObject(menu.FORMID.RESIM);

                    }
                }                
            }
            catch (Exception ex)
            {
                Kls.Dlg.Hata(ex);
            }
        }

        private void barButtonItem26_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            xpCollection1.Session = DB.XP.Crs;
            xpCollection1.Add(new Data.Tables.test(DB.XP.Crs));
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {

        }

        private void barButtonItem27_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                new Formlar.FormGRUPLAR() { MdiParent = this }.Show();
            }
            catch (Exception exc)
            {
                Kls.Dlg.Hata(exc);
            }
        }

        private void barButtonItem31_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            using (FormLisans lis = new FormLisans())
            {
                lis.ShowDialog();
            }
        }

       
       
       

  

    

    }
}