using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.Data.Filtering;

namespace YAGCI_SHIPPING.Formlar
{
    public partial class FormArsiv : Gui.BaseForm
    {
        public FormArsiv()
        {
            InitializeComponent();
        }

        //this.xpCollection1.CriteriaString = "[TARIH] Between(AddMonths('@CurrentDate', -1), '@CurrentDate')";
        private void btnKaydet_Click(object sender, EventArgs e)
        {
            Data.Tables.FORMGENERIC row = gridView1.GetFocusedRow() as Data.Tables.FORMGENERIC;

            if (row == null) return;

            new FormGENERIC() { MdiParent = this.MdiParent, ArsivLoad = row, ID = row.FORM.Oid }.Show();

        }

        private void barManager1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (e.Item.Id == 0)
            {
                CriteriaOperatorCollection coll = new CriteriaOperatorCollection();
                if (!object.ReferenceEquals(barEditItem1.EditValue, null))
                {
                    if (!object.ReferenceEquals(barEditItem2.EditValue, null))
                        coll.Add(CriteriaOperator.Parse(" TARIH Between (?,?)", barEditItem1.EditValue, barEditItem2.EditValue));
                    else
                        coll.Add(CriteriaOperator.Parse(" TARIH = ?", barEditItem1.EditValue));
                }
                if (barEditItem3.EditValue != null)
                {
                    coll.Add(CriteriaOperator.Parse(" USTFORMID = ? Or ? = 0 ", barEditItem3.EditValue, barEditItem3.EditValue));
                }
                xpCollection1.Criteria = CriteriaOperator.And(coll);
                xpCollection1.TopReturnedObjects = 0;
                gridControl1.RefreshDataSource();
            }
            
        }

        private void FormArsiv_Load(object sender, EventArgs e)
        {
            barEditItem1.EditValue = DateTime.Now.AddMonths(-1);
            barEditItem2.EditValue = DateTime.Now;

            int xoid = 0;
            List<object> xitems = new List<object>();
            if (Kls.Gnl.AktifKullaniciYetkileri != null && Kls.Gnl.AktifKullaniciYetkileri.Length > 0)
            {
                var aitems = Kls.Gnl.AktifKullaniciYetkileri.Where(x => x.FORMID.USTID == 0).Select(x => new { x.FORMID.AD, x.FORMID.BASLIK, x.FORMID.Oid }).ToArray();
                xitems.AddRange(aitems);
                if (aitems != null && aitems.Length > 0)
                    xoid = aitems[0].Oid;
            }
            xitems.Add(new { AD = "HEPSİ", BASLIK = "HEPSİ", Oid = 0 });
            repositoryItemComboBox1.DataSource = xitems;
            repositoryItemComboBox1.DisplayMember = "BASLIK";
            repositoryItemComboBox1.ValueMember = "Oid";
            repositoryItemComboBox1.AutoSearchColumnIndex = 2;
            barEditItem3.EditValue = xoid;
        }
    }
}
