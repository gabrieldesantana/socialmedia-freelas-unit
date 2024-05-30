using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SocialMediaFreelas.Pages.Experiencias
{
    public class DeleteModel : PageModel
    {
        private readonly IExperienciaService _service;

        public DeleteModel(IExperienciaService service)
        {
            _service = service;
        }

        [BindProperty]
        public ExperienciaViewModel ExperienciaViewModel { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int id)
        {
            var model = await _service.GetByIdAsync(id);

            if (!model.Body.Any()) return RedirectToPage("./Index");

            ExperienciaViewModel = model.Body[0];

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (_service == null || ExperienciaViewModel == null)
            {
                return Page();
            }

            try
            {
                await _service.DeleteAsync(ExperienciaViewModel.Id);

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
