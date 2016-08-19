using Cerberus.AbstractClasses;
using Cerberus.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cerberus.DataAccessLayer
{
    public class TranslationManager : AbstractManager
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Text">Text to be translated</param>
        /// <param name="LangCode">Two letter, lower case lang code</param>
        /// <param name="TranslatedText">Translation value</param>
        public void AddOrUpdateTranslation(string Text, string LangCode, string TranslatedText)
        {
            if(this.context.Cultures.Any(x => x.LangCode == LangCode))
            {
                Translation translation;
                if(this.context.Translations.Any(x=>x.Text == Text && x.LangCode==LangCode))
                {
                    translation = this.context.Translations.Where(x => x.Text == Text && x.LangCode == LangCode).First();
                }
                else
                {
                    translation = new Translation() { Text = Text, LangCode = LangCode };
                    this.context.Translations.Add(translation);
                }
                translation.TranslatedText = TranslatedText;
            }
            else
            {
                throw new Exception("Provided LangCode could not be found in Cultures table");
            }
        }

        public string GetTranslation(string Text, string LangCode)
        {
            string result = this.context.Translations.Where(x => x.Text == Text && x.LangCode == LangCode).Select(x => x.TranslatedText).First();
            return result;
        }

        public TranslationManager(MainContext Context) : base(Context) { }
    }
}