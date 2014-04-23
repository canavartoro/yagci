using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
 

namespace YAGCI_SHIPPING
{
  

    public partial class UGrid : UserControl
    {      
        public UGrid()
        {
            InitializeComponent();           
        }

        public event ObjectSelected MeSelected;

        #region Api Tanimlar

        private static class UnsafeNativeMethods
        {

            public const int WM_NCLBUTTONDOWN = 0xA1;
            public const int HT_CAPTION = 0x2;

            [DllImport("user32.dll")]
            public static extern bool ReleaseCapture();
            [DllImport("user32.dll", CharSet = CharSet.Auto)]
            public static extern IntPtr SendMessage(IntPtr hWnd, UInt32 Msg, IntPtr wParam, IntPtr lParam);
        }

     
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd,
                         int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        #endregion

        protected override void OnMouseUp(MouseEventArgs e)
        {
            Cursor.Current = Cursors.Default;
            base.OnMouseUp(e);
            if (MeSelected != null)
            {
                DesingEventArgs e2 = null;
                //if (gridView1.FocusedColumn != null)
                //{
                //    e2 = new DesingEventArgs();
                //}
                MeSelected(this, e2);
            }
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            ((Control)this.Tag).Text = this.Name;

            int msg = -1; //if (msg == -1) at the end of this, then the mousedown is not a drag.

            if (e.Y < 8)
            {
                Cursor.Current = Cursors.SizeNS;
                msg = 12; //Top
                if (e.X < 25) msg = 13; //Top Left
                if (e.X > Width - 25) msg = 14; //Top Right
            }
            else if (e.X < 8)
            {
                Cursor.Current = Cursors.SizeWE;
                msg = 10; //Left
                if (e.Y < 17) msg = 13;
                if (e.Y > Height - 17) msg = 16;
            }
            else if (e.Y > Height - 9)
            {
                Cursor.Current = Cursors.SizeNS;
                msg = 15; //Bottom
                if (e.X < 25) msg = 16;
                if (e.X > Width - 25) msg = 17;
            }
            else if (e.X > Width - 9)
            {
                Cursor.Current = Cursors.SizeWE;
                msg = 11; //Right
                if (e.Y < 17) msg = 14;
                if (e.Y > Height - 17) msg = 17;
            }

            if (msg != -1)
            {
               UnsafeNativeMethods.ReleaseCapture(); //Release current mouse capture
                UnsafeNativeMethods.SendMessage(Handle, 0xA1, new IntPtr(msg), IntPtr.Zero);
                //Tell the OS that you want to drag the window.
            }            
        }

        private void kolonEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Formlar.FormOzellikler frm =
                 new Formlar.FormOzellikler() { Is = Formlar.FormOzellikler.Isler.RowEkle };

            if (frm.ShowDialog() == DialogResult.OK)
            {
                DataTable dt = gridControl1.DataSource as DataTable;

                if (dt == null) return;

                if (frm.Skl == YAGCI_SHIPPING.Formlar.FormOzellikler.Sekiller.Tarih)
                    dt.Columns.Add(frm.Baslik, typeof(DateTime));
                else
                    dt.Columns.Add(frm.Baslik);

                dt.AcceptChanges();

                gridView1.Columns.Add(
                    new DevExpress.XtraGrid.Columns.GridColumn()
                    {
                        FieldName = dt.Columns[dt.Columns.Count - 1].ColumnName,
                        Caption = frm.Baslik.Trim() == "" ? "" : dt.Columns[dt.Columns.Count - 1].ColumnName,
                        Width = frm.Uzunluk,
                        Visible = true
                    });

                gridView1.RefreshData();

                if (frm.Skl == YAGCI_SHIPPING.Formlar.FormOzellikler.Sekiller.Tarih)
                {
                    DevExpress.XtraEditors.Repository.RepositoryItemDateEdit dtRp
                        = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();

                    //dtRp.DisplayFormat.FormatString = "dd.MM.yyyy";
                    //dtRp.EditFormat.FormatString = "dd.MM.yyyy";
                   
                    dtRp.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;                    
                    gridView1.Columns[gridView1.Columns.Count - 1].ColumnEdit = dtRp;
                    //gridView1.Columns[gridView1.Columns.Count - 1].DisplayFormat.FormatString = "dd.MM.yyyy";                    
                }
                else if (frm.Skl == YAGCI_SHIPPING.Formlar.FormOzellikler.Sekiller.AcilirListe)
                {
                    DevExpress.XtraEditors.Repository.RepositoryItemComboBox dtCmb
                        = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
                    dtCmb.Items.AddRange(frm.Items);
                    dtCmb.Name = "RepositoryItemComboBox" + (gridView1.Columns.Count + 1).ToString();
                    dtCmb.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
                    gridView1.Columns[gridView1.Columns.Count - 1].ColumnEdit = dtCmb;
                }
                
            }
        }

