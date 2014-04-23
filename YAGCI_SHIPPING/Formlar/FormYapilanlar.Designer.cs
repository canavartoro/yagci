namespace YAGCI_SHIPPING.Formlar
{
    partial class FormYapilanlar
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colFORM_TURU = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFORMAD = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFORM_BASLIK = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDOLDUMU = new DevExpress.XtraGrid.Columns.GridColumn();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.seçiliFormuAçToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.ContextMenuStrip = this.contextMenuStrip1;
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(1167, 565);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colFORM_TURU,
            this.colFORMAD,
            this.colFORM_BASLIK,
            this.colDOLDUMU});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            // 
            // colFORM_TURU
            // 
            this.colFORM_TURU.FieldName = "FORM_TURU";
            this.colFORM_TURU.Name = "colFORM_TURU";
            this.colFORM_TURU.Visible = true;
            this.colFORM_TURU.VisibleIndex = 0;
            // 
            // colFORMAD
            // 
            this.colFORMAD.Caption = "FORM ADI";
            this.colFORMAD.FieldName = "FORM_NAME";
            this.colFORMAD.Name = "colFORMAD";
            this.colFORMAD.Visible = true;
            this.colFORMAD.VisibleIndex = 1;
            // 
            // colFORM_BASLIK
            // 
            this.colFORM_BASLIK.FieldName = "FORM_BASLIK";
            this.colFORM_BASLIK.Name = "colFORM_BASLIK";
            this.colFORM_BASLIK.Visible = true;
            this.colFORM_BASLIK.VisibleIndex = 2;
            // 
            // colDOLDUMU
            // 
            this.colDOLDUMU.FieldName = "DOLDUMU";
            this.colDOLDUMU.Name = "colDOLDUMU";
            this.colDOLDUMU.Visible = true;
            this.colDOLDUMU.VisibleIndex = 3;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.seçiliFormuAçToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(185, 48);
            // 
            // seçiliFormuAçToolStripMenuItem
            // 
            this.seçiliFormuAçToolStripMenuItem.Image = global::YAGCI_SHIPPING.Properties.Resources._1322777497_stock_data_tables;
            this.seçiliFormuAçToolStripMenuItem.Name = "seçiliFormuAçToolStripMenuItem";
            this.seçiliFormuAçToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.seçiliFormuAçToolStripMenuItem.Text = "Seçili Formu Aç...";
            // 
            // FormYapilanlar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1167, 565);
            this.Controls.Add(this.gridControl1);
            this.Name = "FormYapilanlar";
            this.Text = "Yapılan İşlemler";
            this.Load += new System.EventHandler(this.FormYapilanlar_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colFORM_TURU;
        private DevExpress.XtraGrid.Columns.GridColumn colFORM_BASLIK;
        private DevExpress.XtraGrid.Columns.GridColumn colDOLDUMU;
        private DevExpress.XtraGrid.Columns.GridColumn colFORMAD;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem seçiliFormuAçToolStripMenuItem;
    }
}