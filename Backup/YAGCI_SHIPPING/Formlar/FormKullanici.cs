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
    public partial class FormKullanici : Gui.BaseForm
    {
        public FormKullanici()
        {
            InitializeComponent();
            xpCollection1.Session = DB.XP.Crs;
            xpCollection1.DeleteObjectOnRemove = true;
        }
       
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            xpCollection1.Add(new Data.Tables.KULLANICI(DB.XP.Crs) { });
            gridView1.SelectRow(gridView1.RowCount - 1);
        }

        private void FormKullanici_Load(object sender, EventArgs e)
        {
            repositoryItemComboBox1.Items.AddRange(Enum.GetNames(typeof(DB.MOD)));

            XPQuery<YAGCI_SHIPPING.Data.Tables.KULLANICIGRUP> query = new XPQuery<YAGCI_SHIPPING.Data.Tables.KULLANICIGRUP>(DB.XP.Crs);
            var grups = from x in query
                        select new { GRUPAD = x.GRUPAD, GRUPID = x.Oid };
            repositoryItemLookUpEdit1.DataSource = grups.ToList();
            repositoryItemLookUpEdit1.DisplayMember = "GRUPAD";
            repositoryItemLookUpEdit1.ValueMember = "GRUPID";
            repositoryItemLookUpEdit1.AutoSearchColumnIndex = 1;

        }

        private void gridControl1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                if (gridView1.SelectedRowsCount > 0)
                {
                    YAGCI_SHIPPING.Data.Tables.KULLANICI obj = gridView1.GetFocusedRow() as YAGCI_SHIPPING.Data.Tables.KULLANICI;
                    if (obj != null)
                        if (Kls.Dlg.Soru(string.Format("{0} isimli kullanici silinecek onayliyor musunuz?", obj.ADI)) == DialogResult.Cancel) return;
                    gridView1.DeleteSelectedRows();                    
                }
                else
                {
                    gridView1.DeleteRow(gridView1.GetRowHandle(gridView1.RowCount - 1));
                }
                //xpCollection1.Session.Save(xpCollection1);
            }
        }
    }
}
