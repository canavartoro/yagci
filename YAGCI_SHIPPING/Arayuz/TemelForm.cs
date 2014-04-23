using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace YAGCI_SHIPPING.Gui
{
    public partial class BaseForm : DevExpress.XtraEditors.XtraForm
    {
        

        public BaseForm()
        {
            InitializeComponent();

          
        }

        public byte SurecId { get; set; }

        public int ID { get; set; }

        private void BaseForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Form frm = (Form)sender;

            foreach (Control cnt in frm.Controls)
            {
                if (cnt.GetType() == typeof(DevExpress.XtraGrid.GridControl))
                {
                    //((DevExpress.XtraGrid.GridControl)cnt).MainView.SaveLayoutToRegistry(frm.Name + cnt.Name);
                }
            }


            foreach (DevExpress.XtraBars.BarItemLink itm in Kls.Gnl.TaskBar.ItemLinks)
            {
                if (itm.Caption.Replace("[","").Replace("]","") == frm.Text)
                {
                    itm.Dispose();
                    break;
                }
            }
        }

        private void BaseForm_Load(object sender, EventArgs e)
        {

            Form frm = (Form)sender;

            foreach (Control cnt in frm.Controls)
            {
                if (cnt.GetType() == typeof(DevExpress.XtraGrid.GridControl))
                {
                    //((DevExpress.XtraGrid.GridControl)cnt).MainView.RestoreLayoutFromRegistry(frm.Name + cnt.Name);
                }
            }


            //if (SayfaYetki == null) return;

           

            DevExpress.XtraBars.BarItem br = new DevExpress.XtraBars.BarButtonItem();
            br.Border = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            br.Caption = "[" + this.Text + "]";
            br.Tag = sender;
            br.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(br_ItemClick);

            try
            {
                Kls.Gnl.TaskBar.AddItem(br); 
            }
            catch 
            {
                
             
            }
         

        }

        void br_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form frm = ((Form)e.Item.Tag);

            if (frm.WindowState == FormWindowState.Minimized)
                frm.WindowState = FormWindowState.Normal;
            
             
            frm.Activate();

        }

       
    }
}