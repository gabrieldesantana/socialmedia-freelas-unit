using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SocialMediaFreelas.Application.InputModels;

namespace SocialMediaFreelas.Pages.Login.Freelancer
{
    public class LoginModel : PageModel
    {
        private readonly IFreelancerService _freelancerService;

        public LoginModel(IFreelancerService freelancerService)
        {
            _freelancerService = freelancerService;
        }

        public void OnGet()
        {
        }

        [BindProperty]
        public LoginInputModel LoginInputModel { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (LoginInputModel.Email == null || LoginInputModel.Senha == null) return Page();

            var loginInputModel = await _freelancerService.LoginAsync(LoginInputModel.Email, LoginInputModel.Senha);

            if (loginInputModel == null)
            {
                TempData["MensagemErro"] = "Email ou Senha Incorretos!";
                return Page();
            }

            TempData["MensagemSucesso"] = "Login realizado com sucesso!";
            return Page();
        }
    }
}
