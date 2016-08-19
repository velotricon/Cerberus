using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cerberus.Containers
{
    public class GridResultContainer
    {
        public string GridNameTranslation { get; set; }
        public string[] GridColumnNames { get; set; }
        //public GridColumnContainer[] Columns { get; set; } --> To przenieść do deskryptora grida
        public GridRowContainer[] Rows { get; set; }
    }
}