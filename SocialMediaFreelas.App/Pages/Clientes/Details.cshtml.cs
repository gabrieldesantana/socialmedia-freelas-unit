using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SocialMediaFreelas.Pages.Clientes
{
    public class DetailsModel : PageModel
    {
        private readonly IClienteService _service;

        public DetailsModel(IClienteService service)
        {
            _service = service;
        }

        [BindProperty]
        public ClienteViewModel ClienteViewModel { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int id)
        {
            var model = await _service.GetByIdAsync(id);

            if (!model.Body.Any()) return RedirectToPage("./Index");

            ClienteViewModel = model.Body[0];

            return Page();
        }
    }
}
