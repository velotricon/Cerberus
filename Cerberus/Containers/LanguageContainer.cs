using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cerberus.Containers
{
    public class LanguageContainer
    {
        public string LangCode { get; set; }//Jak to oznaczyć jako [PrimaryKey]?... Jak zrobić, żeby to było niepowtarzalne?
        public string LangName { get; set; }
    }
}