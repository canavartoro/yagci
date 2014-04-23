using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.Xpo;

namespace YAGCI_SHIPPING.Formlar
{
    public partial class FormGENELKART : Gui.BaseForm
    {
        public FormGENELKART()
        {
            InitializeComponent();
        }

       

        private void btnKaydet_Click(object sender, EventArgs e)
        {

            try
            {

                Data.Tables.FORM1 fr1 = textEdit1.Tag as Data.Tables.FORM1;


                if (fr1 != null && Properties.Settings.Default.ProgramMod < 1 && Kls.Gnl.AktifKullanici.KAPTAN==false)
                    throw new Exception(" Kayıt güncelleme yetkiniz bulunmuyor. ");


                if (fr1 == null)
                {
                    fr1 = new YAGCI_SHIPPING.Data.Tables.FORM1(DB.XP.Crs);

                    if (Kls.Dlg.Soru(" Form kayıdı eklenecek onaylıyormusnuz..?") != DialogResult.Yes)
                        return;
                }
                else
                {                    
                    fr1.Reload();

                    if (Kls.Dlg.Soru(" Form kayıdı güncellenecek onaylıyormusnuz..?") != DialogResult.Yes)
                        return;
                }


                 

                fr1.TARIH = (DateTime)row.Properties.Value;
                fr1.ALAN1 = row1.Properties.Value.ToString();
                fr1.ALAN2 = row2.Properties.Value.ToString();

                fr1.ALAN3 = editorRow1.Properties.Value.ToString();
                fr1.ALAN4 = editorRow2.Properties.Value.ToString();
                fr1.ALAN5 = editorRow3.Properties.Value.ToString();
                fr1.ALAN6 = row3.Properties.Value.ToString();
                fr1.ALAN7 = row11.Properties.Value.ToString();
                fr1.ALAN8 = row21.Properties.Value.ToString();

                fr1.FORM_BASLIK = textEdit1.Text;
                fr1.ACIKLAMA = memoEdit1.Text;
                fr1.FORM_NAME = this.Name;
                fr1.KULLANICI_ID = Kls.Gnl.AktifKullanici.Oid;
                fr1.Save();

            }
            catch (Exception ee)
            {
                Kls.Dlg.Hata(ee);
            }

            
        }

        private void brnArsiv_Click(object sender, EventArgs e)
        {
            var lns = new XPCollection<Data.Tables.FORM1>(DB.XP.Crs).ToArray();

            if (new Popup.Secim()
            {
                SetData = lns,
                VisibleColumns = new string[] { "TARIH", "FORM_BASLIK", "ACIKLAMA" }
            }.ShowDialog() != DialogResult.OK)
                return;

            Data.Tables.FORM1 fr1 = Kls.Gnl.SelectedRow as Data.Tables.FORM1;

            if (fr1 == null) return;

            row.Properties.Value=fr1.TARIH;
            row1.Properties.Value = fr1.ALAN1;
            row2.Properties.Value = fr1.ALAN2;

            editorRow1.Properties.Value = fr1.ALAN3;

            editorRow2.Properties.Value = fr1.ALAN4;
            editorRow3.Properties.Value = fr1.ALAN5;
            row3.Properties.Value = fr1.ALAN6;
            row11.Properties.Value = fr1.ALAN7;
            row21.Properties.Value = fr1.ALAN8;

            memoEdit1.Text = fr1.ACIKLAMA;

            textEdit1.Tag = fr1;

        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {

        }

        private void FormGENELKART_Load(object sender, EventArgs e)
        {
            row.Properties.Value = DateTime.Now;

            if (!Kls.Gnl.AktifKullanici.KAPTAN)
            {
                //row.Enabled = false;
                row1.Enabled = false;
                //row2.Enabled = false;
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {

            Data.Tables.FORM1 frm = textEdit1.Tag as Data.Tables.FORM1;

            if (frm == null)
            {
                MessageBox.Show("Form boş..");
                return;
            }

            //Formlar.FormPrintCrs fp = new FormPrintCrs();
            //frm.Reload();
            //frm.FORM_BASLIK = textEdit1.Text;
            //frm.Save();

            //fp.ID = frm.Oid;
            //fp.ShowDialog();
            
        }

        Bitmap memoryImage;

      

        
        [System.Runtime.InteropServices.DllImport("gdi32.dll")]
        public static extern long BitBlt(IntPtr hdcDest, int nXDest, int nYDest, int nWidth, int nHeight, IntPtr hdcSrc, int nXSrc, int nYSrc, int dwRop);
       
        private void CaptureScreen()
        {
            Graphics mygraphics = this.CreateGraphics();
            Size s = this.Size;
            memoryImage = new Bitmap(s.Width, s.Height-100, mygraphics);
            Graphics memoryGraphics = Graphics.FromImage(memoryImage);
            IntPtr dc1 = mygraphics.GetHdc();
            IntPtr dc2 = memoryGraphics.GetHdc();
            BitBlt(dc2, 0, 0, this.ClientRectangle.Width, this.ClientRectangle.Height, dc1, 0, 0, 13369376);
            mygraphics.ReleaseHdc(dc1);
            memoryGraphics.ReleaseHdc(dc2);
        }
        private void printDocument1_PrintPage(System.Object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(memoryImage, 0, 0);
            
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(((LinkLabel)sender).Text);
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(((LinkLabel)sender).Text);
        }
     

    
    }
}
