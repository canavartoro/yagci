namespace YAGCI_SHIPPING.Formlar
{
    partial class FormFirmalar
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
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.xpCollection1 = new DevExpress.Xpo.XPCollection(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colOid = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFRMCODE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFRMNAME = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVERGINO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVERGIDAIRESI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPOSTAKODU = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colADRES = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIL = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colILCE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTELEFON = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFAX = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMAIL = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colILGILI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNOTLAR = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xpCollection1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.simpleButton1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl1.Location = new System.Drawing.Point(0, 600);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(908, 79);
            this.panelControl1.TabIndex = 0;
            // 
            // simpleButton1
            // 
            this.simpleButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.simpleButton1.Location = new System.Drawing.Point(800, 40);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(103, 34);
            this.simpleButton1.TabIndex = 0;
            this.simpleButton1.Text = "Ekle";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // gridControl1
            // 
            this.gridControl1.DataSource = this.xpCollection1;
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(908, 600);
            this.gridControl1.TabIndex = 1;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            this.gridControl1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.gridControl1_KeyUp);
            // 
            // xpCollection1
            // 
            this.xpCollection1.ObjectType = typeof(YAGCI_SHIPPING.Data.Tables.FIRMALAR);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colOid,
            this.colFRMCODE,
            this.colFRMNAME,
            this.colVERGINO,
            this.colVERGIDAIRESI,
            this.colPOSTAKODU,
            this.colADRES,
            this.colIL,
            this.colILCE,
            this.colTELEFON,
            this.colFAX,
            this.colMAIL,
            this.colILGILI,
            this.colNOTLAR});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            // 
            // colOid
            // 
            this.colOid.FieldName = "Oid";
            this.colOid.Name = "colOid";
            // 
            // colFRMCODE
            // 
            this.colFRMCODE.FieldName = "FRMCODE";
            this.colFRMCODE.Name = "colFRMCODE";
            this.colFRMCODE.Visible = true;
            this.colFRMCODE.VisibleIndex = 0;
            this.colFRMCODE.Width = 150;
            // 
            // colFRMNAME
            // 
            this.colFRMNAME.FieldName = "FRMNAME";
            this.colFRMNAME.Name = "colFRMNAME";
            this.colFRMNAME.Visible = true;
            this.colFRMNAME.VisibleIndex = 1;
            this.colFRMNAME.Width = 300;
            // 
            // colVERGINO
            // 
            this.colVERGINO.FieldName = "VERGINO";
            this.colVERGINO.Name = "colVERGINO";
            this.colVERGINO.Visible = true;
            this.colVERGINO.VisibleIndex = 2;
            this.colVERGINO.Width = 39;
            // 
            // colVERGIDAIRESI
            // 
            this.colVERGIDAIRESI.FieldName = "VERGIDAIRESI";
            this.colVERGIDAIRESI.Name = "colVERGIDAIRESI";
            this.colVERGIDAIRESI.Visible = true;
            this.colVERGIDAIRESI.VisibleIndex = 3;
            this.colVERGIDAIRESI.Width = 39;
            // 
            // colPOSTAKODU
            // 
            this.colPOSTAKODU.FieldName = "POSTAKODU";
            this.colPOSTAKODU.Name = "colPOSTAKODU";
            this.colPOSTAKODU.Visible = true;
            this.colPOSTAKODU.VisibleIndex = 4;
            this.colPOSTAKODU.Width = 39;
            // 
            // colADRES
            // 
            this.colADRES.FieldName = "ADRES";
            this.colADRES.Name = "colADRES";
            this.colADRES.Visible = true;
            this.colADRES.VisibleIndex = 5;
            this.colADRES.Width = 39;
            // 
            // colIL
            // 
            this.colIL.FieldName = "IL";
            this.colIL.Name = "colIL";
            this.colIL.Visible = true;
            this.colIL.VisibleIndex = 6;
            this.colIL.Width = 39;
            // 
            // colILCE
            // 
            this.colILCE.FieldName = "ILCE";
            this.colILCE.Name = "colILCE";
            this.colILCE.Visible = true;
            this.colILCE.VisibleIndex = 7;
            this.colILCE.Width = 39;
            // 
            // colTELEFON
            // 
            this.colTELEFON.FieldName = "TELEFON";
            this.colTELEFON.Name = "colTELEFON";
            this.colTELEFON.Visible = true;
            this.colTELEFON.VisibleIndex = 8;
            this.colTELEFON.Width = 39;
            // 
            // colFAX
            // 
            this.colFAX.FieldName = "FAX";
            this.colFAX.Name = "colFAX";
            this.colFAX.Visible = true;
            this.colFAX.VisibleIndex = 9;
            this.colFAX.Width = 39;
            // 
            // colMAIL
            // 
            this.colMAIL.FieldName = "MAIL";
            this.colMAIL.Name = "colMAIL";
            this.colMAIL.Visible = true;
            this.colMAIL.VisibleIndex = 10;
            this.colMAIL.Width = 39;
            // 
            // colILGILI
            // 
            this.colILGILI.FieldName = "ILGILI";
            this.colILGILI.Name = "colILGILI";
            this.colILGILI.Visible = true;
            this.colILGILI.VisibleIndex = 11;
            this.colILGILI.Width = 39;
            // 
            // colNOTLAR
            // 
            this.colNOTLAR.FieldName = "NOTLAR";
            this.colNOTLAR.Name = "colNOTLAR";
            this.colNOTLAR.Visible = true;
            this.colNOTLAR.VisibleIndex = 12;
            this.colNOTLAR.Width = 50;
            // 
            // FormFirmalar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(908, 679);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.panelControl1);
            this.Name = "FormFirmalar";
            this.Text = "FormFirmalar";
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xpCollection1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.Xpo.XPCollection xpCollection1;
        private DevExpress.XtraGrid.Columns.GridColumn colOid;
        private DevExpress.XtraGrid.Columns.GridColumn colFRMCODE;
        private DevExpress.XtraGrid.Columns.GridColumn colFRMNAME;
        private DevExpress.XtraGrid.Columns.GridColumn colVERGINO;
        private DevExpress.XtraGrid.Columns.GridColumn colVERGIDAIRESI;
        private DevExpress.XtraGrid.Columns.GridColumn colPOSTAKODU;
        private DevExpress.XtraGrid.Columns.GridColumn colADRES;
        private DevExpress.XtraGrid.Columns.GridColumn colIL;
        private DevExpress.XtraGrid.Columns.GridColumn colILCE;
        private DevExpress.XtraGrid.Columns.GridColumn colTELEFON;
        private DevExpress.XtraGrid.Columns.GridColumn colFAX;
        private DevExpress.XtraGrid.Columns.GridColumn colMAIL;
        private DevExpress.XtraGrid.Columns.GridColumn colILGILI;
        private DevExpress.XtraGrid.Columns.GridColumn colNOTLAR;
    }
}