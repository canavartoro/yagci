namespace YAGCI_SHIPPING.Formlar.Popup
{
    partial class Secim
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
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.btnOnayaGonder = new DevExpress.XtraEditors.SimpleButton();
            this.btnCikis = new DevExpress.XtraEditors.SimpleButton();
            this.gcSecim = new DevExpress.XtraGrid.GridControl();
            this.gvSecim = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.btnEkle = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcSecim)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvSecim)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.btnEkle);
            this.groupControl2.Controls.Add(this.btnOnayaGonder);
            this.groupControl2.Controls.Add(this.btnCikis);
            this.groupControl2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupControl2.Location = new System.Drawing.Point(0, 422);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(918, 55);
            this.groupControl2.TabIndex = 13;
            this.groupControl2.Text = "İşlemler";
            // 
            // btnOnayaGonder
            // 
            this.btnOnayaGonder.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnOnayaGonder.Image = global::YAGCI_SHIPPING.Properties.Resources._1322777798_001_06;
            this.btnOnayaGonder.Location = new System.Drawing.Point(772, 21);
            this.btnOnayaGonder.Name = "btnOnayaGonder";
            this.btnOnayaGonder.Size = new System.Drawing.Size(144, 32);
            this.btnOnayaGonder.TabIndex = 13;
            this.btnOnayaGonder.Text = "SEÇ";
            this.btnOnayaGonder.Click += new System.EventHandler(this.btnOnayaGonder_Click);
            // 
            // btnCikis
            // 
            this.btnCikis.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnCikis.Image = global::YAGCI_SHIPPING.Properties.Resources._1370992330_quit;
            this.btnCikis.Location = new System.Drawing.Point(2, 21);
            this.btnCikis.Name = "btnCikis";
            this.btnCikis.Size = new System.Drawing.Size(102, 32);
            this.btnCikis.TabIndex = 0;
            this.btnCikis.Text = "Çıkış";
            this.btnCikis.Click += new System.EventHandler(this.btnCikis_Click);
            // 
            // gcSecim
            // 
            this.gcSecim.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcSecim.Location = new System.Drawing.Point(0, 0);
            this.gcSecim.MainView = this.gvSecim;
            this.gcSecim.Name = "gcSecim";
            this.gcSecim.Size = new System.Drawing.Size(918, 422);
            this.gcSecim.TabIndex = 14;
            this.gcSecim.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvSecim});
            // 
            // gvSecim
            // 
            this.gvSecim.GridControl = this.gcSecim;
            this.gvSecim.Name = "gvSecim";
            this.gvSecim.OptionsBehavior.Editable = false;
            this.gvSecim.OptionsDetail.EnableMasterViewMode = false;
            this.gvSecim.OptionsView.ShowAutoFilterRow = true;
            this.gvSecim.DoubleClick += new System.EventHandler(this.gvSecim_DoubleClick);
            // 
            // btnEkle
            // 
            this.btnEkle.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnEkle.Image = global::YAGCI_SHIPPING.Properties.Resources._1322517007_reports_stack;
            this.btnEkle.Location = new System.Drawing.Point(623, 21);
            this.btnEkle.Name = "btnEkle";
            this.btnEkle.Size = new System.Drawing.Size(149, 32);
            this.btnEkle.TabIndex = 14;
            this.btnEkle.Text = "EKLE";
            this.btnEkle.Visible = false;
            this.btnEkle.Click += new System.EventHandler(this.btnEkle_Click);
            // 
            // Secim
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(918, 477);
            this.Controls.Add(this.gcSecim);
            this.Controls.Add(this.groupControl2);
            this.Name = "Secim";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Secim";
            this.Load += new System.EventHandler(this.Secim_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcSecim)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvSecim)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraEditors.SimpleButton btnOnayaGonder;
        private DevExpress.XtraEditors.SimpleButton btnCikis;
        private DevExpress.XtraGrid.Views.Grid.GridView gvSecim;
        private DevExpress.XtraGrid.GridControl gcSecim;
        private DevExpress.XtraEditors.SimpleButton btnEkle;
    }
}