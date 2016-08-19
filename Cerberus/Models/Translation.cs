using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Cerberus.Models
{
    public class Translation
    {
        [Key]
        public int Id { get; set; }
        public string Text { get; set; }
        public string LangCode { get; set; }
        public string TranslatedText { get; set; }
    }
}