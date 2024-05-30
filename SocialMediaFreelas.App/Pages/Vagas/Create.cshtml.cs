using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SocialMediaFreelas.Pages.Vagas
{
    public class CreateModel : PageModel
    {
        private readonly IVagaService _service;

        public CreateModel(IVagaService service)
        {
            _service = service;
        }

        public IActionResult OnGet() 
        {
            return Page();
        }

        [BindProperty]
        public VagaInputModel VagaInputModel { get; set; } = default!;

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || _service == null || VagaInputModel == null)
            {
                return Page();
            }

            try
            {
                await _service.PostAsync(VagaInputModel);
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
