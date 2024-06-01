using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SocialMediaFreelas.Frontend.Dtos;
using SocialMediaFreelas.Frontend.Enums;

namespace SocialMediaFreelas.Frontend.Filters
{
    public class RestrictedAdminPage : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            string? userSession = context.HttpContext.Session.GetString("userSessionLogged");

            if (string.IsNullOrEmpty(userSession))
                context.Result = new RedirectToRouteResult(new RouteValueDictionary { { "controller", "Login" }, { "action", "index" } });
            else
            {
                UserDTO? user = JsonConvert.DeserializeObject<UserDTO>(userSession);
                if (user == null)
                    context.Result = new RedirectToRouteResult(new RouteValueDictionary { { "controller", "Login" }, { "action", "index" } });

                if (user.Role != EUserRole.Admin)
                    context.Result = new RedirectToRouteResult(new RouteValueDictionary { { "controller", "Login" }, { "action", "index" } });
            }

            base.OnActionExecuting(context);
        }
    }
}
