using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.Xpo;
using DevExpress.Data.Filtering;

namespace YAGCI_SHIPPING.Formlar
{
    public partial class FormKLFORM : Gui.BaseForm
    {
        public FormKLFORM()
        {
            InitializeComponent();
            xpCollection1.Session = DB.XP.Crs;
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            if (new Formlar.Popup.Secim()
                 {
                     SetData = new XPCollection<Data.Tables.FORMLAR>(DB.XP.Crs, CriteriaOperator.Parse(" USTID <> 0 ")).ToArray(),
                     VisibleColumns = new string[] { "BASLIK", "AD" }
                 }.ShowDialog() == DialogResult.OK)
            {
                Data.Tables.FORMLAR frm = Kls.Gnl.SelectedRow as Data.Tables.FORMLAR;
                xpCollection1.Add(new Data.Tables.REVIZYON(DB.XP.Crs) { NAMESPACE = frm.NAMESPACE });
            }            
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            try
            {

                Data.Tables.REVIZYON rv = gridView1.GetFocusedRow() as Data.Tables.REVIZYON;

                Gui.BaseForm frm = (Gui.BaseForm)Activator.CreateInstance(Type.GetType(rv.NAMESPACE));
                frm.WindowState = FormWindowState.Maximized;
                frm.MdiParent = this.MdiParent;
                //frm.Text = menu.FORMID.BASLIK;
                //frm.SurecId = menu.FORMID.ISSUREC ? (byte)menu.FORMID.Oid : (byte)0;
                //frm.ID = menu.FORMID.Oid;
                frm.Show();
            }
            catch (Exception ee)
            {
                Kls.Dlg.Hata(ee);
            }
        }

        private void gridView1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                if (Kls.Dlg.Soru("Kayıt silinecek..?") != DialogResult.Yes) return;

                Data.Tables.REVIZYON rv = gridView1.GetFocusedRow() as Data.Tables.REVIZYON;

                DB.XP.Crs.ExecuteNonQuery(" DELETE FROM REVIZYON WHERE OID=" + rv.Oid);
                xpCollection1.Reload();
            }
        }
    }
}
