using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.Xpo;
using DevExpress.Data.Filtering;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraVerticalGrid;
using DevExpress.XtraEditors;
using Newtonsoft.Json;
using Newtonsoft;
using DevExpress.XtraGrid.Columns;
using System.IO;

namespace YAGCI_SHIPPING.Formlar
{
    public partial class FormGENERIC : Gui.BaseForm
    {
        public FormGENERIC()
        {
            InitializeComponent();
        }



        private void btnKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                Data.Tables.FORMGENERIC fg =
                    new Data.Tables.FORMGENERIC(DB.XP.Crs);

                fg.FORMNAME = this.Text;
                fg.KULLANICIID = Kls.Gnl.AktifKullanici.Oid;
                fg.FIRMAID = Kls.Gnl.AktifFirma.Oid;
                fg.TARIH = Kls.Gnl.GetDate;
                fg.FORM = DB.XP.Crs.GetObjectByKey<YAGCI_SHIPPING.Data.Tables.FORMLAR>(this.ID);

                List<Data.Views.RepoItem> lst = new List<Data.Views.RepoItem>();

                foreach (Control c in pnlParent.Controls)
                {
                    try
                    {
                        string xrL = c.GetType().ToString();

                        switch (xrL)
                        {
                            case "DevExpress.XtraGrid.GridControl":
                                {
                                    #region
                                    GridControl ug = (GridControl)c;
                                    GridView gv = ug.DefaultView as GridView;

                                    for (int i = 0; i < gv.RowCount; i++)
                                    {
                                        for (int ii = 0; ii < gv.Columns.Count; ii++)
                                        {
                                            GridColumn col = gv.Columns[ii];

                                            Data.Views.RepoItem rp = new Data.Views.RepoItem();
                                            rp.RowNo = i;
                                            rp.ColNo = ii;
                                            rp.RepoItemName = col.FieldName;
                                            rp.RepoItemValue = gv.GetDataRow(i)[col.FieldName].ToString();

                                            string[] ss = col.RealColumnEdit.GetType().ToString().Split('.');
                                            rp.RepoType = ss[ss.Length - 1];

                                            string[] ll = c.GetType().ToString().Split('.');
                                            rp.ContentType = ll[ll.Length - 1];
                                            rp.ContentName = ug.Name;
                                            lst.Add(rp);
                                        }
                                    }
                                    #endregion
                                }
                                break;
                            case "DevExpress.XtraEditors.PanelControl":
                                {
                                    #region
                                    foreach (Control c1 in c.Controls)
                                    {
                                        if (c1.GetType() == typeof(TextEdit) || c1.GetType() == typeof(LabelControl))
                                        {
                                            Data.Views.RepoItem rp = new Data.Views.RepoItem();
                                            rp.RepoItemName = c1.Name;
                                            rp.RepoItemValue = c1.Text;

                                            string[] kk = c1.GetType().ToString().Split('.');
                                            rp.RepoType = kk[kk.Length - 1];

                                            string[] ll = c.GetType().ToString().Split('.');
                                            rp.ContentType = ll[ll.Length - 1];
                                            rp.ContentName = c.Name;
                                            lst.Add(rp);
                                        }
                                    }
                                    #endregion
                                }
                                break;
                            case "DevExpress.XtraEditors.GroupControl":
                                {
                                    #region
                                    foreach (Control c1 in c.Controls)
                                    {
                                        if (c1.GetType() == typeof(MemoEdit))
                                        {
                                            Data.Views.RepoItem rp = new Data.Views.RepoItem();
                                            rp.RepoItemName = c1.Name;
                                            rp.RepoItemValue = c1.Text;

                                            string[] kk = c1.GetType().ToString().Split('.');
                                            rp.RepoType = kk[kk.Length - 1];

                                            string[] ll = c.GetType().ToString().Split('.');
                                            rp.ContentType = ll[ll.Length - 1];
                                            rp.ContentName = c.Name;
                                            lst.Add(rp);
                                        }
                                    }
                                    #endregion
                                }
                                break;
                            case "DevExpress.XtraVerticalGrid.VGridControl":
                                {
                                    #region
                                    VGridControl ug = (VGridControl)c;

                                    for (int i = 0; i < ug.Rows.Count; i++)
                                    {

                                        DevExpress.XtraVerticalGrid.Rows.BaseRow col = ug.Rows[i];

                                        string gttp = col.Properties.RowEdit.GetType().ToString();

                                        switch (gttp)
                                        {
                                            case "DevExpress.XtraEditors.Repository.RepositoryItemComboBox":
                                                {

                                                }
                                                break;
                                            case "DevExpress.XtraEditors.Repository.RepositoryItemTextEdit":
                                                {

                                                }
                                                break;
                                            default:
                                                break;
                                        }

                                        Data.Views.RepoItem rp = new Data.Views.RepoItem();
                                        rp.RowNo = i;
                                        rp.ColNo = 0;
                                        rp.RepoItemName = col.Properties.RowEditName;
                                        rp.RepoItemValue = col.Properties.Value == null ? "" : col.Properties.Value.ToString();

                                        rp.RepoType = col.Properties.RowEdit.GetType().ToString();


                                        rp.ContentType = "VGridControl";
                                        rp.ContentName = ug.Name;
                                        lst.Add(rp);


                                    }
                                    #endregion
                                }
                                break;
                            default:
                                break;
                        }
                    }
                    catch (Exception ee)
                    {
                        Kls.Dlg.Hata(ee);
                    }
                }


