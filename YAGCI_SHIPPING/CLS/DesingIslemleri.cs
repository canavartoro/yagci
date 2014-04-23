using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data;
using DevExpress.XtraGrid.Views.Grid;
using System.Drawing;
using DevExpress.XtraGrid.Columns;

namespace YAGCI_SHIPPING
{
    public delegate void ObjectSelected(object item, DesingEventArgs e);

    public enum Islems{
      
        Grid=0,
        VGrid=1,
        Label=2,
        Text=3,
        Memo=4,
        Grup=5,
        SabitMetinler=6,
        SabitResim = 7
    }



    class DesingIslemleri
    {
        public event ObjectSelected ItemSelected;

        public static Control LabelName { get; set; }

        public Control Parent { get; set; }

        Control eklenen = new Control();

        public  void ControlAdd(Islems Isl)
        {
            
            switch (Isl)
            { 
                case Islems.Grid:
                     GridEkle();
                    break;
                case Islems.VGrid:
                    VGridEkle();
                    break;
                case Islems.Label:
                    LabelEkle();
                    break;
                case Islems.Text:
                    TextEkle();
                    break;
                case Islems.Memo:
                    MTextEkle();
                    break;
                case Islems.Grup:
                    break;
                case Islems.SabitMetinler:
                    LabelSEkle();
                    break;
                case Islems.SabitResim:
                    IconeEkle();
                    break;
                default:
                    return;
            }


            Parent.Controls.Add(eklenen);
            eklenen.BringToFront();
            eklenen.Tag = LabelName;
           
        }

       


        public void GridEkle()
        {

            DataTable dt = new DataTable();
            dt.Columns.Add("Col1");
            dt.Columns.Add("Col2");
            dt.Columns.Add("Col3");
            dt.Columns.Add("Col4");
            dt.AcceptChanges();

            int i = 0;

            foreach (Control cc in Parent.Controls)
            {
                if (cc.GetType() == typeof(UGrid))
                    i++;
            }

            UGrid gr = new UGrid();
            gr.Name = "Tbl" + DateTime.Now.ToString("ddHHmmssff");
            gr.Location = new Point((gr.Location.X + (i * 30)), (gr.Location.Y + (i * 30)));
            gr.MeSelected += new ObjectSelected(gr_MeSelected);

            eklenen = gr;
            
            gr.gridControl1.DataSource = dt;
            gr.gridView1.OptionsView.ShowGroupPanel = false;
            gr.gridView1.AddNewRow();
            gr.gridView1.AddNewRow();
            gr.gridView1.AddNewRow();
            //gr.gridView1.OptionsBehavior.Editable = false;

            gr.BringToFront();
 
        }

        void gr_MeSelected(object item, DesingEventArgs e)
        {
            if (ItemSelected != null)
                ItemSelected(item, e);
        }

        public void VGridEkle()
        {

          
            int i = 0;

            foreach (Control cc in Parent.Controls)
            {
                if (cc.GetType() == typeof(UVGrid))
                    i++;
            }

            UVGrid gr = new UVGrid();
            gr.Name = "VG" + DateTime.Now.ToString("ddHHmmssff");
            gr.Location = new Point((gr.Location.X + (i * 30)), (gr.Location.Y + (i * 30)));
            gr.LabelName = LabelName;
            gr.MeSelected += new ObjectSelected(gr_MeSelected);

            eklenen = gr;
            

            gr.BringToFront();

           
        }

        public void LabelEkle()
        {
            int i = 0;

            foreach (Control cc in Parent.Controls)
            {
                if (cc.GetType() == typeof(ULabel))
                    i++;
            }

            ULabel gr = new ULabel();
            gr.Name = "ST" + DateTime.Now.ToString("ddHHmmssff");
            gr.Location = new Point((gr.Location.X + (i * 30)), (gr.Location.Y + (i * 30)));
            gr.LabelName = LabelName;
            gr.MeSelected += new ObjectSelected(gr_MeSelected);

            eklenen = gr;
        
            gr.BringToFront();


        }

        public void TextEkle()
        {
            int i = 0;

            foreach (Control cc in Parent.Controls)
            {
                if (cc.GetType() == typeof(UText))
                    i++;
            }

            UText gr = new UText();
            gr.Name = "TXT" + DateTime.Now.ToString("ddHHmmssff");
            gr.Location = new Point((gr.Location.X + (i * 30)), (gr.Location.Y + (i * 30)));
            gr.LabelName = LabelName;

            eklenen = gr;

            gr.BringToFront();


        }

        public void MTextEkle()
        {
            int i = 0;

            foreach (Control cc in Parent.Controls)
            {
                if (cc.GetType() == typeof(UMText))
                    i++;
            }

            UMText gr = new UMText();
            gr.Name = "ME" + DateTime.Now.ToString("ddHHmmssff");
            gr.Location = new Point((gr.Location.X + (i * 30)), (gr.Location.Y + (i * 30)));
            gr.LabelName = LabelName;
            gr.MeSelected += new ObjectSelected(gr_MeSelected);

            eklenen = gr;

            gr.BringToFront();


        }

        public void LabelSEkle()
        {
            int i = 0;

            foreach (Control cc in Parent.Controls)
            {
                if (cc.GetType() == typeof(ULabels))
                    i++;
            }

            ULabels gr = new ULabels();
            gr.Name = "STL" + DateTime.Now.ToString("ddHHmmssff");
            gr.Location = new Point((gr.Location.X + (i * 30)), (gr.Location.Y + (i * 30)));
            gr.LabelName = LabelName;
            gr.MeSelected += new ObjectSelected(gr_MeSelected);

            eklenen = gr;

            gr.BringToFront();


        }

        public void IconeEkle()
        {
            int i = 0;

            foreach (Control cc in Parent.Controls)
            {
                if (cc.GetType() == typeof(UIcone))
                    i++;
            }

            UIcone gr = new UIcone();
            gr.Name = "SRS" + DateTime.Now.ToString("ddHHmmssff");
            gr.Location = new Point((gr.Location.X + (i * 30)), (gr.Location.Y + (i * 30)));            
            gr.MeSelected += new ObjectSelected(gr_MeSelected);

            eklenen = gr;

            gr.BringToFront();


        }
    }

    public class DesingEventArgs : EventArgs
    {
        public DesingEventArgs()
        { 
        }

        public DesingEventArgs(DevExpress.XtraEditors.Repository.RepositoryItemComboBox item)
        {
            this.ItemComboBox = item;
        }

        public DevExpress.XtraEditors.Repository.RepositoryItemComboBox ItemComboBox { get; set; }
    }
}
