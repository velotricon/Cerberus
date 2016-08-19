using Cerberus.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace Cerberus.Attributes
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public class SuperUserAccessAttribute : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            if (httpContext.User.Identity.IsAuthenticated)
            {
                ClaimsIdentity identity = httpContext.User.Identity as ClaimsIdentity;
                Claim user_id_claim = identity.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier);
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
    }
}