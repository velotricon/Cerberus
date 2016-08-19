using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cerberus.Controllers
{
    public class SettingsController : Controller
    {
        // GET: Settings
        public ActionResult Index()
        {
            return PartialView();
        }

        public ActionResult AddTranslation()
        {
            return PartialView();
        }
    }
}