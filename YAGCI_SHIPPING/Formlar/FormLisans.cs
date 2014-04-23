using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using YAGCI_SHIPPING.Kls;

namespace YAGCI_SHIPPING.Formlar
{
    public partial class FormLisans : Form
    {
        public FormLisans()
        {
            InitializeComponent();
        }

        private void butCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("mailto:canavar.toro@gmail.com");
        }

        private void FormLisans_Load(object sender, EventArgs e)
        {
            string kod = Lisans.UrunAnahtari();
            if (kod.Length == 32)
            {
                textKod1.Text = kod.Substring(0, 4);
                textKod2.Text = kod.Substring(4, 4);
                textKod3.Text = kod.Substring(8, 4);
                textKod4.Text = kod.Substring(12, 4);
            }
            //string lisans = LisansKontrol();
            //if (lisans.Length == 16)
            //{
            //    lisans1.Text = lisans.Substring(0, 4);
            //    lisans2.Text = lisans.Substring(4, 4);
            //    lisans3.Text = lisans.Substring(8, 4);
            //    lisans4.Text = lisans.Substring(12, 4);
            //}
        }        

        private void butCheck_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textLisans1.Text) || string.IsNullOrEmpty(textLisans2.Text) || string.IsNullOrEmpty(textLisans3.Text) || string.IsNullOrEmpty(textLisans4.Text))
            {
                Kls.Dlg.Hata("Ürün anahtarını tam girin ve tekrar deneyin.");
                return;
            }

            if (Lisans.LisansDogrula(textLisans1.Text + textLisans2.Text + textLisans3.Text + textLisans4.Text) == true)
                Kls.Dlg.Bilgi("Lisans doğrulandı");
            else
                Kls.Dlg.Hata("Lisans yanlış. \nLisans kodunu tekrar kotrol ediniz.");
        }

        private void butOk_Click(object sender, EventArgs e)
        {
            FileStream fs;
            BinaryWriter bw;
            string lisans = textLisans1.Text + textLisans2.Text + textLisans3.Text + textLisans4.Text;
            if (lisans.Length < 16)
            {
                Kls.Dlg.Hata("Lisans kodunu tam giriniz.");
                return;
            }
            try
            {
                fs = new FileStream(Application.StartupPath + "\\Lisans.inc", FileMode.OpenOrCreate);
                bw = new BinaryWriter(fs);
                for (int i = 0; i < lisans.Length; i++)
                {
                    bw.Write(lisans[i]);
                }
                bw.Close();
                fs.Close();
                Kls.Dlg.Bilgi("Lisansınız kaydedildi\nAktif halde kullanmak için programı yeniden başlatınız.");

            }
            catch
            {
                lisans = "";
            }
        }

        private void textKod1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.C)
            {
                Clipboard.SetText(string.Format("{0}-{1}-{2}-{3}", textKod1.Text, textKod2.Text, textKod3.Text, textKod4.Text), TextDataFormat.Text);
            }
        }

        private void textLisans1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.V)
            {
                string str = Clipboard.GetText();
                if (string.IsNullOrEmpty(str)) return;
                if (str.IndexOf('-') == -1)
                {
                    if (str.Length >= 4)
                        textLisans1.Text = str.Substring(0, 4);
                    if(str.Length >= 8)
                        textLisans2.Text = str.Substring(4, 4);
                    if(str.Length >= 12)
                        textLisans3.Text = str.Substring(8, 4);
                    if (str.Length >= 16)
                        textLisans4.Text = str.Substring(12, 4);
                }
                else
                {
                    string[] strObj = str.Split('-');
                    if (strObj == null) return;
                    if (strObj.Length >= 1)
                        textLisans1.Text = strObj[0];
                    if (strObj.Length >= 2)
                        textLisans2.Text = strObj[1];
                    if (strObj.Length >= 3)
                        textLisans3.Text = strObj[2];
                    if (strObj.Length >= 4)
                        textLisans4.Text = strObj[3];
                }
            }
        }
    }
}
