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
    public partial class FormYapilanlar : Gui.BaseForm
    {
        public FormYapilanlar()
        {
            InitializeComponent();
        }

        private void FormYapilanlar_Load(object sender, EventArgs e)
        {
            List<Data.Tables.FORMHAREKET> lst = new List<YAGCI_SHIPPING.Data.Tables.FORMHAREKET>();

            foreach (var itm in Kls.Gnl.AktifKullaniciYetkileri.Where(x=>x.FORMID.USTID==0))
            {
                foreach (var frms in Kls.Gnl.AktifKullaniciYetkileri.Where(x => x.FORMID.USTID == itm.FORMID.Oid))
                {

                    lst.Add(new YAGCI_SHIPPING.Data.Tables.FORMHAREKET()
                    {
                        DOLDUMU = true,
                        FORM_NAME=frms.FORMID.BASLIK,
                        FORM_BASLIK = frms.FORMID.AD,
                        FORM_TURU = itm.FORMID.BASLIK
                    });
                }
            }

            gridControl1.DataSource = lst.ToArray();
        }
    }
}
