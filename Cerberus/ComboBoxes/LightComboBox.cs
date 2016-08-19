using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cerberus.ComboBoxes
{
    public class LightComboBox
    {
        public string IdColumnName { get; set; }
        public string ViewColumnName { get; set; }
        public IEnumerable<LightComboBoxRow> Items { get; set; }
    }
}