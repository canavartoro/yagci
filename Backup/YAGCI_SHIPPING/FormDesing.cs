using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid;
using DevExpress.XtraEditors;
using DevExpress.Xpo;
using DevExpress.Data.Filtering;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraVerticalGrid;

namespace YAGCI_SHIPPING
{
    public partial class FormDesing : Gui.BaseForm
    {
        public FormDesing()
        {
            InitializeComponent();


            DesingIslemleri.LabelName = lblControlName;
            
        }

        public Formlar.FormAnaEkran FrmAnaEkran { get; set; }

        object selectedObj = null;
        DesingEventArgs argsObj = null;
        DesingIslemleri islemClass = new DesingIslemleri();

        public int FORMID { get; set; }

        public string baslik { get; set; }


        #region 
        private void btnSil_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            foreach (Control cc in pnlDesing.Controls)
            {
                if (cc.Name == lblControlName.Text)
                    cc.Dispose();
            }
        }

        private void btnDokAssaa_Click(object sender, EventArgs e)
        {
            foreach (Control cc in pnlDesing.Controls)
            {
                if (cc.Name == lblControlName.Text)
                    cc.Dock = DockStyle.None;
            }
        }

        private void btnDokYukari_Click(object sender, EventArgs e)
        {
            foreach (Control cc in pnlDesing.Controls)
            {
                if (cc.Name == lblControlName.Text)
                    cc.Dock = DockStyle.Top;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            foreach (Control cc in pnlDesing.Controls)
            {
                if (cc.Name==lblControlName.Text)
                    cc.Dock = DockStyle.Fill;
            }
        }

        private void btnDokSag_Click(object sender, EventArgs e)
        {
            foreach (Control cc in pnlDesing.Controls)
            {
                if (cc.Name == lblControlName.Text)
                    cc.Dock = DockStyle.Right;
            }
        }

        private void btnDokSol_Click(object sender, EventArgs e)
        {
            foreach (Control cc in pnlDesing.Controls)
            {
                if (cc.Name == lblControlName.Text)
                    cc.Dock = DockStyle.Left;
            }
        }

        private void btnDokAssaaa_Click(object sender, EventArgs e)
        {
            foreach (Control cc in pnlDesing.Controls)
            {
                if (cc.Name == lblControlName.Text)
                    cc.Dock = DockStyle.Bottom;
            }
        }
        #endregion


        private void btnGrid_Click(object sender, EventArgs e)
        {
            //DesingIslemleri iii = new DesingIslemleri();
            //iii.Parent = pnlDesing;
            //iii.ControlAdd(Islems.Grid);
            islemClass.ControlAdd(Islems.Grid);
        }

        private void btnRow_Click(object sender, EventArgs e)
        {
            //DesingIslemleri iii = new DesingIslemleri();
            //iii.Parent = pnlDesing;
            //iii.ControlAdd(Islems.VGrid);
            islemClass.ControlAdd(Islems.VGrid);
        }

        private void btnLabel_Click(object sender, EventArgs e)
        {
            //DesingIslemleri iii = new DesingIslemleri();
            //iii.Parent = pnlDesing;
            //iii.ControlAdd(Islems.Label);
            islemClass.ControlAdd(Islems.Label);
        }

        private void btnText_Click(object sender, EventArgs e)
        {
            //DesingIslemleri iii = new DesingIslemleri();
            //iii.Parent = pnlDesing;
            //iii.ControlAdd(Islems.Text);
            islemClass.ControlAdd(Islems.Text);
        }

        private void btnMemoText_Click(object sender, EventArgs e)
        {
            //DesingIslemleri iii = new DesingIslemleri();
            //iii.Parent = pnlDesing;
            //iii.ControlAdd(Islems.Memo);
            islemClass.ControlAdd(Islems.Memo);
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {

                if (barItmFormName.EditValue == null || barItmFormName.EditValue.ToString() == "")
                    throw new Exception("Lütfen tasarlanan forma bir isim giriniz..");

                var row = new XPCollection<Data.Tables.FORMLAR>(DB.XP.Crs,
                    CriteriaOperator.Parse(" AD = (?) ", barItmFormName.EditValue.ToString()));

                Data.Tables.FORMLAR nfr = null;

                if (row == null || row.Count() < 1)
                {
                    #region yeni
                    if (new Formlar.Popup.Secim()
                    {
                        SetData = new XPCollection<Data.Tables.FORMLAR>(DB.XP.Crs, CriteriaOperator.Parse(" USTID = 0 ")).ToArray(),
                        VisibleColumns = new string[] { "BASLIK", "AD" }
                    }.ShowDialog() == DialogResult.OK)
                    {
                        Data.Tables.FORMLAR frm = Kls.Gnl.SelectedRow as Data.Tables.FORMLAR;

                        nfr = new YAGCI_SHIPPING.Data.Tables.FORMLAR(DB.XP.Crs);
                        nfr.AD = barItmFormName.EditValue.ToString();
                        nfr.BASLIK = barItmFormName.EditValue.ToString();
                        nfr.NAMESPACE = "YAGCI_SHIPPING.Formlar.FormGENERIC";
                        nfr.USTID = frm.Oid;
                        nfr.RESIM = "_1377905062_stock_task";

                        Data.Tables.KULLANICIGRUP kulgrup = DB.XP.Crs.GetObjectByKey<Data.Tables.KULLANICIGRUP>(1);

                        nfr.KULLANICIGRUPDETAYLARIs.Add(new Data.Tables.KULLANICIGRUPDETAYLARI(DB.XP.Crs)
                        {
                            GRUPID = kulgrup
                        });

                        nfr.Save();

                        if (FrmAnaEkran != null)
                            FrmAnaEkran.Refresh12();

                    }
                    #endregion
                }
                else
                {
                    DB.XP.Crs.ExecuteNonQuery(" DELETE FROM GENERIC WHERE FORMID = " + row.First().Oid);
                    nfr = row.First();
                }

                if (nfr == null)
                {
                    Kls.Dlg.Hata("Form secilmedi!");
                    return;
                }

                foreach (Control c in pnlDesing.Controls)
                {
                    if (!c.GetType().ToString().Replace("YAGCI_SHIPPING.", "").StartsWith("U"))
                        continue;

                    DB.Control cnt = (DB.Control)Enum.Parse(typeof(DB.Control), c.GetType().ToString().Split('.')[1]);

                    switch (cnt)
                    {
                        case YAGCI_SHIPPING.DB.Control.UGrid:
                            UGrid((UGrid)c, nfr);
                            break;
                        case YAGCI_SHIPPING.DB.Control.ULabel:
                            ULabel((ULabel)c, nfr);
                            break;
                        case YAGCI_SHIPPING.DB.Control.UMText:
                            UMText((UMText)c, nfr);
                            break;
                        case YAGCI_SHIPPING.DB.Control.UText:
                            UText((UText)c, nfr);
                            break;
                        case YAGCI_SHIPPING.DB.Control.UVGrid:
                            UVGrid((UVGrid)c, nfr);
                            break;
                        case YAGCI_SHIPPING.DB.Control.ULabels:
                            ULabels((ULabels)c, nfr);
                            break;
                        case YAGCI_SHIPPING.DB.Control.UIcone:
                            UIcone((UIcone)c, nfr);
                            break;
                        default:
                            return;
                    }
                }

                Kls.Dlg.Bilgi("İşlem tamamlandı..");
            }
            catch (Exception ee)
            {
                Kls.Dlg.Hata(ee);
            }
        }

        void UGrid(UGrid ug, YAGCI_SHIPPING.Data.Tables.FORMLAR FORM)
        {
            Data.Tables.GENERIC g = new Data.Tables.GENERIC(DB.XP.Crs);
            g.FORMNAME = barItmFormName.EditValue.ToString();
            g.COLCOUNT = ug.gridView1.Columns.Count;
            g.REPOITEMS = "";
            g.COLUMNS = "";
            g.CONTROLYYPE = YAGCI_SHIPPING.DB.Control.UGrid;
            g.ROWCOUNT = ug.gridView1.RowCount;
            g.XPOS = ug.Location.X;
            g.YPOS = ug.Location.Y;
            g.HSIZE = ug.Size.Height;
            g.WSIZE = ug.Size.Width;
            g.DOCK = ug.Dock;

            for (int i = 0; i < g.COLCOUNT; i++)
            {
                g.SIZES += ug.gridView1.Columns[i].Width + ";";
                if (ug.gridView1.Columns[i].ColumnEdit != null)
                {
                    g.COLUMNS += string.Format("{0}.{1}", ug.gridView1.Columns[i].ColumnEdit.Name, ug.gridView1.Columns[i].FieldName) + ";";
                    if (ug.gridView1.Columns[i].ColumnEdit is RepositoryItemComboBox)
                    {                        
                        RepositoryItemComboBox rp = ug.gridView1.Columns[i].ColumnEdit as RepositoryItemComboBox;
                        g.REPOITEMS += ug.gridView1.Columns[i].ColumnEdit.Name + ":";

                        foreach (string it in rp.Items)
                            g.REPOITEMS += it.Replace(",", "") + ",";

                        g.REPOITEMS += ";";
                    }
                }
                else
                    g.COLUMNS += ug.gridView1.Columns[i].FieldName + ";";
            }

            for (int i = 0; i < g.ROWCOUNT; i++)
            {
                DataRowView dv = ug.gridView1.GetRow(i) as DataRowView;
                if (dv != null)
                    g.TEXT += (dv.Row[0] == DBNull.Value || dv.Row[0] == null) ? "" : dv.Row[0].ToString()+";";
            }

            g.NAME = ug.Name;
            g.FORMID = FORM.Oid;
            g.LANDSCAPE = cmbSayfaYonu.SelectedIndex > 0;
            g.Save();             
        }

        void ULabel(ULabel ug, YAGCI_SHIPPING.Data.Tables.FORMLAR FORM)
        {
            Data.Tables.GENERIC g = new Data.Tables.GENERIC(DB.XP.Crs);
            g.FORMNAME = barItmFormName.EditValue.ToString();
         
            g.CONTROLYYPE = YAGCI_SHIPPING.DB.Control.ULabel;
          
            g.XPOS = ug.Location.X;
            g.YPOS = ug.Location.Y;
            g.HSIZE = ug.Size.Height;
            g.WSIZE = ug.Size.Width;
            g.DOCK = ug.Dock;

            g.TEXT = ug.labelControl1.Text;

            g.NAME = ug.Name;
            g.FORMID = FORM.Oid;
            g.LANDSCAPE = cmbSayfaYonu.SelectedIndex > 0;
            g.Save(); 
        }

        void ULabels(ULabels ug, YAGCI_SHIPPING.Data.Tables.FORMLAR FORM)
        {
            Data.Tables.GENERIC g = new Data.Tables.GENERIC(DB.XP.Crs);
            g.FORMNAME = barItmFormName.EditValue.ToString();

            g.CONTROLYYPE = YAGCI_SHIPPING.DB.Control.ULabels;

            g.XPOS = ug.Location.X;
            g.YPOS = ug.Location.Y;
            g.HSIZE = ug.Size.Height;
            g.WSIZE = ug.Size.Width;
            g.DOCK = ug.Dock;

            g.TEXT = ug.labelControl1.Text + ";" + ug.labelControl2.Text;

            g.NAME = ug.Name;
            g.FORMID = FORM.Oid;
            g.LANDSCAPE = cmbSayfaYonu.SelectedIndex > 0;
            g.Save();
        }

        void UIcone(UIcone ug, YAGCI_SHIPPING.Data.Tables.FORMLAR FORM)
        {
            Data.Tables.GENERIC g = new Data.Tables.GENERIC(DB.XP.Crs);
            g.FORMNAME = barItmFormName.EditValue.ToString();

            g.CONTROLYYPE = YAGCI_SHIPPING.DB.Control.UIcone;

            g.XPOS = ug.Location.X;
            g.YPOS = ug.Location.Y;
            g.HSIZE = ug.Size.Height;
            g.WSIZE = ug.Size.Width;
            g.DOCK = ug.Dock;
            g.ICONEFILE = ug.IconeData;
            g.NAME = ug.Name;
            g.FORMID = FORM.Oid;
            g.LANDSCAPE = cmbSayfaYonu.SelectedIndex > 0;
            g.Save();
        }

        void UMText(UMText ug, YAGCI_SHIPPING.Data.Tables.FORMLAR FORM)
        {
            Data.Tables.GENERIC g = new Data.Tables.GENERIC(DB.XP.Crs);
            g.FORMNAME = barItmFormName.EditValue.ToString();

            g.CONTROLYYPE = YAGCI_SHIPPING.DB.Control.UMText;

            g.XPOS = ug.Location.X;
            g.YPOS = ug.Location.Y;
            g.HSIZE = ug.Size.Height;
            g.WSIZE = ug.Size.Width;
            g.DOCK = ug.Dock;

            g.TEXT = ug.memoEdit1.Text;

            g.NAME = ug.Name;
            g.FORMID = FORM.Oid;
            g.LANDSCAPE = cmbSayfaYonu.SelectedIndex > 0;
            g.Save(); 
        }

        void UText(UText ug, YAGCI_SHIPPING.Data.Tables.FORMLAR FORM)
        {
            Data.Tables.GENERIC g = new Data.Tables.GENERIC(DB.XP.Crs);
            g.FORMNAME = barItmFormName.EditValue.ToString();

            g.CONTROLYYPE = YAGCI_SHIPPING.DB.Control.UText;

            g.XPOS = ug.Location.X;
            g.YPOS = ug.Location.Y;
            g.HSIZE = ug.Size.Height;
            g.WSIZE = ug.Size.Width;
            g.DOCK = ug.Dock;

            g.TEXT = ug.textEdit1.Text;

            g.NAME = ug.Name;
            g.FORMID = FORM.Oid;
            g.LANDSCAPE = cmbSayfaYonu.SelectedIndex > 0;
            g.Save(); 
        }

        void UVGrid(UVGrid ug, YAGCI_SHIPPING.Data.Tables.FORMLAR FORM)
        {
            Data.Tables.GENERIC g = new Data.Tables.GENERIC(DB.XP.Crs);
            g.FORMNAME = barItmFormName.EditValue.ToString();

            g.CONTROLYYPE = YAGCI_SHIPPING.DB.Control.UVGrid;
            g.ROWCOUNT = ug.vGridControl1.Rows.Count;
            g.XPOS = ug.Location.X;
            g.YPOS = ug.Location.Y;
            g.HSIZE = ug.Size.Height;
            g.WSIZE = ug.Size.Width;
            g.DOCK = ug.Dock;
            g.WSIZE1 = ug.vGridControl1.RowHeaderWidth;
            g.TEXT = "";


            for (int i = 0; i < ug.vGridControl1.Rows.Count; i++)
                g.REPOITEMS += ug.vGridControl1.Rows[i].Properties.Caption.Replace(",", "") + "," +  ug.vGridControl1.Rows[i].Properties.RowEdit.Name + ";";

            for (int i = 0; i < ug.vGridControl1.Rows.Count; i++)
            {
                string repoTyp = ug.vGridControl1.Rows[i].Properties.RowEdit.Name;

                if (repoTyp.IndexOf("ComboBox") > -1)
                {
                    RepositoryItemComboBox rp = ug.vGridControl1.Rows[i].Properties.RowEdit as RepositoryItemComboBox;
                    g.TEXT += ug.vGridControl1.Rows[i].Properties.RowEdit.Name + ":";

                    foreach (string it in rp.Items)
                        g.TEXT += it.Replace(",", "") + ",";

                    g.TEXT += ";";
                }
                else if (repoTyp.IndexOf("DateEdit") > -1)
                {
                    RepositoryItemDateEdit rp = ug.vGridControl1.Rows[i].Properties.RowEdit as RepositoryItemDateEdit;
                    g.TEXT += ug.vGridControl1.Rows[i].Properties.RowEdit.Name + ":";
                    g.TEXT += " ,";
                    g.TEXT += ";";
                }
                else if (repoTyp.IndexOf("TextEdit") > -1)
                {
                    RepositoryItemTextEdit rp = ug.vGridControl1.Rows[i].Properties.RowEdit as RepositoryItemTextEdit;
                    g.TEXT += ug.vGridControl1.Rows[i].Properties.RowEdit.Name + ":";
                    g.TEXT += ug.vGridControl1.Rows[i].Properties.Value == null ? "" : ug.vGridControl1.Rows[i].Properties.Value.ToString();
                    g.TEXT += ";";
                }
            }

            g.NAME = ug.Name;
            g.FORMID = FORM.Oid;
            g.LANDSCAPE = cmbSayfaYonu.SelectedIndex > 0;
            g.Save();

        }

        private void FormDesing_Load(object sender, EventArgs e)
        {
            barItmFormName.Enabled = YAGCI_SHIPPING.Kls.Lisans.LISANSLI;
            if (!barItmFormName.Enabled) barItmFormName.EditValue = "Demo Form";

            islemClass.Parent = pnlDesing;
            islemClass.ItemSelected += new ObjectSelected(islemClass_ItemSelected);

            if (FORMID < 1) return;            

            XPCollection<Data.Tables.GENERIC> 
                rows = new XPCollection<Data.Tables.GENERIC>(DB.XP.Crs,
                CriteriaOperator.Parse(" FORMID = (?) ", this.FORMID));                       

              foreach (Data.Tables.GENERIC g in rows)
              {
                  barItmFormName.EditValue = this.baslik;

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

        void islemClass_ItemSelected(object item, DesingEventArgs e)
        {
            if (object.ReferenceEquals(item, null)) return;            

            if (item is Control)
            {
                lblControlName.Text = ((Control)item).Name;
            }

            if (!object.ReferenceEquals(e, null) && !object.ReferenceEquals(e.ItemComboBox, null))
            {
                StringBuilder sb = new StringBuilder();
                foreach (var itm in e.ItemComboBox.Items)
                {
                    sb.AppendLine(itm.ToString());
                }
                memoEdit1.Text = sb.ToString();
            }

            //if (!object.ReferenceEquals(e, null) && !object.ReferenceEquals(e.ItemDataColumn, null))
            //{
            //    textBaslik.Text = e.ItemDataColumn.FieldName;
            //}

            selectedObj = item;
            argsObj = e;
        }

        void UGrid(Data.Tables.GENERIC g)
        {
            UGrid ug = new UGrid();
            ug.Size = new Size(g.WSIZE , g.HSIZE);
            ug.Dock = g.DOCK;
            ug.Location = new Point(g.XPOS, g.YPOS);
            ug.MeSelected += new ObjectSelected(islemClass_ItemSelected);

            GridControl gc = ug.gridControl1;
            gc.Size = new Size(g.WSIZE - 10, g.HSIZE - 10);
           


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

            ug.Name = g.NAME;

            gc.DataSource = dt;             
            pnlDesing.Controls.Add(ug);
            ug.Tag = lblControlName;
            GridView vv = gc.DefaultView as GridView;
            vv.OptionsView.ShowGroupPanel = false;

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

                            DevExpress.XtraEditors.Repository.RepositoryItemComboBox dtCmb = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
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
            ULabel gc = new ULabel();
            gc.Size = new Size(g.WSIZE, g.HSIZE + 10);
            gc.Location = new Point(g.XPOS, g.YPOS);
            gc.Dock = g.DOCK;
            gc.MeSelected += new ObjectSelected(islemClass_ItemSelected);

            LabelControl lbl = gc.labelControl1;
            lbl.Text = g.TEXT;
            lbl.AutoSizeMode = LabelAutoSizeMode.None;
            gc.Size = new Size(g.WSIZE - 10, g.HSIZE);

            gc.Name = g.NAME;
            pnlDesing.Controls.Add(gc);
            gc.Tag = lblControlName;
        }

        void ULabels(Data.Tables.GENERIC g)
        {
            ULabels gc = new ULabels();
            gc.Size = new Size(g.WSIZE, g.HSIZE + 10);
            gc.Location = new Point(g.XPOS, g.YPOS);
            gc.Dock = g.DOCK;
            gc.Size = new Size(g.WSIZE - 10, g.HSIZE);
            gc.MeSelected += new ObjectSelected(islemClass_ItemSelected);

            LabelControl lbl = gc.labelControl1;
            lbl.Text = g.TEXT.Split(';')[0];
            lbl.AutoSizeMode = LabelAutoSizeMode.None;
            
            LabelControl lbl1 = gc.labelControl2;
            lbl1.Text = g.TEXT.Split(';')[1];
            lbl1.AutoSizeMode = LabelAutoSizeMode.None;
          

            gc.Name = g.NAME;
            pnlDesing.Controls.Add(gc);
            gc.Tag = lblControlName;
        }

        void UMText(Data.Tables.GENERIC g)
        {
            UMText gc = new UMText();
            gc.Size = new Size(g.WSIZE, g.HSIZE);
            gc.Location = new Point(g.XPOS, g.YPOS);
            gc.Dock = g.DOCK;
            gc.MeSelected += new ObjectSelected(islemClass_ItemSelected);

            GroupControl lbl = gc.groupControl1;
            lbl.Text = g.TEXT;            
            lbl.Size = new Size(g.WSIZE - 10, g.HSIZE - 10);

            gc.Name = g.NAME;
            pnlDesing.Controls.Add(gc);
            gc.Tag = lblControlName;
        }

        void UText(Data.Tables.GENERIC g)
        {

            UText gc = new UText();
            gc.Size = new Size(g.WSIZE, g.HSIZE + 10);
            gc.Location = new Point(g.XPOS, g.YPOS);
            gc.Dock = g.DOCK;
            gc.MeSelected += new ObjectSelected(islemClass_ItemSelected);

            TextEdit lbl = gc.textEdit1;
            lbl.Text = g.TEXT;
            lbl.Properties.AutoHeight = false;
            lbl.Size = new Size(g.WSIZE - 10, g.HSIZE);

            gc.Name = g.NAME;
            pnlDesing.Controls.Add(gc);
            gc.Tag = lblControlName;
        }

        void UVGrid(Data.Tables.GENERIC g)
        {
            UVGrid uv = new UVGrid();
            uv.Size = new Size(g.WSIZE, g.HSIZE);
            uv.Dock = g.DOCK;
            uv.Location = new Point(g.XPOS, g.YPOS);
            uv.MeSelected += new ObjectSelected(islemClass_ItemSelected);

            VGridControl gc = uv.vGridControl1;
            gc.Size = new Size(g.WSIZE - 10, g.HSIZE - 10);

            gc.Rows.Clear();

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
                        #region
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
                        #endregion
                    }
                    else if (itm.IndexOf("DateEdit") > -1)
                    {
                        #region
                        DevExpress.XtraEditors.Repository.RepositoryItemDateEdit rCDt =
                             new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
 

                        rCDt.AutoHeight = false;
                        rCDt.Name = "RepositoryItemDateEdit" + (gc.Rows.Count + 1).ToString();
                        rCDt.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
                        xRow.Properties.RowEdit = rCDt;
                        #endregion
                    }
                    else if (itm.IndexOf("TextEdit") > -1)
                    {
                        #region
                        DevExpress.XtraEditors.Repository.RepositoryItemTextEdit rcTxt =
                             new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();

                        rcTxt.AutoHeight = false;
                        rcTxt.Name = "RepositoryItemTextEdit" + (gc.Rows.Count + 1).ToString();
                        xRow.Properties.RowEdit = rcTxt;
                        #endregion
                    }
                }

                gc.Rows.Add(xRow);
                gc.RecordWidth = 1200;
                gc.RowHeaderWidth = g.WSIZE1;
            }

            uv.Name = gc.Name;
            pnlDesing.Controls.Add(uv);
            uv.Tag = lblControlName;

        }

