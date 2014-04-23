namespace YAGCI_SHIPPING
{
    partial class UVGrid
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
            this.vGridControl1 = new DevExpress.XtraVerticalGrid.VGridControl();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.yeniSatırToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.satırınBaşlığınıDeğiştirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.satırıSilToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.acılırListeElemanlarınıDüzenleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TextEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.TextEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.row = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.row1 = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            ((System.ComponentModel.ISupportInitialize)(this.vGridControl1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TextEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextEdit2)).BeginInit();
            this.SuspendLayout();
            // 
            // vGridControl1
            // 
            this.vGridControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.vGridControl1.ContextMenuStrip = this.contextMenuStrip1;
            this.vGridControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.vGridControl1.Location = new System.Drawing.Point(4, 5);
            this.vGridControl1.Name = "vGridControl1";
            this.vGridControl1.OptionsView.FixRowHeaderPanelWidth = true;
            this.vGridControl1.RecordWidth = 1373;
            this.vGridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.TextEdit1,
            this.TextEdit2});
            this.vGridControl1.RowHeaderWidth = 257;
            this.vGridControl1.Rows.AddRange(new DevExpress.XtraVerticalGrid.Rows.BaseRow[] {
            this.row,
            this.row1});
            this.vGridControl1.Size = new System.Drawing.Size(563, 93);
            this.vGridControl1.TabIndex = 0;
            this.vGridControl1.FocusedRowChanged += new DevExpress.XtraVerticalGrid.Events.FocusedRowChangedEventHandler(this.vGridControl1_FocusedRowChanged);
            this.vGridControl1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.vGridControl1_MouseUp);
            this.vGridControl1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.vGridControl1_KeyDown);
            this.vGridControl1.MouseLeave += new System.EventHandler(this.vGridControl1_MouseLeave);
            this.vGridControl1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.vGridControl1_MouseDown);
            this.vGridControl1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.vGridControl1_KeyUp);
            this.vGridControl1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.vGridControl1_MouseMove);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.yeniSatırToolStripMenuItem,
            this.satırınBaşlığınıDeğiştirToolStripMenuItem,
            this.satırıSilToolStripMenuItem,
            this.acılırListeElemanlarınıDüzenleToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(238, 92);
            // 
            // yeniSatırToolStripMenuItem
            // 
            this.yeniSatırToolStripMenuItem.Name = "yeniSatırToolStripMenuItem";
            this.yeniSatırToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.Insert;
            this.yeniSatırToolStripMenuItem.Size = new System.Drawing.Size(237, 22);
            this.yeniSatırToolStripMenuItem.Text = "Yeni Satır";
            this.yeniSatırToolStripMenuItem.Click += new System.EventHandler(this.yeniSatırToolStripMenuItem_Click);
            // 
            // satırınBaşlığınıDeğiştirToolStripMenuItem
            // 
            this.satırınBaşlığınıDeğiştirToolStripMenuItem.Name = "satırınBaşlığınıDeğiştirToolStripMenuItem";
            this.satırınBaşlığınıDeğiştirToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F2;
            this.satırınBaşlığınıDeğiştirToolStripMenuItem.Size = new System.Drawing.Size(237, 22);
            this.satırınBaşlığınıDeğiştirToolStripMenuItem.Text = "Satırın Başlığını Değiştir";
            this.satırınBaşlığınıDeğiştirToolStripMenuItem.Click += new System.EventHandler(this.satırınBaşlığınıDeğiştirToolStripMenuItem_Click);
            // 
            // satırıSilToolStripMenuItem
            // 
            this.satırıSilToolStripMenuItem.Name = "satırıSilToolStripMenuItem";
            this.satırıSilToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.Delete;
            this.satırıSilToolStripMenuItem.Size = new System.Drawing.Size(237, 22);
            this.satırıSilToolStripMenuItem.Text = "Satırı Sil";
            this.satırıSilToolStripMenuItem.Click += new System.EventHandler(this.satırıSilToolStripMenuItem_Click);
            // 
            // acılırListeElemanlarınıDüzenleToolStripMenuItem
            // 
            this.acılırListeElemanlarınıDüzenleToolStripMenuItem.Name = "acılırListeElemanlarınıDüzenleToolStripMenuItem";
            this.acılırListeElemanlarınıDüzenleToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F3;
            this.acılırListeElemanlarınıDüzenleToolStripMenuItem.Size = new System.Drawing.Size(237, 22);
            this.acılırListeElemanlarınıDüzenleToolStripMenuItem.Text = "AcılırListe Elemanlarını Düzenle";
            this.acılırListeElemanlarınıDüzenleToolStripMenuItem.Click += new System.EventHandler(this.acılırListeElemanlarınıDüzenleToolStripMenuItem_Click);
            // 
            // TextEdit1
            // 
            this.TextEdit1.AutoHeight = false;
            this.TextEdit1.Name = "TextEdit1";
            // 
            // TextEdit2
            // 
            this.TextEdit2.AutoHeight = false;
            this.TextEdit2.Name = "TextEdit2";
            // 
            // row
            // 
            this.row.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.row.Appearance.Options.UseFont = true;
            this.row.Appearance.Options.UseTextOptions = true;
            this.row.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.row.Height = 25;
            this.row.Name = "row";
            this.row.Properties.Caption = "Başlık";
            this.row.Properties.RowEdit = this.TextEdit1;
            // 
            // row1
            // 
            this.row1.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.row1.Appearance.Options.UseFont = true;
            this.row1.Height = 25;
            this.row1.Name = "row1";
            this.row1.Properties.Caption = "Baslik 2";
            this.row1.Properties.RowEdit = this.TextEdit2;
            // 
            // UVGrid
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gray;
            this.Controls.Add(this.vGridControl1);
            this.Name = "UVGrid";
            this.Size = new System.Drawing.Size(570, 104);
            ((System.ComponentModel.ISupportInitialize)(this.vGridControl1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.TextEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextEdit2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraVerticalGrid.Rows.EditorRow row;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow row1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem yeniSatırToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem satırınBaşlığınıDeğiştirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem satırıSilToolStripMenuItem;
        public DevExpress.XtraVerticalGrid.VGridControl vGridControl1;
        private System.Windows.Forms.ToolStripMenuItem acılırListeElemanlarınıDüzenleToolStripMenuItem;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit TextEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit TextEdit2;

    }
}
