using Cerberus.AbstractClasses;
using Cerberus.Containers;
using Cerberus.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cerberus.DataAccessLayer
{
    public class CultureManager : AbstractManager
    {
        public List<Culture> GetBasicCultures()
        {
            List<Culture> culture_codes_list = new List<Culture>();
            culture_codes_list.Add(new Culture()
            {
                Country = "Poland",
                CountryCode = "PL",
                CountryCodeLong = "POL",
                Language = "Polish",
                LangCode = "pl",
                LangCodeLong = "pol",
                CultureInfoCode = "pl-PL"
            });
            culture_codes_list.Add(new Culture()
            {
                Country = "United States",
                CountryCode = "US",
                CountryCodeLong = "USA",
                Language = "English",
                LangCode = "en",
                LangCodeLong = "eng",
                CultureInfoCode = "en-US"
            });
            culture_codes_list.Add(new Culture()
            {
                Country = "Germany",
                CountryCode = "DE",
                CountryCodeLong = "DEU",
                Language = "German",
                LangCode = "de",
                LangCodeLong = "deu",
                CultureInfoCode = "de-DE"
            });
            return culture_codes_list;
        }

        public void InitBasicCultures()
        {
            List<Culture> culture_codes_list = this.GetBasicCultures();

            foreach (Culture c in culture_codes_list)
            {
                if(!this.context.Cultures.Any(x => x.CultureInfoCode == c.CultureInfoCode))
                {
                    this.context.Cultures.Add(c);
                }
            }

            this.context.SaveChanges();
        }

        public List<LanguageContainer> GetLanguagesList()
        {
            List<LanguageContainer> lang_list = this.context.Cultures.Select(x => new LanguageContainer() { LangCode = x.LangCode, LangName = x.Language }).Distinct().ToList();
            return lang_list;
        }

        public CultureManager(MainContext Context) : base(Context) { }
    }
}