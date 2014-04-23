namespace YAGCI_SHIPPING
{
    partial class ULabel
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
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.metniDeğiştirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControl1.Appearance.BackColor = System.Drawing.Color.White;
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelControl1.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.labelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl1.ContextMenuStrip = this.contextMenuStrip1;
            this.labelControl1.Location = new System.Drawing.Point(8, 7);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(346, 20);
            this.labelControl1.TabIndex = 5;
            this.labelControl1.Text = "Sabit Metin";
            this.labelControl1.MouseLeave += new System.EventHandler(this.labelControl1_MouseLeave);
            this.labelControl1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.labelControl1_MouseMove);
            this.labelControl1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.labelControl1_MouseDown);
            this.labelControl1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.labelControl1_MouseUp);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.metniDeğiştirToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(149, 26);
            // 
            // metniDeğiştirToolStripMenuItem
            // 
            this.metniDeğiştirToolStripMenuItem.Name = "metniDeğiştirToolStripMenuItem";
            this.metniDeğiştirToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.metniDeğiştirToolStripMenuItem.Text = "Metni Değiştir";
            this.metniDeğiştirToolStripMenuItem.Click += new System.EventHandler(this.metniDeğiştirToolStripMenuItem_Click);
            // 
            // ULabel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gray;
            this.Controls.Add(this.labelControl1);
            this.Name = "ULabel";
            this.Size = new System.Drawing.Size(360, 35);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem metniDeğiştirToolStripMenuItem;
        public DevExpress.XtraEditors.LabelControl labelControl1;


    }
}
