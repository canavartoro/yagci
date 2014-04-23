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
    public partial class FormGRUPLAR : Gui.BaseForm
    {
        public FormGRUPLAR()
        {
            InitializeComponent();
            xpCollection1.Session = DB.XP.Crs;
            xpCollection1.DeleteObjectOnRemove = true;
        }

        private void FormGRUPLAR_Load(object sender, EventArgs e)
        {
            Gruplar();           
        }

        private void Gruplar()
        {
            try
            {
                gridLookUpEdit1.Properties.DataSource = null;
                XPQuery<YAGCI_SHIPPING.Data.Tables.KULLANICIGRUP> query = new XPQuery<YAGCI_SHIPPING.Data.Tables.KULLANICIGRUP>(DB.XP.Crs);
                var grups = from x in query
                            select new { GRUPAD = x.GRUPAD, GRUPID = x.Oid };
                gridLookUpEdit1.Properties.DataSource = grups.ToList();
                gridLookUpEdit1.Properties.DisplayMember = "GRUPAD";
                gridLookUpEdit1.Properties.ValueMember = "GRUPID";

                XPQuery<YAGCI_SHIPPING.Data.Tables.FORMLAR> qurForm = new XPQuery<YAGCI_SHIPPING.Data.Tables.FORMLAR>(DB.XP.Crs);
                var forms = (from x in qurForm
                             select new { x.AD, x.BASLIK, ID = x.Oid });
                repositoryItemGridLookUpEdit1.DataSource = forms.ToList();
                repositoryItemGridLookUpEdit1.DisplayMember = "AD";
                repositoryItemGridLookUpEdit1.ValueMember = "ID";                
            }
            catch (Exception exc)
            {
                Kls.Dlg.Hata(exc);
            }
        }

        private void btnYeni_Click(object sender, EventArgs e)
        {
            if (editGrup.Enabled)
            {
                editGrup.Enabled = false;
                btnKaydet.Enabled = false;
                editGrup.Text = "";
            }
            else
            {
                editGrup.Enabled = true;
                btnKaydet.Enabled = true;
                editGrup.Text = "";
                editGrup.Focus();
            }
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                YAGCI_SHIPPING.Data.Tables.KULLANICIGRUP grp = DB.XP.Crs.FindObject<YAGCI_SHIPPING.Data.Tables.KULLANICIGRUP>(CriteriaOperator.Parse(" GRUPAD = ? ", editGrup.Text));
                if (grp != null)
                {
                    Kls.Dlg.Hata(editGrup.Text + " isimli grup mevcut baska bir isim girin!");
                    editGrup.Text = "";
                    editGrup.Focus();
                    return;
                }
                grp = new YAGCI_SHIPPING.Data.Tables.KULLANICIGRUP(DB.XP.Crs);
                grp.GRUPAD = editGrup.Text;
                grp.Save();
                Gruplar();
            }
            catch (Exception exc)
            {
                Kls.Dlg.Hata(exc);
            }
            finally
            {
                editGrup.Enabled = false;
                btnKaydet.Enabled = false;
                editGrup.Text = "";
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            try
            {
                if (gridLookUpEdit1.EditValue == null) return;

                if (Kls.Dlg.Soru(string.Format("{0} idli grup silinecek onayliyor musunuz?", gridLookUpEdit1.EditValue)) == DialogResult.No) return;

                YAGCI_SHIPPING.Data.Tables.KULLANICIGRUP grp = DB.XP.Crs.GetObjectByKey<YAGCI_SHIPPING.Data.Tables.KULLANICIGRUP>(Convert.ToInt32(gridLookUpEdit1.EditValue));
                if (grp == null)
                {
                    Kls.Dlg.Hata("Grup bilgisi bulunamadi!");
                    return;
                }
                grp.Delete();
                Gruplar();
            }
            catch (Exception exc)
            {
                Kls.Dlg.Hata(exc);
            }
            finally
            {
                editGrup.Enabled = false;
                btnKaydet.Enabled = false;
                editGrup.Text = "";
            }
        }

        private void gridLookUpEdit1_EditValueChanged(object sender, EventArgs e)
        {
            if (gridLookUpEdit1.EditValue != null)
            {
                //if (gridLookUpEdit1.GetSelectedDataRow() != null)
                xpCollection1.Criteria = CriteriaOperator.Parse(" GRUPID = ? ", gridLookUpEdit1.EditValue);
                xpCollection1.LoadingEnabled = true;
                gridControl1.RefreshDataSource();
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (gridLookUpEdit1.EditValue == null)
            {
                Kls.Dlg.Hata("Listeden grup secin!");
                return;
            }
            YAGCI_SHIPPING.Data.Tables.KULLANICIGRUP grp = DB.XP.Crs.GetObjectByKey<YAGCI_SHIPPING.Data.Tables.KULLANICIGRUP>(Convert.ToInt32(gridLookUpEdit1.EditValue));
            if(grp == null)
            {
                Kls.Dlg.Hata(string.Format("{0} secilen grup bulunamadi!", gridLookUpEdit1.EditValue));
                return;
            }
            xpCollection1.Add(new Data.Tables.KULLANICIGRUPDETAYLARI(DB.XP.Crs) { GRUPID = grp });
        }

        private void gridControl1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                if (gridView1.SelectedRowsCount > 0)
                {
                    YAGCI_SHIPPING.Data.Tables.KULLANICIGRUPDETAYLARI obj = gridView1.GetFocusedRow() as YAGCI_SHIPPING.Data.Tables.KULLANICIGRUPDETAYLARI;
                    if (obj != null)
                        if (Kls.Dlg.Soru(string.Format("{0} idli kayit silinecek onayliyor musunuz?", obj.Oid)) == DialogResult.Cancel) return;
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