        void UIconeLoad(Data.Tables.GENERIC g)
        {
            UIcone gc = new UIcone();
            gc.Size = new Size(g.WSIZE, g.HSIZE);
            if (g.DOCK != DockStyle.None)
                gc.Dock = g.DOCK;
            else
                gc.Location = new Point(g.XPOS, g.YPOS);
            gc.IconeData = g.ICONEFILE;
            gc.MeSelected += new ObjectSelected(islemClass_ItemSelected);
            pnlDesing.Controls.Add(gc);
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            //DesingIslemleri iii = new DesingIslemleri();
            //iii.Parent = pnlDesing;
            //iii.ControlAdd(Islems.SabitMetinler);
            islemClass.ControlAdd(Islems.SabitMetinler);
        }

        private void memoEdit1_Leave(object sender, EventArgs e)
        {
            ComboSetle();
        }

        private void ComboSetle()
        {
            if (!object.ReferenceEquals(argsObj, null) && !object.ReferenceEquals(argsObj.ItemComboBox, null))
            {
                argsObj.ItemComboBox.Items.Clear();
                argsObj.ItemComboBox.Items.AddRange(memoEdit1.Text.Replace("\n", "").Split('\r'));
                //if (!object.ReferenceEquals(selectedObj, null)) ((UVGrid)selectedObj).Invalidate();
            }
        }

        private void pnlDesing_MouseEnter(object sender, EventArgs e)
        {
        }

        private void memoEdit1_KeyUp(object sender, KeyEventArgs e)
        {
           ComboSetle();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            islemClass.ControlAdd(Islems.SabitResim);
        }


    }
}
