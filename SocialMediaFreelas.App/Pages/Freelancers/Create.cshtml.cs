using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SocialMediaFreelas.Frontend.Filters;
using SocialMediaFreelas.Frontend.Helpers;

namespace SocialMediaFreelas.Pages.Freelancers
{
    [TypeFilter(typeof(RestrictedAdminPageFilter))]
    public class CreateModel : BaseModel
    {
        private readonly IFreelancerService _service;

        public CreateModel(IFreelancerService service, ISessao sessao) : base(sessao)
        {
            _service = service;
        }

        public IActionResult OnGet() 
        {
            return Page();
        }

        [BindProperty]
        public FreelancerInputModel FreelancerInputModel { get; set; } = default!;

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || _service == null || FreelancerInputModel == null)
            {
                return Page();
            }

            try
            {
                await _service.PostAsync(FreelancerInputModel);
                TempData["MensagemSucesso"] = "Cadastro feito com sucesso!";
                return RedirectToPage("./Index");
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
