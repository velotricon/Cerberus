using Cerberus.ComboBoxes;
using Cerberus.Containers;
using Cerberus.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Script.Serialization;

namespace Cerberus.Controllers
{
    public class ComboBoxApiController : ApiController
    {
        [ResponseType(typeof(string))]
        public IHttpActionResult GetLigtComboBox(string ComboName)
        {
            string result = string.Empty;
            LightComboBox combo = null;
            
            switch (ComboName)
            {
                case "LanguageCombo":
                    combo = this.GetLanguageCombo();
                    break;
                default:
                    return NotFound();
            }

            JavaScriptSerializer serializer = new JavaScriptSerializer();
            result = serializer.Serialize(combo);
            return Ok(result);
        }

        private LightComboBox GetLanguageCombo()
        {
            LightComboBox combo_box = new LightComboBox();
            MainContext context = new MainContext();
            CultureManager culture_manager = new CultureManager(context);
            combo_box.IdColumnName = "LangCode";
            combo_box.ViewColumnName = "LangName";
            combo_box.Items = culture_manager.GetLanguagesList().Select(x => new LightComboBoxRow() { Id = x.LangCode, View = x.LangName });
            
            return combo_box;
        }
    }
}
