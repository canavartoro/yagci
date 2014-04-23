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
    public partial class FormFirmalar : Gui.BaseForm
    {
        public FormFirmalar()
        {
            InitializeComponent();
            xpCollection1.Session = DB.XP.Crs;
            xpCollection1.DeleteObjectOnRemove = true;
        }

        private void gridControl1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                if (gridView1.SelectedRowsCount > 0)
                {
                    YAGCI_SHIPPING.Data.Tables.FIRMALAR obj = gridView1.GetFocusedRow() as YAGCI_SHIPPING.Data.Tables.FIRMALAR;
                    if (obj != null)
                        if (Kls.Dlg.Soru(string.Format("{0} isimli gemi kaydi silinecek onayliyor musunuz?", obj.FRMNAME)) == DialogResult.Cancel) return;
                    gridView1.DeleteSelectedRows();
                }
                else
                {
                    gridView1.DeleteRow(gridView1.GetRowHandle(gridView1.RowCount - 1));
                }
                //xpCollection1.Session.Save(xpCollection1);
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            xpCollection1.Add(new Data.Tables.FIRMALAR(DB.XP.Crs) {  });
        }
    }
}
