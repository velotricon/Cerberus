using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cerberus.Containers
{
    public class GridDescriptorContainer
    {
        public string GridName { get; set; }
        public string GridNameTranslation { get; set; }
        public GridColumnContainer[] Columns { get; set; }
        public int TotalRowsCount { get; set; }
        //Tutaj może jakieś filtry? tylko jak?
    }
}