using System;
using System.Collections.Generic;

using System.Text;
using System.Windows.Forms;

namespace YAGCI_SHIPPING.Util
{
    public class TaskControl
    {

        public TaskControl() { ;}

        public void FormOpen(Form OpeningForm)
        {
            Cursor.Current = Cursors.WaitCursor;

            //foreach (Form fr in Utility.Main_.MdiChildren)
            //{
            //    if (fr.Text == OpeningForm.Text)
            //    { fr.Activate(); Cursor.Current = Cursors.Default; return; }
            //}

            OpeningForm.WindowState = System.Windows.Forms.FormWindowState.Normal;
            OpeningForm.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            //OpeningForm.MdiParent = Utility.Main_;
            OpeningForm.Show();            
            StatusBarTab(OpeningForm.Text);
            Cursor.Current = Cursors.Default;
        }

        public void StatusBarDelete(string ThisText)
        {
            //for (int i = 0; i < Utility.Main_.GetStatus.ItemLinks.Count; i++)
            //{
            //    if (Utility.Main_.GetStatus.ItemLinks[i].Item.Caption.Replace("[", "").Replace("]", "") == ThisText)
            //        Utility.Main_.GetStatus.ItemLinks[i].Item.Dispose();
            //}
        }

        private static void StatusBarTab(string FormText)
        {
            //for (int i = 0; i < Utility.Main_.GetStatus.ItemLinks.Count; i++)
            //{
            //    if (Utility.Main_.GetStatus.ItemLinks[i].Item.Caption.Replace("[", "").Replace("]", "") == FormText)
            //        return;
            //}

            //DevExpress.XtraBars.BarButtonItem brsi = new DevExpress.XtraBars.BarButtonItem();
            //brsi.BorderStyle = DevExpress.XtraBars.BarItemBorderStyle.Single;
            //brsi.Caption = "[" + FormText + "]";
            //brsi.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(brsi_ItemClick);
            //Utility.Main_.GetStatus.ItemLinks.Add(brsi);
        }

        static void brsi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //foreach (Form fr in Utility.Main_.MdiChildren)
            //{
            //    if (fr.Text == e.Item.Caption.Replace("[", "").Replace("]", ""))
            //    {
            //        if (fr.WindowState == FormWindowState.Minimized)
            //            fr.WindowState = FormWindowState.Normal;
            //        else if (fr.WindowState == FormWindowState.Normal)
            //            fr.WindowState = FormWindowState.Minimized;
            //        else
            //            fr.Activate();
            //    }
                    
            //}
        }
        
    }
}
