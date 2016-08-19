using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cerberus.Controllers
{
    public class DirectiveTemplatesController : Controller
    {
        // GET: DirectiveTemplates
        public ActionResult Index()
        {
            return PartialView();
        }

        public ActionResult LightComboBox()
        {
            return PartialView();
        }
    }
}