using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cerberus.Grids
{
    public class Grid
    {
        public bool AllowEdit { get; set; }
        public bool CheckboxColumnVisible { get; set; }
        public string ViewName { get; set; }
        public GridColumn[] Columns { get; set; }
        //public string[] ColumnNames { get; set; }
        //public string[] ColumnTranslations { get; set; }
        public int TotalRowsCount { get; set; }
        public GridRow[] Rows { get; set; }
    }
}