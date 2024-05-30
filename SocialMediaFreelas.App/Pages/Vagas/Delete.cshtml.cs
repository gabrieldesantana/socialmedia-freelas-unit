using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SocialMediaFreelas.Pages.Vagas
{
    public class DeleteModel : PageModel
    {
        private readonly IVagaService _service;

        public DeleteModel(IVagaService service)
        {
            _service = service;
        }

        [BindProperty]
        public VagaViewModel VagaViewModel { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int id)
        {
            var model = await _service.GetByIdAsync(id);

            if (!model.Body.Any()) return RedirectToPage("./Index");

            VagaViewModel = model.Body[0];

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (_service == null || VagaViewModel == null)
            {
                return Page();
            }

            try
            {
                await _service.DeleteAsync(VagaViewModel.Id);

                TempData["MensagemSucesso"] = "Dele��o feita com sucesso!";
                return RedirectToPage("./Index");
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
