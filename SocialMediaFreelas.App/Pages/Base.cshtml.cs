using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SocialMediaFreelas.Frontend.Helpers;

namespace SocialMediaFreelas.Pages
{
    public class BaseModel : PageModel
    {

        private readonly ISessao _sessao;

        public BaseModel(ISessao sessao) => _sessao = sessao;

        public string GetTenantIdUser()
        {
            try
            {
                return _sessao.GetTenantIdUser();
            }
            catch (Exception)
            {
                throw;
            }

        }

        public int GetUserId()
        {
            try
            {
                return _sessao.GetUserId();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IActionResult OnPostLogoutAsync()
        {
            _sessao.RemoveUserSession();
            return RedirectToPage("/Index");
        }
    }
}
