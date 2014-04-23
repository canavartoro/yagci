namespace YAGCI_SHIPPING
{
    partial class UMText
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
            this.memoEdit1 = new DevExpress.XtraEditors.MemoEdit();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            ((System.ComponentModel.ISupportInitialize)(this.memoEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // memoEdit1
            // 
            this.memoEdit1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.memoEdit1.EditValue = "Uzun metinler";
            this.memoEdit1.Location = new System.Drawing.Point(2, 21);
            this.memoEdit1.Name = "memoEdit1";
            this.memoEdit1.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.memoEdit1.Properties.Appearance.Options.UseFont = true;
            this.memoEdit1.Size = new System.Drawing.Size(450, 77);
            this.memoEdit1.TabIndex = 5;
            this.memoEdit1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.groupControl1_MouseUp);
            this.memoEdit1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.groupControl1_MouseMove);
            this.memoEdit1.MouseLeave += new System.EventHandler(this.groupControl1_MouseLeave);
            this.memoEdit1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.groupControl1_MouseDown);
            // 
            // groupControl1
            // 
            this.groupControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControl1.Controls.Add(this.memoEdit1);
            this.groupControl1.Location = new System.Drawing.Point(6, 6);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(454, 100);
            this.groupControl1.TabIndex = 6;
            this.groupControl1.Text = "Açıklama";
            this.groupControl1.MouseLeave += new System.EventHandler(this.groupControl1_MouseLeave);
            this.groupControl1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.groupControl1_MouseMove);
            this.groupControl1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.groupControl1_MouseDown);
            this.groupControl1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.groupControl1_MouseUp);
            // 
            // UMText
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gray;
            this.Controls.Add(this.groupControl1);
            this.Name = "UMText";
            this.Size = new System.Drawing.Size(466, 113);
            ((System.ComponentModel.ISupportInitialize)(this.memoEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public DevExpress.XtraEditors.GroupControl groupControl1;
        public DevExpress.XtraEditors.MemoEdit memoEdit1;


    }
}
