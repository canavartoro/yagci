using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;
using System.Windows.Forms;

namespace YAGCI_SHIPPING.Formlar.Ayarlar
{
    public partial class Ayar : Gui.BaseForm
    {
        public Ayar()
        {
            InitializeComponent();
        }

        private void comboBoxEdit1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Kls.Gnl.DefLookFeel1 != null)
            {
                Kls.Gnl.DefLookFeel1.LookAndFeel.SetSkinStyle(comboBoxEdit1.Text);
                Kls.Gnl.IniData.Write("DevexTema", comboBoxEdit1.Text);
            }
        }

        private void Ayar_Load(object sender, EventArgs e)
        {
            textServ.Text = Kls.Gnl.IniData.Read("WebUrl", textServ.Text);
            foreach (DevExpress.Skins.SkinContainer skin in DevExpress.Skins.SkinManager.Default.Skins)
            {
                comboBoxEdit1.Properties.Items.Add(skin.SkinName);
            }
            comboBoxEdit1.Text = Kls.Gnl.IniData.Read("DevexTema", "VS2010");
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {

            DialogResult = DialogResult.Cancel;
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            Kls.Gnl.IniData.Write("WebUrl", textServ.Text);
            //Util.Utility.Web.Url = txtAdress.Text;
            this.DialogResult = DialogResult.OK;
        }
    }
}
