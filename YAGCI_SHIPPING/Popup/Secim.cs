using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.Xpo;

namespace YAGCI_SHIPPING.Formlar.Popup
{
    public partial class Secim : Gui.BaseForm
    {
        public Secim()
        {
            InitializeComponent();            
        }


        public object SetData
        {
            get
            {
                return gcSecim.DataSource;
            }
            set { gcSecim.DataSource = value; }
        }

        public bool Ekle
        {
            get { return btnEkle.Visible; }
            set { btnEkle.Visible = value; }
        }

        public Form KayitEkle { get; set; }

        public string[] VisibleColumns { get; set; }

        private void btnCikis_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void btnOnayaGonder_Click(object sender, EventArgs e)
        {
            Kls.Gnl.SelectedRow  = gvSecim.GetFocusedRow();

            DialogResult = DialogResult.OK;
        }

        private void Secim_Load(object sender, EventArgs e)
        {
            foreach (DevExpress.XtraGrid.Columns.GridColumn col in gvSecim.Columns)
            {
                if (col.Name.IndexOf("Oid") > -1 || col.Name.IndexOf("OID") > -1)
                    col.Visible = false;
            }

            if (VisibleColumns != null && VisibleColumns.Length > 0)
                foreach (DevExpress.XtraGrid.Columns.GridColumn col in gvSecim.Columns)
                {
                    if (VisibleColumns.Where(x => x.Equals(col.FieldName)).Count() > 0)
                        col.Visible = true;
                    else
                        col.Visible = false;
                }
        }

        private void gvSecim_DoubleClick(object sender, EventArgs e)
        {
            btnOnayaGonder_Click(null, null);
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            if (KayitEkle.ShowDialog() == DialogResult.OK)
                (gvSecim.DataSource as XPCollection).Reload();
        }


    }
}
