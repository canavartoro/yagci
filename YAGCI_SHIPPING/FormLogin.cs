using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Collections;
using System.Text;
using System.Windows.Forms;
using YAGCI_SHIPPING.Kls;
using DevExpress.Xpo;

namespace YAGCI_SHIPPING.Formlar
{
    public partial class FormLogin : DevExpress.XtraEditors.XtraForm
    {
        public FormLogin()
        {
            InitializeComponent();
        }

    

     
        private void cmbusercode_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtPass.Focus();
        }

        private void txtPass_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnGiris_Click(null, null);
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {
            lblMod.Caption = Properties.Settings.Default.ProgramMod > 0 ? "Server Mod" : "Client Mod";

            if (Properties.Settings.Default.ProgramMod < 1)
            {
                cmbGemiler.EditValue = Properties.Settings.Default.FIRMA;
                cmbGemiler.Enabled = false;
            }

            Kullanicilar();
        }

        private void Kullanicilar()
        {
            try
            {

                int by = (int)Properties.Settings.Default.ProgramMod;

                cmbKullanici.Properties.Items.AddRange(
                    new XPCollection<Data.Tables.KULLANICI>(DB.XP.Crs).Where(u => u.KULTUR.GetHashCode() == by).Select(x => x.ADI.Trim() + " " + x.SOYADI).ToArray());

                cmbGemiler.Properties.DataSource =
                new XPCollection<Data.Tables.FIRMALAR>(DB.XP.Crs);

                //xpView1.Reload();
            }
            catch (Exception exc)
            {
                Kls.Dlg.Hata(exc);
            }
        }
  

        private void btnVazgec_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void btnGiris_Click(object sender, EventArgs e)
        {
            if (cmbKullanici.SelectedIndex < 0)
                return;

            int idx = cmbKullanici.SelectedIndex;
           
            try
            {
                if (cmbGemiler.EditValue == null)
                    throw new Exception(" Gemi adını seçiniz... ");

                string sekul = cmbKullanici.Text.Split(' ')[0].Trim();

                var snc = new XPCollection<Data.Tables.KULLANICI>(DB.XP.Crs).Where(x => x.ADI.Trim() == sekul && x.PWORD == txtPass.Text);

                if (snc == null || snc.Count() < 1)
                    throw new Exception("Bilgiler dogru deil , kontrol ediniz..!");

                Gnl.AktifKullanici = snc.ToList()[0];

               
                Data.Tables.FIRMALAR oo = cmbGemiler.Properties.GetDataSourceRowByKeyValue(cmbGemiler.EditValue)
                    as Data.Tables.FIRMALAR;

                Gnl.AktifFirma = oo;

                //if (frm == null)
                //    throw new Exception("Firma seçilmemiş , kontrol ediniz..!");

                //Gnl.AktifFirma = frm;
 
                DialogResult = DialogResult.OK;
            }
            catch (Exception exc)
            {
                Kls.Dlg.Hata(exc);          
            }            
        }

        private void btnAyar_Click(object sender, EventArgs e)
        {
   
        }

        private void lkpFirma_CustomDisplayText(object sender, DevExpress.XtraEditors.Controls.CustomDisplayTextEventArgs e)
        {
            //Data.Views.vLOGO_FIRMALAR fr = lkpFirma.GetSelectedDataRow() as Data.Views.vLOGO_FIRMALAR;

            //if (fr == null) return;

           // e.DisplayText = "(" + fr.NR.ToString().PadLeft(3, '0') + ")-(" + fr.DONEM.PadLeft(1, '0') + ")";
        }
    }
}
