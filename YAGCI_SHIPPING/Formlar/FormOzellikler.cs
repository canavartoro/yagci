using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace YAGCI_SHIPPING.Formlar
{
    public partial class FormOzellikler : Gui.BaseForm
    {

        public enum Sekiller : byte
        {
            AcilirListe = 0,
            MetinGirisi = 1,
            Tarih = 2,
            EvetHayir = 3
        }

        public enum Isler
        {
            RowEkle = 0,
            BaslikDeistir = 1
        }

        public string Baslik { get; set; }
        public Sekiller Skl { get; set; }

        private string[] items = null;
        public string[] Items { get { return items; } }

        public int Uzunluk
        {
            get
            {
                return Convert.ToInt32(spinEdit1.Value);
            }
        }

        public Isler Is { get; set; }

        public FormOzellikler()
        {
            InitializeComponent();
        }

        private void btnGiris_Click(object sender, EventArgs e)
        {
            if (comboBoxEdit1.Text.Trim() != "")
                Skl = (Sekiller)Enum.Parse(typeof(Sekiller), comboBoxEdit1.Text);

            if (memoEdit1.Enabled && string.IsNullOrEmpty(memoEdit1.Text))
            {
                Kls.Dlg.Hata("Acilir liste elemanlarini girmediniz'");
                return;
            }

            Baslik = textEdit1.Text;
            items = memoEdit1.Text.Replace("\n", "").Split('\r');

            DialogResult = DialogResult.OK;
        }

        private void btnVazgec_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void FormOzellikler_Load(object sender, EventArgs e)
        {

            if (Is == Isler.RowEkle)
            {
                comboBoxEdit1.Enabled = true;
                spinEdit1.Enabled = true;
            }
            else if (Is == Isler.BaslikDeistir)
            {
                labelControl2.Visible = true;
                comboBoxEdit1.Visible = true;
                spinEdit1.Enabled = true;
                textEdit1.Text = Baslik;
            }


            comboBoxEdit1.Properties.Items.AddRange(Enum.GetNames(typeof(Sekiller)));
        }

        private void comboBoxEdit1_SelectedIndexChanged(object sender, EventArgs e)
        {
            memoEdit1.Enabled = comboBoxEdit1.SelectedIndex == (int)Sekiller.AcilirListe;
            if (!string.IsNullOrEmpty(comboBoxEdit1.Text))
            {
            }
        }
    }
}
