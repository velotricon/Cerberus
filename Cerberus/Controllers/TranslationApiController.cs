using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Cerberus.Attributes;
using System.Web.Http.Description;
using Cerberus.Models;
using Cerberus.DataAccessLayer;

namespace Cerberus.Controllers
{
    public class TranslationApiController : ApiController
    {
        [SuperUserAccessApi]
        [ResponseType(typeof(void))]   
        public IHttpActionResult Add(Translation TranslationObj)
        {
            try
            {
                MainContext context = new MainContext();
                TranslationManager translation_manager = new TranslationManager(context);
                translation_manager.AddOrUpdateTranslation(TranslationObj.Text, TranslationObj.LangCode, TranslationObj.TranslatedText);
                context.SaveChanges();
            }
            catch(Exception ex)
            {
                throw new Exception();
            }

            return Ok();
        }
    }
}
