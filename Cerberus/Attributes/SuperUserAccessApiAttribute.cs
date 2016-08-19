using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Security.Claims;
using System.Web.Http.Controllers;
using Cerberus.DataAccessLayer;

namespace Cerberus.Attributes
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public class SuperUserAccessApiAttribute : AuthorizeAttribute
    {
        protected override bool IsAuthorized(HttpActionContext actionContext)
        {
            var principal = actionContext.RequestContext.Principal as ClaimsPrincipal;
            if (principal.Identity.IsAuthenticated)
            {
                var identity = principal.Identity as ClaimsIdentity;
                var user_id_claim = identity.Claims.First(x => x.Type == ClaimTypes.NameIdentifier);
                AuthManager auth_manager = new AuthManager();
                bool is_super_user = auth_manager.HasSufficientRole(user_id_claim.Value, "SuperUser");
                if(is_super_user)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        protected override void HandleUnauthorizedRequest(HttpActionContext actionContext)
        {
            actionContext.Response = new System.Net.Http.HttpResponseMessage(System.Net.HttpStatusCode.NotFound); //NotFound dla zmyłki xD
        }
    }
}