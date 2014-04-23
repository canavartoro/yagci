using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace YAGCI_SHIPPING.Formlar
{
    public partial class FormPrint : Gui.BaseForm
    {
        public FormPrint()
        {
            InitializeComponent();
        }

        public Data.Tables.FORMGENERIC fG { get; set; }
        public int FORMID { get; set; }

        private void FormPrint_Load(object sender, EventArgs e)
        {
            XtraReport1 rpr = new XtraReport1();
            rpr.fG = this.fG;
            rpr.FORMID = this.FORMID;
            pC1.PrintingSystem = rpr.PrintingSystem;
            rpr.CreateDocument();


            //pC1.ExecCommand(DevExpress.XtraPrinting.PrintingSystemCommand.ShowFirstPage);
            //pC1.ExecCommand(DevExpress.XtraPrinting.PrintingSystemCommand.View);
            //pC1.ExecCommand(DevExpress.XtraPrinting.PrintingSystemCommand.Scale, new object[] { 1 });
            //pC1.PrintingSystem.PageSettings.Landscape = true;
            //pC1.PrintingSystem.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.A4;      
        }
    }
}
