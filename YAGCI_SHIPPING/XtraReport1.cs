using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using DevExpress.Data.Filtering;
using DevExpress.Xpo;

namespace YAGCI_SHIPPING
{
    public partial class XtraReport1 : DevExpress.XtraReports.UI.XtraReport
    {
        public XtraReport1()
        {
            InitializeComponent();

            
        }

        public Data.Tables.FORMGENERIC fG { get; set; }

        public int FORMID { get; set; }

        private void XtraReport1_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            try
            {
                XRTable tbl1 = new XRTable();
                List<XRTable> tblst = new List<XRTable>();

            
                var rows = new XPCollection<Data.Tables.GENERIC>(DB.XP.Crs,
                   CriteriaOperator.Parse(" FORMID = (?) ", this.FORMID));

               
                foreach (Data.Tables.GENERIC lbl in rows.Where(x => x.CONTROLYYPE == YAGCI_SHIPPING.DB.Control.ULabels))
                {
                    XRLabel lx = new XRLabel();
                    lx.Text = lbl.TEXT.Split(';')[0];
                    lx.LocationF = new PointF(0F, 0F);
                    lx.SizeF = new SizeF(300.00001F, 3300.00001F);
   
                    XRLabel lx1 = new XRLabel();
                    lx1.LocationF = new PointF(680.00001F, 0F);
                    lx1.Text = lbl.TEXT.Split(';')[1];
                    lx1.SizeF = new SizeF(300.00001F, 3300.00001F);

                    Detail.Controls.Add(lx);
                    Detail.Controls.Add(lx1);
                }


                foreach (Data.Tables.GENERIC lbl in rows.Where(x => x.CONTROLYYPE == YAGCI_SHIPPING.DB.Control.ULabel))
                {
                    XRLabel lxt = new XRLabel();
                    lxt.Text = lbl.TEXT;
                    lxt.LocationF = new PointF(5F, 30.00010F);
                    lxt.SizeF = new SizeF(745.00001F, 10F);
                    lxt.BackColor = Color.GhostWhite;
                    lxt.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
                    Detail.Controls.Add(lxt);
                }

                List<XRTableRow> xRow = new List<XRTableRow>();

                foreach (Data.Tables.GENERIC lbl in rows.Where(x => x.CONTROLYYPE == YAGCI_SHIPPING.DB.Control.UVGrid))
                {
                    string[] rws = lbl.REPOITEMS.Split(';');

                    XRTable rTable = new XRTable();
                    List<Data.Views.RepoItem> xLst = new List<Data.Views.RepoItem>();

                    if (fG != null)
                        xLst = JsonConvert.DeserializeObject<List<Data.Views.RepoItem>>(fG.Values);

                    for (int x = 0; x < rws.Length; x++)
                    {
                        if (rws[x].Trim() == "") continue;

                        string[] cll = rws[x].Trim().Split(',');

                        XRTableRow rw = new XRTableRow();
                        XRTableCell celBas = new XRTableCell();
                        celBas.Text = cll[0];
                        celBas.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));

                        /*
                        var dbList =
                        new XPCollection<Data.Tables.FORMGENERIC>(
                            DB.XP.Crs,
                            CriteriaOperator.Parse(" FORMNAME = (?) ", lbl.FORMNAME));
                        */
                        //new Data.Tables.FORMGENERIC().FORMNAME

                        if (xLst.Count() < 1) continue;

                        var sx = xLst.Where(c => c.ContentType == "VGridControl" && c.RepoItemName == cll[1]);
                         
                        XRTableCell celBas1 = new XRTableCell();
                        celBas1.Text = sx.Count() > 0 ? sx.First().RepoItemValue : "";


                      
                        

                        rw.Cells.Add(celBas);
                        rw.Cells.Add(celBas1);
                        
                        xRow.Add(rw);

                        rTable.Rows.Add(rw);
                    }

                    rTable.SizeF = new SizeF(740.00001F, 10.00001F);
                    rTable.LocationFloat = new DevExpress.Utils.PointFloat(5.00001F, 50.00001F);
                    rTable.Borders = DevExpress.XtraPrinting.BorderSide.All;
                    
