using Microsoft.AspNetCore.Http;
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

            var usuarioViewModel = await _clienteService.LoginAsync(LoginInputModel.Email, LoginInputModel.Senha);

            if (usuarioViewModel == null)
            {
                TempData["MensagemErro"] = "Email ou Senha Incorretos!";
                return Page();
            }


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
            TempData["MensagemSucesso"] = "Login realizado com sucesso!";

            return RedirectPreserveMethod("../Home/Cliente");

        }

        public async Task<IActionResult> OnGetOtherHandler()
        {
            _sessao.RemoveUserSession();
            return RedirectToPage("../");
        }
    }
}