        private void kolonSilToolStripMenuItem_Click(object sender, EventArgs e)
        {

            KolonSil();
        }        

        private void balıkDeğiştirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (gridView1.FocusedColumn == null) return;

            DataTable dt = gridControl1.DataSource as DataTable;
            DataColumn col = dt.Columns[gridView1.FocusedColumn.FieldName];

            Formlar.FormOzellikler frm =
             new Formlar.FormOzellikler()
             {
                 Is = Formlar.FormOzellikler.Isler.BaslikDeistir,
                 Baslik = col.Caption
             };

            if (frm.ShowDialog() == DialogResult.OK)
            {                                
                col.ColumnName = frm.Baslik;
                //gridView1.FocusedColumn.FieldName
                gridView1.FocusedColumn.Caption = frm.Baslik;
                gridView1.FocusedColumn.FieldName = frm.Baslik;
            }
        }

        private void satırEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SatirEkle();
        }

        private void KolonSil()
        {
            DataTable dt = gridControl1.DataSource as DataTable;

            if (dt == null || dt.Columns.Count == 0) return;

            dt.Columns.Remove(dt.Columns[dt.Columns.Count - 1]);
            dt.AcceptChanges();

            gridView1.Columns.Remove(gridView1.Columns[gridView1.Columns.Count - 1]);
            gridView1.RefreshData();
        }

        private void SatirEkle()
        {
            DataTable dt = gridControl1.DataSource as DataTable;

            if (dt == null || dt.Columns.Count == 0) return;

            dt.Rows.Add(dt.NewRow());
            dt.AcceptChanges();

            gridView1.RefreshData();
        }

        private void SatirSil()
        {
            DataTable dt = gridControl1.DataSource as DataTable;
            if (dt == null || dt.Columns.Count == 0) return;
            if (dt.Rows.Count < 1) return;
            dt.Rows.RemoveAt(dt.Rows.Count - 1);
            dt.AcceptChanges();

            gridView1.RefreshData();
        }


        #region Tasima
        private Point cursorOffset;
        private bool moving = false;
        private Cursor currentCursor;

        private void gridControl1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                cursorOffset = e.Location;
                moving = true;
                currentCursor = base.Cursor;
                base.Cursor = Cursors.SizeAll;
            }            
        }

        private void gridControl1_MouseMove(object sender, MouseEventArgs e)
        {
            if (moving)
            {
                Point clientPosition = base.Parent.PointToClient(System.Windows.Forms.Cursor.Position);
                base.Location = new Point(clientPosition.X - cursorOffset.X, clientPosition.Y - cursorOffset.Y);
            }
        }

        private void gridControl1_MouseUp(object sender, MouseEventArgs e)
        {
            moving = false;
            base.Cursor = currentCursor;
            if (MeSelected != null)
            {
                DesingEventArgs e2 = null;
                //if (gridView1.FocusedColumn != null)
                //{
                //    e2 = new DesingEventArgs();
                //    e2.ItemDataColumn = gridView1.FocusedColumn;
                //}
                MeSelected(this, e2);
            }
        }         

        private void gridControl1_MouseLeave(object sender, EventArgs e)
        {
            moving = false;
        }

        #endregion

        private void gridControl1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Insert)
            {
                SatirEkle();
            }
            else if (e.KeyCode == Keys.Delete)
            {
                if (e.Shift)
                    KolonSil();
                else
                    SatirSil();
            }
        }

        private void gridView1_FocusedColumnChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedColumnChangedEventArgs e)
        {
            if (MeSelected != null)
            {
                DesingEventArgs e2 = null;
                if (gridView1.FocusedColumn != null)
                {
                    if (gridView1.FocusedColumn.ColumnEdit != null)
                    {
                        if (gridView1.FocusedColumn.ColumnEdit.GetType() ==
                        typeof(DevExpress.XtraEditors.Repository.RepositoryItemComboBox))
                        {
                            DevExpress.XtraEditors.Repository.RepositoryItemComboBox cmb =
                             gridView1.FocusedColumn.ColumnEdit as DevExpress.XtraEditors.Repository.RepositoryItemComboBox;
                            MeSelected(this, new DesingEventArgs(cmb));
                        }
                    }
                    //DataTable dt = gridControl1.DataSource as DataTable;
                    //DataColumn col = dt.Columns[gridView1.FocusedColumn.FieldName];
                    //e2 = new DesingEventArgs();
                    //e2.ItemComboBox = gridView1.FocusedColumn;
                }
                MeSelected(this, e2);
            }
        }

    }
}
