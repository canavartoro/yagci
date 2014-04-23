using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.Xpo;

namespace YAGCI_SHIPPING.Data.Views
{
   
    public class RepoItem
    {
        public int RowNo { get; set; }
        public int ColNo { get; set; }        

        public string RepoItemName { get; set; }
        public string RepoItemValue { get; set; }

        public string RepoType { get; set; }

        public string ContentName { get; set; }
        public string ContentType { get; set; }
    }


}
