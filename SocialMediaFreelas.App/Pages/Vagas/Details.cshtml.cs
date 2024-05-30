using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SocialMediaFreelas.Pages.Vagas
{
    public class DetailsModel : PageModel
    {
        private readonly IVagaService _service;

        public DetailsModel(IVagaService service)
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
    }
}
