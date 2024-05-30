using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SocialMediaFreelas.Pages.Experiencias
{
    public class DetailsModel : PageModel
    {
        private readonly IExperienciaService _service;

        public DetailsModel(IExperienciaService service)
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
    }
}
