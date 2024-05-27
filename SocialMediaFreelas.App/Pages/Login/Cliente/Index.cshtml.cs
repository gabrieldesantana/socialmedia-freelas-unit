using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SocialMediaFreelas.Application.InputModels;

namespace SocialMediaFreelas.Pages.Login.Cliente
{
    public class LoginModel : PageModel
    {
        public void OnGet()
        {
        }

        [BindProperty]
        public LoginInputModel LoginInputModel { get; set; }

        public void OnPostAsync()
        {

        }
    }
}
