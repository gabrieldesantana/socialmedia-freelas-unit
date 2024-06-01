using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SocialMediaFreelas.Frontend.Helpers;

namespace SocialMediaFreelas.Pages.Shared.Top
{
    public class DefaultModel : PageModel
    {
        private readonly ISessao _sessao;
        public DefaultModel(ISessao sessao)
        {
            _sessao = sessao;
        }
        public IActionResult OnPost()
        {
            _sessao.RemoveUserSession();
            return RedirectToPage("../");
        }
    }
}
