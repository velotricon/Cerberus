using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Cerberus.Models
{
    public class Culture
    {
        public string Country { get; set; }
        public string CountryCode { get; set; }
        public string CountryCodeLong { get; set; }
        public string Language { get; set; }
        public string LangCode { get; set; }
        public string LangCodeLong { get; set; }

        [Key]
        public string CultureInfoCode { get; set; }
    }
}