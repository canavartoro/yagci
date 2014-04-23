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


    public partial class UMText : UserControl
    {

        public UMText()
        {
            InitializeComponent();
                     
        }

        public event ObjectSelected MeSelected;
       

        #region Api Tanimlar

        public Control LabelName { get; set; }
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

        #region Tasima
        private Point cursorOffset;
        private bool moving = false;
        private Cursor currentCursor;

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

        private void groupControl1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                cursorOffset = e.Location;
                moving = true;
                currentCursor = base.Cursor;
                base.Cursor = Cursors.SizeAll;
            }
        }

        private void groupControl1_MouseMove(object sender, MouseEventArgs e)
        {
            if (moving)
            {
                Point clientPosition = base.Parent.PointToClient(System.Windows.Forms.Cursor.Position);
                base.Location = new Point(clientPosition.X - cursorOffset.X, clientPosition.Y - cursorOffset.Y);
            }
        }

        private void groupControl1_MouseUp(object sender, MouseEventArgs e)
        {
            moving = false;
            base.Cursor = currentCursor;
            if (MeSelected != null)
            {
                DesingEventArgs e2 = null;
                MeSelected(this, e2);
            }
        }

        private void groupControl1_MouseLeave(object sender, EventArgs e)
        {
            moving = false;
        }

        #endregion
    }
}
