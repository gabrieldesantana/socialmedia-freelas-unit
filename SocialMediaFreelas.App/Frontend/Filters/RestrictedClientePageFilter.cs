using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using SocialMediaFreelas.Frontend.Dtos;
using SocialMediaFreelas.Frontend.Enums;

namespace SocialMediaFreelas.Frontend.Filters
{
    public class RestrictedClientePageFilter : Attribute,IPageFilter
    {
        public void OnPageHandlerSelected(PageHandlerSelectedContext context)
        {
        }

        public void OnPageHandlerExecuting(PageHandlerExecutingContext context)
        {
            string? userSession = context.HttpContext.Session.GetString("userSessionLogged");

            if (string.IsNullOrEmpty(userSession))
                context.Result = new RedirectToPageResult("/Unauthorized");
            else
            {
                UserDTO? user = JsonConvert.DeserializeObject<UserDTO>(userSession);
                if (user == null)
                    context.Result = new RedirectToPageResult("/Unauthorized");

                if (user.Role != EUserRole.Cliente)
                    context.Result = new RedirectToPageResult("/Unauthorized");
            }
        }

        public void OnPageHandlerExecuted(PageHandlerExecutedContext context)
        {
        }
    }
}
