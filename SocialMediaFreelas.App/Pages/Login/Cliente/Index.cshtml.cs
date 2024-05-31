using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SocialMediaFreelas.Application.InputModels;
using SocialMediaFreelas.Frontend.Dtos;
using SocialMediaFreelas.Frontend.Helpers;

namespace SocialMediaFreelas.Pages.Login.Cliente
{
    public class LoginModel : PageModel
    {
        private readonly IClienteService _clienteService;
        private readonly ISessao _sessao;

        public LoginModel(IClienteService clienteService, ISessao sessao)
        {
            _clienteService = clienteService;
            _sessao = sessao;
        }
        public void OnGet()
        {
        }

        [BindProperty]
        public LoginInputModel LoginInputModel { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (LoginInputModel.Email == null || LoginInputModel.Senha == null) return Page();

            var loginInputModel = await _clienteService.LoginAsync(LoginInputModel.Email, LoginInputModel.Senha);

            if (loginInputModel == null)
            {
                TempData["MensagemErro"] = "Email ou Senha Incorretos!";
                return Page();
            }


            UserDTO userDTO = new UserDTO
            {
                Name = loginInputModel.Nome,
                Role = loginInputModel.Role,
                Email = loginInputModel.Email,
                TenantId = loginInputModel.TenantId
            };

            _sessao.CreateUserSession(userDTO);


            TempData["MensagemSucesso"] = "Login realizado com sucesso!";
            return Page();

        }
    }
}
