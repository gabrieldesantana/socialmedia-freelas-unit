using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SocialMediaFreelas.Application.InputModels;
using SocialMediaFreelas.Frontend.Dtos;
using SocialMediaFreelas.Frontend.Helpers;

namespace SocialMediaFreelas.Pages.Login.Freelancer
{
    public class LoginModel : PageModel
    {
        private readonly IFreelancerService _freelancerService;
        private readonly ISessao _sessao;

        public LoginModel(IFreelancerService freelancerService, ISessao sessao)
        {
            _freelancerService = freelancerService;
            _sessao = sessao;
        }

        public IActionResult OnGet()
        {
            if (_sessao.GetUserSession() != null)
                return RedirectPreserveMethod($"../Home/{_sessao.GetUserSession().Role}");

            return Page();

        }

        [BindProperty]
        public LoginInputModel LoginInputModel { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (LoginInputModel.Email == null || LoginInputModel.Senha == null) return Page();

            var usuarioViewModel = await _freelancerService.LoginAsync(LoginInputModel.Email, LoginInputModel.Senha);

            if (usuarioViewModel == null)
            {
                TempData["MensagemErro"] = "Email ou Senha Incorretos!";
                return Page();
            }


            if (usuarioViewModel.Email.Equals("admin@teste.com", StringComparison.OrdinalIgnoreCase))
                usuarioViewModel.Role = Frontend.Enums.EUserRole.Admin;

            UserDTO userDTO = new UserDTO
            {
             UserId = usuarioViewModel.UserId,
             Name = usuarioViewModel.Nome,
             Role = usuarioViewModel.Role,
             Email = usuarioViewModel.Email,
             TenantId = usuarioViewModel.TenantId ?? "tenantIdVazio"
            };

            _sessao.CreateUserSession(userDTO);

            TempData["MensagemSucesso"] = null;
            return RedirectPreserveMethod("../Home/Freelancer" );
        }
    }
}
