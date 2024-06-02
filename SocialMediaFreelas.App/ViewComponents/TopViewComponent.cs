using Microsoft.AspNetCore.Mvc;
using SocialMediaFreelas.Frontend.Dtos;
using SocialMediaFreelas.Frontend.Helpers;

namespace SocialMediaFreelas.ViewComponents
{
    public class TopViewComponent : ViewComponent
    {
        private readonly ISessao _sessao;

        public TopViewComponent(ISessao sessao)
        {
            _sessao = sessao;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            UserDTO userDTO = _sessao.GetUserSession();
            return View(userDTO);
        }
    }
}
