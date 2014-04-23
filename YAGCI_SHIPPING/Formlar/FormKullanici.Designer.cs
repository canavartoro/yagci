namespace YAGCI_SHIPPING.Formlar
{
    partial class FormKullanici
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
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.xpCollection1 = new DevExpress.Xpo.XPCollection(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colADI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSOYADI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSICIL_NO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTC_KIKLIK_NO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFIRMA = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKULTUR = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemComboBox1 = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.colKAPTAN = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUNVANI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemTextEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemLookUpEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xpCollection1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.simpleButton1);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupControl1.Location = new System.Drawing.Point(0, 594);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(908, 55);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "İşlemler";
            // 
            // simpleButton1
            // 
            this.simpleButton1.Dock = System.Windows.Forms.DockStyle.Right;
            this.simpleButton1.Location = new System.Drawing.Point(811, 21);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(95, 32);
            this.simpleButton1.TabIndex = 0;
            this.simpleButton1.Text = "EKLE";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // gridControl1
            // 
            this.gridControl1.DataSource = this.xpCollection1;
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemComboBox1,
            this.repositoryItemTextEdit1,
            this.repositoryItemLookUpEdit1});
            this.gridControl1.Size = new System.Drawing.Size(908, 594);
            this.gridControl1.TabIndex = 1;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            this.gridControl1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.gridControl1_KeyUp);
            // 
            // xpCollection1
            // 
            this.xpCollection1.ObjectType = typeof(YAGCI_SHIPPING.Data.Tables.KULLANICI);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colADI,
            this.colSOYADI,
            this.colSICIL_NO,
            this.colTC_KIKLIK_NO,
            this.colFIRMA,
            this.colKULTUR,
            this.colKAPTAN,
            this.colUNVANI,
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True;
            this.gridView1.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.True;
            this.gridView1.OptionsDetail.EnableMasterViewMode = false;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            // 
            // colADI
            // 
            this.colADI.FieldName = "ADI";
            this.colADI.Name = "colADI";
            this.colADI.Visible = true;
            this.colADI.VisibleIndex = 0;
            // 
            // colSOYADI
            // 
            this.colSOYADI.FieldName = "SOYADI";
            this.colSOYADI.Name = "colSOYADI";
            this.colSOYADI.Visible = true;
            this.colSOYADI.VisibleIndex = 1;
            // 
            // colSICIL_NO
            // 
            this.colSICIL_NO.FieldName = "SICIL_NO";
            this.colSICIL_NO.Name = "colSICIL_NO";
            this.colSICIL_NO.Visible = true;
            this.colSICIL_NO.VisibleIndex = 2;
            // 
            // colTC_KIKLIK_NO
            // 
            this.colTC_KIKLIK_NO.FieldName = "TC_KIKLIK_NO";
            this.colTC_KIKLIK_NO.Name = "colTC_KIKLIK_NO";
            this.colTC_KIKLIK_NO.Visible = true;
            this.colTC_KIKLIK_NO.VisibleIndex = 3;
            // 
            // colFIRMA
            // 
            this.colFIRMA.FieldName = "FIRMA";
            this.colFIRMA.Name = "colFIRMA";
            this.colFIRMA.Visible = true;
            this.colFIRMA.VisibleIndex = 4;
            // 
            // colKULTUR
            // 
            this.colKULTUR.Caption = "Kullanici Türü";
            this.colKULTUR.ColumnEdit = this.repositoryItemComboBox1;
            this.colKULTUR.FieldName = "KULTUR";
            this.colKULTUR.Name = "colKULTUR";
            this.colKULTUR.Visible = true;
            this.colKULTUR.VisibleIndex = 5;
            // 
            // repositoryItemComboBox1
            // 
            this.repositoryItemComboBox1.AutoHeight = false;
            this.repositoryItemComboBox1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemComboBox1.Name = "repositoryItemComboBox1";
            // 
            // colKAPTAN
            // 
            this.colKAPTAN.FieldName = "KAPTAN";
            this.colKAPTAN.Name = "colKAPTAN";
            this.colKAPTAN.Visible = true;
            this.colKAPTAN.VisibleIndex = 6;
            // 
            // colUNVANI
            // 
            this.colUNVANI.FieldName = "UNVANI";
            this.colUNVANI.Name = "colUNVANI";
            this.colUNVANI.Visible = true;
            this.colUNVANI.VisibleIndex = 7;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Parola";
            this.gridColumn1.ColumnEdit = this.repositoryItemTextEdit1;
            this.gridColumn1.FieldName = "PWORD";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsFilter.AllowAutoFilter = false;
            this.gridColumn1.OptionsFilter.AllowFilter = false;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 8;
            // 
            // repositoryItemTextEdit1
            // 
            this.repositoryItemTextEdit1.AutoHeight = false;
            this.repositoryItemTextEdit1.Name = "repositoryItemTextEdit1";
            this.repositoryItemTextEdit1.PasswordChar = '*';
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Kullanici Grubu";
            this.gridColumn2.ColumnEdit = this.repositoryItemLookUpEdit1;
            this.gridColumn2.FieldName = "GRUP";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 9;
            // 
            // repositoryItemLookUpEdit1
            // 
            this.repositoryItemLookUpEdit1.AutoSearchColumnIndex = 1;
            this.repositoryItemLookUpEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEdit1.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("GRUPAD", 90, "GRUPAD"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("GRUPID", "GRUPID")});
            this.repositoryItemLookUpEdit1.Name = "repositoryItemLookUpEdit1";
            this.repositoryItemLookUpEdit1.NullText = "[Grup secin]";
            this.repositoryItemLookUpEdit1.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Aktarim Yapabilir";
            this.gridColumn3.FieldName = "ENTEGRASYON";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 10;
            // 
            // FormKullanici
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(908, 649);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.groupControl1);
            this.Name = "FormKullanici";
            this.Text = "Kullanicilar";
            this.Load += new System.EventHandler(this.FormKullanici_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xpCollection1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.Xpo.XPCollection xpCollection1;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraGrid.Columns.GridColumn colADI;
        private DevExpress.XtraGrid.Columns.GridColumn colSICIL_NO;
        private DevExpress.XtraGrid.Columns.GridColumn colTC_KIKLIK_NO;
        private DevExpress.XtraGrid.Columns.GridColumn colFIRMA;
        private DevExpress.XtraGrid.Columns.GridColumn colKULTUR;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryItemComboBox1;
        private DevExpress.XtraGrid.Columns.GridColumn colSOYADI;
        private DevExpress.XtraGrid.Columns.GridColumn colKAPTAN;
        private DevExpress.XtraGrid.Columns.GridColumn colUNVANI;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        
    }
}