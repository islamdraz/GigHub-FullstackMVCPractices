using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace Gighub.Test.Extensions
{
    public static class ControllerExtension
    {
        public static void MockCurrentUser(this ApiController controller, string userId, string userName)
        {
            var identity = new GenericIdentity(userName);

            identity.AddClaim(
                new Claim("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name", userName));
            identity.AddClaim(
                new Claim("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier", userId));

            var principal = new GenericPrincipal(identity, null);

            controller.User = principal;
        }

        public static void MockCurrentUser(this Controller controller, string userId, string userName)
        {
            var identity = new GenericIdentity(userName);

            identity.AddClaim(
                new Claim("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name", userName));
            identity.AddClaim(
                new Claim("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier", userId));

            controller.ControllerContext = new ControllerContext
            {
                HttpContext = new MockHttpContext
                {
                    User = new GenericPrincipal(identity, null)
                }
            };
        }


    }

    public class MockHttpContext : HttpContextBase
    {
        public override IPrincipal User { get; set; }
    }
}
