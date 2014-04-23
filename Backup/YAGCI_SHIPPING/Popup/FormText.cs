using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace YAGCI_SHIPPING.Formlar.Popup
{
    public partial class FormText : Gui.BaseForm
    {
           
        public string Items { get; set; }
      

        public FormText()
        {
            InitializeComponent();
        }

        private void btnGiris_Click(object sender, EventArgs e)
        {

            Items = memoEdit1.Text;

            DialogResult = DialogResult.OK;
        }

        private void btnVazgec_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void FormOzellikler_Load(object sender, EventArgs e)
        {
            memoEdit1.Text = Items;
           
        }
    }
}