                    Detail.Controls.Add(rTable);
                }
               
                this.Landscape = rows.First().LANDSCAPE;

                if (fG == null)
                    return;

                fG.Reload();
               
                List<Data.Views.RepoItem> lst =
                 JsonConvert.DeserializeObject<List<Data.Views.RepoItem>>(fG.Values);

                List<Data.Views.RepoItem> lst1 = lst.OrderBy(x => x.ContentType).ToList();

                #region grid
                foreach (var table in lst1.Where(c => c.ContentType == "GridControl").GroupBy(x => x.ContentName))
                {
                    XRTable xrt = new XRTable();

                    XRTableRow rwBaslik = new XRTableRow();
                    rwBaslik.BackColor = Color.YellowGreen;
                    rwBaslik.Font = xrt.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));

                    Data.Views.RepoItem[] itmss = lst1.Where(a => a.ContentName == table.Key && a.RowNo == 0).ToArray();

                    string[] str = rows.Where(c => c.CONTROLYYPE == YAGCI_SHIPPING.DB.Control.UGrid).First().SIZES.Split(';');

                    int j = 0;

                    foreach (var basl in itmss)
                    {
                        XRTableCell celbas = new XRTableCell();

                        if (str[j].Trim() != "")
                            celbas.SizeF = new SizeF(float.Parse(str[j]), 0);

                        celbas.Text = basl.RepoItemName;
                        rwBaslik.Cells.Add(celbas);
                        j++;
                    }

                    xrt.Rows.Add(rwBaslik);


                    foreach (var ln in lst1.Where(a => a.ContentName == table.Key).GroupBy(c => c.RowNo).OrderBy(x => x.Key))
                    {

                        XRTableRow rw = new XRTableRow();

                        foreach (var cel in lst1.Where(a => a.ContentName == table.Key && a.RowNo == ln.Key))
                        {
                            XRTableCell cell = new XRTableCell();
                            cell.Text = cel.RepoItemValue;

                            if (str[cel.ColNo].Trim() != "")
                                cell.SizeF = new SizeF(float.Parse(str[cel.ColNo]), 0);

                            rw.Cells.Add(cell);

                            if (cel.ColNo == 0)
                                cell.BackColor = Color.YellowGreen;

                        }
                        xrt.Rows.Add(rw);
                    }


                    float fl = (tblst.Count() * 220.00001F);

                    xrt.LocationFloat = new DevExpress.Utils.PointFloat(10.00001F, 200.00001F + fl);
                    xrt.Borders = DevExpress.XtraPrinting.BorderSide.All;
                    xrt.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));

                    if (this.Landscape)
                        xrt.SizeF = new SizeF(1100.00001F, 10.00001F);
                    else
                        xrt.SizeF = new SizeF(725.00001F, 10.00001F);

                    xrt.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
                    tblst.Add(xrt);
                }
                #endregion

                #region
                foreach (Data.Tables.GENERIC lbl in rows.Where(x => x.CONTROLYYPE == YAGCI_SHIPPING.DB.Control.UMText))
                {
                    XRRichText rch = new XRRichText();
                    rch.LocationFloat = new DevExpress.Utils.PointFloat(10.00001F, 284.7083F);                    
                    rch.SizeF = new System.Drawing.SizeF(756F, 108.4167F);

                    if (lst1.Where(x => x.RepoType == "MemoEdit").Count() > 0)
                    {
                        rch.Text = lst1.Where(x => x.RepoType == "MemoEdit").First().RepoItemValue;
                    }

                    rch.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));                    
                    Detail.Controls.Add(rch);
                }
                #endregion

                //tbl1.LocationFloat = new DevExpress.Utils.PointFloat(10.00001F, 10.00001F);
                Detail.Controls.AddRange(tblst.ToArray());
            }
            catch (Exception ee)
            {
                Kls.Dlg.Hata(ee.Message);
            }
        }
    }
}
