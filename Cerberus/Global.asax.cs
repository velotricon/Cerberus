using Cerberus.DataAccessLayer;
using Cerberus.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Cerberus
{
    public class MvcApplication : System.Web.HttpApplication
    {
        public object IdentityManager { get; private set; }

        private void OnApplicationStartup()
        {
            AuthManager auth_manager = new AuthManager();
            auth_manager.UpdataMainRoles();
            MainContext context = new MainContext();
            CultureManager culture_manager = new CultureManager(context);
            culture_manager.InitBasicCultures();
            //TranslationManager translation_manager = new TranslationManager(context);

        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            this.OnApplicationStartup();
        }
    }
}
