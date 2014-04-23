namespace YAGCI_SHIPPING
{
    partial class UIcone
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.pictureEdit1 = new DevExpress.XtraEditors.PictureEdit();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.resimAcToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureEdit1
            // 
            this.pictureEdit1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureEdit1.EditValue = global::YAGCI_SHIPPING.Properties.Resources._1322777834_button_cancel;
            this.pictureEdit1.Location = new System.Drawing.Point(3, 3);
            this.pictureEdit1.Name = "pictureEdit1";
            this.pictureEdit1.Properties.ContextMenuStrip = this.contextMenuStrip1;
            this.pictureEdit1.Properties.PictureStoreMode = DevExpress.XtraEditors.Controls.PictureStoreMode.ByteArray;
            this.pictureEdit1.Properties.ShowMenu = false;
            this.pictureEdit1.Properties.ShowZoomSubMenu = DevExpress.Utils.DefaultBoolean.False;
            this.pictureEdit1.Size = new System.Drawing.Size(212, 145);
            this.pictureEdit1.TabIndex = 0;
            this.pictureEdit1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureEdit1_MouseUp);
            this.pictureEdit1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureEdit1_MouseMove);
            this.pictureEdit1.MouseLeave += new System.EventHandler(this.pictureEdit1_MouseLeave);
            this.pictureEdit1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureEdit1_MouseDown);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.resimAcToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(124, 26);
            // 
            // resimAcToolStripMenuItem
            // 
            this.resimAcToolStripMenuItem.Name = "resimAcToolStripMenuItem";
            this.resimAcToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.resimAcToolStripMenuItem.Text = "Resim Ac";
            this.resimAcToolStripMenuItem.Click += new System.EventHandler(this.resimAcToolStripMenuItem_Click);
            // 
            // UIcone
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gray;
            this.Controls.Add(this.pictureEdit1);
            this.Name = "UIcone";
            this.Size = new System.Drawing.Size(218, 153);
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PictureEdit pictureEdit1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem resimAcToolStripMenuItem;
    }
}