                fg.Values = JsonConvert.SerializeObject(lst);
                fg.Save();

                Kls.Dlg.Bilgi("Kayıt eklendi..");
            }
            catch (Exception ee)
            {
                Kls.Dlg.Hata(ee);
            }
        }

        private void brnArsiv_Click(object sender, EventArgs e)
        {
          
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {

        }

        private void FormGENELKART_Load(object sender, EventArgs e)
        {
            btnSil.Visible = Kls.Gnl.AktifKullanici.KULTUR == YAGCI_SHIPPING.DB.MOD.Server;

            dizaynyukle();
            
            goster();
        }

        void UGrid(Data.Tables.GENERIC g)
        {
            GridControl gc = new GridControl();
            gc.Size = new Size(g.WSIZE, g.HSIZE);            
            if (g.DOCK != DockStyle.None)
                gc.Dock = g.DOCK;
            else
                gc.Location = new Point(g.XPOS, g.YPOS);

            
            DataTable dt = new DataTable();
            string[] strs = g.COLUMNS.Split(';');

            for (int i = 0; i < strs.Length; i++)
            {
                if (strs[i].Trim() == "") continue;
                if (strs[i].IndexOf('.') > -1)
                    dt.Columns.Add(strs[i].Substring(strs[i].IndexOf('.') + 1, strs[i].Length - (strs[i].IndexOf('.') + 1)));                    
                else
                    dt.Columns.Add(strs[i]);
            }

            dt.AcceptChanges();

            string[] sx = g.TEXT.Split(';');
            string[] dx = g.REPOITEMS.Split(';');

            for (int j = 0; j < g.ROWCOUNT; j++)
            {
                DataRow dr = dt.NewRow();

                if (sx.Length > j && sx[j].Trim() != "")
                    dr[0] = sx[j];

                dt.Rows.Add(dr);
            }

            dt.AcceptChanges();
            
            gc.DataSource = dt;
            gc.Name = g.NAME;        
            pnlParent.Controls.Add(gc);

            GridView vv = gc.DefaultView as GridView;
            vv.OptionsView.ShowGroupPanel = false;
            //vv.BestFitColumns();

            #region Kolon Genislik
            int sizeOut = 0;
            string[] sizes = g.SIZES.Split(';');
            if (sizes != null && sizes.Length > 0)
            {
                for (int i = 0; i < vv.Columns.Count; i++)
                {
                    if (sizes.Length > i)
                    {
                        if (int.TryParse(sizes[i], out sizeOut))
                        {
                            vv.Columns[i].Width = sizeOut;
                        }
                    }
                    if (strs.Length > i)
                    {
                        if (strs[i].IndexOf("ComboBox") > -1)
                        {
                            string strData = "";
                            string namex = strs[i].Substring(0, strs[i].IndexOf('.'));

                            foreach (string sxs in dx)
                            {
                                if (sxs.StartsWith(namex))
                                {
                                    strData = sxs.Substring(sxs.IndexOf(':') + 1, sxs.Length - (sxs.IndexOf(':') + 1));
                                }
                            }

                            DevExpress.XtraEditors.Repository.RepositoryItemComboBox dtCmb= new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
                            dtCmb.Items.AddRange(strData.Split(','));
                            dtCmb.Name = "RepositoryItemComboBox" + (vv.Columns.Count + 1).ToString();
                            dtCmb.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
                            vv.Columns[i].ColumnEdit = dtCmb;
                        }
                    }
                }
            } 
            #endregion
            
        }

        void ULabel(Data.Tables.GENERIC g)
        {
            PanelControl gc = new PanelControl();
            gc.Size = new Size(g.WSIZE, g.HSIZE);
            if (g.DOCK != DockStyle.None)
                gc.Dock = g.DOCK;
            else
                gc.Location = new Point(g.XPOS, g.YPOS);

            LabelControl lbl = new LabelControl();
            lbl.Text = g.TEXT;
            lbl.AutoSizeMode = LabelAutoSizeMode.None;
            lbl.Dock = DockStyle.Fill;
            lbl.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            lbl.Name = g.NAME;

            gc.Name = "PNL_" + lbl.Name;
            gc.Controls.Add(lbl);
            pnlParent.Controls.Add(gc);
        }

        void UMText(Data.Tables.GENERIC g)
        {
            GroupControl gc = new GroupControl();
            gc.Size = new Size(g.WSIZE, g.HSIZE);
            if (g.DOCK != DockStyle.None)
                gc.Dock = g.DOCK;
            else
                gc.Location = new Point(g.XPOS, g.YPOS);

            MemoEdit lbl = new MemoEdit();
            lbl.Text = g.TEXT;             
            lbl.Dock = DockStyle.Fill;
            lbl.Name = g.NAME;

            gc.Controls.Add(lbl);
            pnlParent.Controls.Add(gc);
        }

        void UText(Data.Tables.GENERIC g)
        {
            PanelControl gc = new PanelControl();
            gc.Size = new Size(g.WSIZE, g.HSIZE);
            if (g.DOCK != DockStyle.None)
                gc.Dock = g.DOCK;
            else
                gc.Location = new Point(g.XPOS, g.YPOS);

            TextEdit lbl = new TextEdit();
            lbl.Text = g.TEXT;
            lbl.Properties.AutoHeight = false;
            lbl.Dock = DockStyle.Fill;
            lbl.Name = g.NAME;            
            lbl.Properties.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;

            gc.Name = "PNL_" + lbl.Name;
            gc.Controls.Add(lbl);
            pnlParent.Controls.Add(gc);
        }

        void UVGrid(Data.Tables.GENERIC g)
        {
            VGridControl gc = new VGridControl();
            gc.Size = new Size(g.WSIZE, g.HSIZE);
            if (g.DOCK != DockStyle.None)
                gc.Dock = g.DOCK;
            else
                gc.Location = new Point(g.XPOS, g.YPOS);

            string[] rows = g.REPOITEMS.Split(';');
            string[] items = g.TEXT.Split(';');

            for (int i = 0; i < g.ROWCOUNT; i++)
            {
                DevExpress.XtraVerticalGrid.Rows.EditorRow xRow = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
                xRow.Appearance.Font =
                    new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
                xRow.Appearance.Options.UseFont = true;
                xRow.Height = 25;
                xRow.Name = "xRow" + gc.Rows.Count.ToString();

                if (rows.Length > i && rows[i].Trim() != "")
                {
                    string[] ri = rows[i].Split(',');

                    string Baslik = "", itm = "";

                    if (ri.Length > 0)
                        Baslik = ri[0];

                    xRow.Properties.Caption = Baslik;

                    if (ri.Length > 1)
                        itm = ri[1];

                    if (itm.IndexOf("ComboBox") > -1)
                    {
                        DevExpress.XtraEditors.Repository.RepositoryItemComboBox rCmb =
                      new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();

                        var snc = items.Where(c => c.IndexOf(itm) > -1);

                        foreach (string s in snc)
                        {
                            string[] xx = s.Split(',');
                            foreach (string x in xx)
                            {
                                string t = x.Trim();

                                if (t == ";" || t.Trim() == "") continue;

                                if (t.IndexOf(itm) > -1)
                                    t = t.Replace(itm, "").Replace(":", "").Trim();

                                rCmb.Items.Add(t); 
                            }
                        }

                        rCmb.AutoHeight = false;
                        rCmb.Name = "RepositoryItemComboBox" + (gc.Rows.Count + 1).ToString();
                        rCmb.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
                        xRow.Properties.RowEdit = rCmb;
                    }
                    else if (itm.IndexOf("DateEdit") > -1)
                    {
                        DevExpress.XtraEditors.Repository.RepositoryItemDateEdit rDt =
                             new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();

                        rDt.AutoHeight = false;
                        rDt.Name = "RepositoryItemDateEdit" + (gc.Rows.Count + 1).ToString();
                        rDt.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
                        xRow.Properties.RowEdit = rDt;

                    }
                    else if (itm.IndexOf("TextEdit") > -1)
                    {
                        DevExpress.XtraEditors.Repository.RepositoryItemTextEdit rTxt =
                             new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();


                        var snc = items.Where(c => c.IndexOf(itm) > -1);

                        foreach (string s in snc)
                        {
                            string[] xx = s.Split(',');
                            foreach (string x in xx)
                            {
                                string t = x.Trim();

                                if (t == ";" || t.Trim() == "") continue;

                                if (t.IndexOf(itm) > -1)
                                    t = t.Replace(itm, "").Replace(":", "").Trim();

                                xRow.Properties.Value = t;
                            }
                        }

                        rTxt.AutoHeight = false;
                        rTxt.Name = "RepositoryItemTextEdit" + (gc.Rows.Count + 1).ToString();                        
                        xRow.Properties.RowEdit = rTxt;

                    }
                }

                gc.Rows.Add(xRow);
                gc.RecordWidth = 1200;
                gc.RowHeaderWidth = g.WSIZE1;
                gc.Name = g.NAME;
            }

         
            pnlParent.Controls.Add(gc);
        }

        void ULabels(Data.Tables.GENERIC g)
        {
            PanelControl gc = new PanelControl();
            gc.Size = new Size(g.WSIZE, g.HSIZE);
            if (g.DOCK != DockStyle.None)
                gc.Dock = g.DOCK;
            else
                gc.Location = new Point(g.XPOS, g.YPOS);


            LabelControl lbl1 = new LabelControl();
            lbl1.Text = g.TEXT.Split(';')[1];
            lbl1.AutoSizeMode = LabelAutoSizeMode.None;
            lbl1.Dock = DockStyle.Right;
            lbl1.Name = g.NAME + "1";
            lbl1.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;

            LabelControl lbl = new LabelControl();
            lbl.Text = g.TEXT.Split(';')[0];
            lbl.AutoSizeMode = LabelAutoSizeMode.None;
            lbl.Dock = DockStyle.Fill;
            lbl.Name = g.NAME;
            lbl.BringToFront();
         
            gc.Name = "PNL01_" + lbl.Name;
            gc.Controls.Add(lbl);
            gc.Controls.Add(lbl1);
            pnlParent.Controls.Add(gc);
        }

        void UIconeLoad(Data.Tables.GENERIC g)
        {
            PanelControl gc = new PanelControl();
            gc.Size = new Size(g.WSIZE, g.HSIZE);
            if (g.DOCK != DockStyle.None)
                gc.Dock = g.DOCK;
            else
                gc.Location = new Point(g.XPOS, g.YPOS);

            if (g.ICONEFILE != null)
            {
                PictureEdit p = new PictureEdit();
                MemoryStream ms = new MemoryStream(g.ICONEFILE);
                Image xImage = Image.FromStream(ms);
                p.Image = xImage;
                p.Dock = DockStyle.Fill;
                gc.Controls.Add(p);
                
            }
            pnlParent.Controls.Add(gc);
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            new Formlar.FormPrint() { fG = ArsivLoad, FORMID = this.ID }.ShowDialog();
        }

        private void formuDüzeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new FormDesing() { MdiParent = this.MdiParent, FORMID = this.ID, baslik = this.Text }.Show();
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            new FormDesing() { MdiParent = this.MdiParent, FORMID = this.ID, baslik = this.Text }.Show();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(((LinkLabel)sender).Text);
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(((LinkLabel)sender).Text);
        }

        public Data.Tables.FORMGENERIC ArsivLoad { get; set; }

        void dizaynyukle()
        { 
            var rows = new XPCollection<Data.Tables.GENERIC>(DB.XP.Crs,
                CriteriaOperator.Parse(" FORMID = (?) ", this.ID));

            foreach (Data.Tables.GENERIC g in rows)
            {
                try
                {
                    switch (g.CONTROLYYPE)
                    {
                        case YAGCI_SHIPPING.DB.Control.UGrid:
                            UGrid(g);
                            break;
                        case YAGCI_SHIPPING.DB.Control.ULabel:
                            ULabel(g);
                            break;
                        case YAGCI_SHIPPING.DB.Control.UMText:
                            UMText(g);
                            break;
                        case YAGCI_SHIPPING.DB.Control.UText:
                            UText(g);
                            break;
                        case YAGCI_SHIPPING.DB.Control.UVGrid:
                            UVGrid(g);
                            break;
                        case YAGCI_SHIPPING.DB.Control.ULabels:
                            ULabels(g);
                            break;
                        case YAGCI_SHIPPING.DB.Control.UIcone:
                            UIconeLoad(g);
                            break;
                        default:
                            return;
                    }
                }
                catch (Exception ee)
                {
                    Kls.Dlg.Hata(ee.Message);
                }
            }
        }

        void goster()
        {
            if (ArsivLoad == null) return;

            ArsivLoad.Reload();

            Data.Tables.FORMGENERIC fg = ArsivLoad;


            this.Text = fg.FORMNAME;

            List<Data.Views.RepoItem> lst =
             JsonConvert.DeserializeObject<List<Data.Views.RepoItem>>(fg.Values);

            List<Data.Views.RepoItem>  lst1 = lst.OrderBy(x => x.ContentType).ToList();

            try
            {
                foreach (Data.Views.RepoItem it in lst1)
                {

                    if (it.ContentType == "GridControl")
                    {
                        #region

                        Control[] cc = pnlParent.Controls.Find(it.ContentName, true);
                        if (cc.Count() > 0)
                        {
                            GridControl g1 = cc[0] as GridControl;

                            GridView gv = g1.DefaultView as GridView;
                            gv.SetRowCellValue(it.RowNo, gv.Columns[it.ColNo], it.RepoItemValue);
                        }
                        #endregion
                    }
                    else if (it.ContentType == "PanelControl")
                    {
                        /*
                         it.GetType().ToString() == "DevExpress.XtraEditors.TextEdit" || 
                             it.GetType().ToString() == "DevExpress.XtraEditors.LabelControl" || 
                             it.GetType().ToString() == "DevExpress.XtraEditors.MemoEdit"
                         */

                        #region
                        Control[] cc = pnlParent.Controls.Find(it.ContentName, true);
                        if (cc.Count() > 0)
                        {
                            foreach (Control tt in cc[0].Controls)
                            {
                                if (tt.GetType() == typeof(TextEdit) || tt.GetType() == typeof(Label) || tt.GetType() == typeof(MemoEdit))
                                {
                                    tt.Text = it.RepoItemValue;
                                }                                
                            }
                        }                        
                        #endregion
                    }
                    else if (it.ContentType == "GroupControl")
                    {
                        #region
                        Control[] cc = pnlParent.Controls.Find(it.RepoItemName, true);
                        if (cc.Count() > 0)
                        {
                            foreach (Control tt in cc)
                            {
                                if (tt.GetType() == typeof(MemoEdit))
                                {
                                    tt.Text = it.RepoItemValue;
                                }
                            }
                        }
                        #endregion
                    }
                    else if (it.ContentType == "VGridControl")
                    {
                        #region
                        Control[] cc = pnlParent.Controls.Find(it.ContentName, true);
                        if (cc.Count() > 0)
                        {
                            VGridControl vg = cc[0] as VGridControl;

                            for (int i = 0; i < vg.Rows.Count; i++)
                            {
                                if (vg.Rows[i].Properties.RowEdit.Name.IndexOf(it.RepoItemName) > -1)
                                    vg.Rows[i].Properties.Value = it.RepoItemValue;
                            }
                            
                        }

                        #endregion
                    }
                }                
            }
            catch (Exception ee)
            {
                Kls.Dlg.Hata(ee.Message);
            }

        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            try
            {
                using (UnitOfWork wrk = new UnitOfWork())
                {
                    Data.Tables.FORMLAR frm = wrk.GetObjectByKey<Data.Tables.FORMLAR>(this.ID);
                    if (frm == null)
                    {
                        Kls.Dlg.Bilgi("Form bilgisi bulunamadi!");
                        return;
                    }

                    if (Kls.Dlg.Soru(string.Format("{0} adli form silinecek onayliyor musunuz?", frm.AD)) == DialogResult.No) return;

                    if (frm.KULLANICIGRUPDETAYLARIs.Count > 0)
                    {
                        for (int i = frm.KULLANICIGRUPDETAYLARIs.Count; i > 0; i--)
                        {
                            frm.KULLANICIGRUPDETAYLARIs[i - 1].Delete();
                        }
                    }

                    frm.Delete();
                    wrk.CommitChanges();
                }

                if (this.MdiParent != null)
                {
                    ((FormAnaEkran)this.MdiParent).Formlar();
                }
                this.Close();

            }
            catch (Exception exc)
            {
                Kls.Dlg.Hata(exc);
            }
        }

    
    }
}
