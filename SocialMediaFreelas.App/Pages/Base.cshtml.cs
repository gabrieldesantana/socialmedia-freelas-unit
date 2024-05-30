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
    }
}
