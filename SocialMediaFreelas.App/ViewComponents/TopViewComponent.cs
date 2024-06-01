using Microsoft.AspNetCore.Mvc;

namespace SocialMediaFreelas.ViewComponents
{
    public class TopViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}
