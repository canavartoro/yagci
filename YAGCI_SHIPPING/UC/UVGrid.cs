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

    public partial class UVGrid : UserControl
    {
        public event ObjectSelected MeSelected;

        public UVGrid()
        {
            InitializeComponent();
          
        }

        public Control LabelName { get; set; }

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
                MeSelected(this, null);
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

        private void yeniSatırToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Formlar.FormOzellikler frm=
            new Formlar.FormOzellikler() { Is = Formlar.FormOzellikler.Isler.RowEkle };

            if (frm.ShowDialog() == DialogResult.OK)
            {

                DevExpress.XtraVerticalGrid.Rows.EditorRow xRow = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
                xRow.Appearance.Font = 
                    new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
                xRow.Appearance.Options.UseFont = true;
                xRow.Height = 25;
                xRow.Name = "xRow" + vGridControl1.Rows.Count.ToString();

                if (frm.Skl == Formlar.FormOzellikler.Sekiller.AcilirListe)
                {
                    DevExpress.XtraEditors.Repository.RepositoryItemComboBox rCmb = 
                        new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
                    
                    rCmb.AutoHeight = false;
                    rCmb.Items.AddRange(frm.Items);
                    rCmb.Name = "RepositoryItemComboBox" + (vGridControl1.Rows.Count + 1).ToString();
                    rCmb.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;                    
                    xRow.Properties.RowEdit = rCmb;
                }
                else if (frm.Skl == Formlar.FormOzellikler.Sekiller.MetinGirisi)
                {
                    DevExpress.XtraEditors.Repository.RepositoryItemTextEdit 
                        rTxt = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
                    rTxt.Name = "RepositoryItemTextEdit" + (vGridControl1.Rows.Count + 1).ToString();
                    xRow.Properties.RowEdit = rTxt;
                }
                else if (frm.Skl == YAGCI_SHIPPING.Formlar.FormOzellikler.Sekiller.Tarih)
                {
                    DevExpress.XtraEditors.Repository.RepositoryItemDateEdit
                         rDdate = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
                    rDdate.Name = "RepositoryItemDateEdit" + (vGridControl1.Rows.Count + 1).ToString();
                    rDdate.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
                    xRow.Properties.RowEdit = rDdate;
                }
                else if (frm.Skl == YAGCI_SHIPPING.Formlar.FormOzellikler.Sekiller.EvetHayir)
                {
                    DevExpress.XtraEditors.Repository.RepositoryItemComboBox
                         rpItem = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
                    rpItem.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
                    rpItem.Name = "RepositoryItemComboBox" + (vGridControl1.Rows.Count + 1).ToString();

                    rpItem.Items.Add("Evet");
                    rpItem.Items.Add("Hayır");

                    xRow.Properties.RowEdit = rpItem;
                }


                xRow.Properties.Caption = frm.Baslik;
                vGridControl1.Rows.Add(xRow);                    
            }
        }

        private void satırınBaşlığınıDeğiştirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (vGridControl1.FocusedRow != null)
            {
                Formlar.FormOzellikler frm =
              new Formlar.FormOzellikler() { Is = Formlar.FormOzellikler.Isler.BaslikDeistir };

                if (frm.ShowDialog() == DialogResult.OK)
                {
                    int ii = vGridControl1.FocusedRow.Index;

                    vGridControl1.Rows[ii].Properties.Caption = frm.Baslik;
                }
            }
        }

        private void satırıSilToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (vGridControl1.FocusedRow == null) return;
            vGridControl1.Rows.Remove(vGridControl1.FocusedRow);
        }

        private void acılırListeElemanlarınıDüzenleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (vGridControl1.FocusedRow != null)
            {
                Formlar.Popup.FormText ff =
            new Formlar.Popup.FormText();

                if (ff.ShowDialog() == DialogResult.OK)
                {
                    if (vGridControl1.FocusedRow.Properties.RowEdit.GetType() == typeof(DevExpress.XtraEditors.Repository.RepositoryItemComboBox))
                    {
                        DevExpress.XtraEditors.Repository.RepositoryItemComboBox cmb =
                         vGridControl1.FocusedRow.Properties.RowEdit as DevExpress.XtraEditors.Repository.RepositoryItemComboBox;
                        cmb.Items.Clear();
                        string[] strs = ff.Items.Split('\r');
                        cmb.Items.AddRange(strs.Select(x => x.Replace("\n", "")).ToArray());
                    }

                }
            }
        }

        #region Tasima
        private Point cursorOffset;
        private bool moving = false, nomoving = false;
        private Cursor currentCursor;        

        private void vGridControl1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                cursorOffset = e.Location;
                moving = true;
                currentCursor = base.Cursor;
                base.Cursor = Cursors.SizeAll;
            }
        }

        private void vGridControl1_MouseMove(object sender, MouseEventArgs e)
        {
            if (moving && nomoving == false)
            {
                Point clientPosition = base.Parent.PointToClient(System.Windows.Forms.Cursor.Position);
                base.Location = new Point(clientPosition.X - cursorOffset.X, clientPosition.Y - cursorOffset.Y);
            }
        }

        private void vGridControl1_MouseUp(object sender, MouseEventArgs e)
        {
            moving = false;
            base.Cursor = currentCursor;
            if (MeSelected != null)
            {
                DesingEventArgs e2 = null;
                if (vGridControl1.FocusedRow != null)
                {
                    DevExpress.XtraEditors.Repository.RepositoryItemComboBox cmb =
                     vGridControl1.FocusedRow.Properties.RowEdit as DevExpress.XtraEditors.Repository.RepositoryItemComboBox;
                    e2 = new DesingEventArgs(cmb);
                }
                MeSelected(this, e2);
            }
        }

        private void vGridControl1_MouseLeave(object sender, EventArgs e)
        {
            moving = false;
        }

        #endregion

        private void vGridControl1_FocusedRowChanged(object sender, DevExpress.XtraVerticalGrid.Events.FocusedRowChangedEventArgs e)
        {
            if (MeSelected != null)
            {
                if (vGridControl1.FocusedRow != null)
                {
                    if (vGridControl1.FocusedRow.Properties.RowEdit.GetType() == typeof(DevExpress.XtraEditors.Repository.RepositoryItemComboBox))
                    {
                        DevExpress.XtraEditors.Repository.RepositoryItemComboBox cmb =
                         vGridControl1.FocusedRow.Properties.RowEdit as DevExpress.XtraEditors.Repository.RepositoryItemComboBox;
                        MeSelected(this, new DesingEventArgs(cmb));
                    }
                }
            }
        }

        private void vGridControl1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == (Keys.LButton | Keys.ShiftKey))
            {
                nomoving = true;
                moving = false;
            }
        }

        private void vGridControl1_KeyUp(object sender, KeyEventArgs e)
        {
            nomoving = false;
        }

    }
}
