using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SocialMediaFreelas.Pages.Clientes
{
    public class DeleteModel : PageModel
    {
        private readonly IClienteService _service;

        public DeleteModel(IClienteService service)
        {
            _service = service;
        }

        [BindProperty]
        public ClienteViewModel ClienteViewModel { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int id)
        {
            var freelancer = await _service.GetByIdAsync(id);

            if (!freelancer.Body.Any()) return RedirectToPage("./Index");

            ClienteViewModel = freelancer.Body[0];

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (_service == null || ClienteViewModel == null)
            {
                return Page();
            }

            try
            {
                await _service.DeleteAsync(ClienteViewModel.Id);

                TempData["MensagemSucesso"] = "Deleção feita com sucesso!";
                return RedirectToPage("./Index");
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
