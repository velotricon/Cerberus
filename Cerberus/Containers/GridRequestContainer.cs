using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cerberus.Containers
{
    public class GridRequestContainer
    {
        public string GridName { get; set; }
        public int RowsFrom { get; set; }
        public int RowsTo { get; set; }
        public string LocaleCode { get; set; }
    }
}