namespace YAGCI_SHIPPING
{
    partial class UGrid
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
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.kolonEkleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kolonSilToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.balıkDeğiştirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.satırEkleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.kolonEkleToolStripMenuItem,
            this.kolonSilToolStripMenuItem,
            this.balıkDeğiştirToolStripMenuItem,
            this.satırEkleToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(188, 92);
            // 
            // kolonEkleToolStripMenuItem
            // 
            this.kolonEkleToolStripMenuItem.Name = "kolonEkleToolStripMenuItem";
            this.kolonEkleToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.kolonEkleToolStripMenuItem.Text = "Kolon Ekle (Shift+Ins)";
            this.kolonEkleToolStripMenuItem.Click += new System.EventHandler(this.kolonEkleToolStripMenuItem_Click);
            // 
            // kolonSilToolStripMenuItem
            // 
            this.kolonSilToolStripMenuItem.Name = "kolonSilToolStripMenuItem";
            this.kolonSilToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.kolonSilToolStripMenuItem.Text = "Kolon Sil (Shift+Del)";
            this.kolonSilToolStripMenuItem.Click += new System.EventHandler(this.kolonSilToolStripMenuItem_Click);
            // 
            // balıkDeğiştirToolStripMenuItem
            // 
            this.balıkDeğiştirToolStripMenuItem.Name = "balıkDeğiştirToolStripMenuItem";
            this.balıkDeğiştirToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F2;
            this.balıkDeğiştirToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.balıkDeğiştirToolStripMenuItem.Text = "Başlık Değiştir";
            this.balıkDeğiştirToolStripMenuItem.Click += new System.EventHandler(this.balıkDeğiştirToolStripMenuItem_Click);
            // 
            // satırEkleToolStripMenuItem
            // 
            this.satırEkleToolStripMenuItem.Name = "satırEkleToolStripMenuItem";
            this.satırEkleToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.satırEkleToolStripMenuItem.Text = "Satır Ekle (Ins)";
            this.satırEkleToolStripMenuItem.Click += new System.EventHandler(this.satırEkleToolStripMenuItem_Click);
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.FocusedColumnChanged += new DevExpress.XtraGrid.Views.Base.FocusedColumnChangedEventHandler(this.gridView1_FocusedColumnChanged);
            // 
            // gridControl1
            // 
            this.gridControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControl1.ContextMenuStrip = this.contextMenuStrip1;
            this.gridControl1.Location = new System.Drawing.Point(5, 6);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(527, 240);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            this.gridControl1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.gridControl1_MouseUp);
            this.gridControl1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.gridControl1_MouseMove);
            this.gridControl1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.gridControl1_MouseDown);
            this.gridControl1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gridControl1_KeyDown);
            this.gridControl1.MouseLeave += new System.EventHandler(this.gridControl1_MouseLeave);
            // 
            // UGrid
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gray;
            this.Controls.Add(this.gridControl1);
            this.Name = "UGrid";
            this.Size = new System.Drawing.Size(537, 250);
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem kolonEkleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem kolonSilToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem balıkDeğiştirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem satırEkleToolStripMenuItem;
        public DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        public DevExpress.XtraGrid.GridControl gridControl1;
    }
}
