using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SocialMediaFreelas.Frontend.Filters;
using SocialMediaFreelas.Frontend.Helpers;

namespace SocialMediaFreelas.Pages.Clientes
{
    [TypeFilter(typeof(RestrictedAdminPageFilter))]
    public class DeleteModel : BaseModel
    {
        private readonly IClienteService _service;

        public DeleteModel(IClienteService service, ISessao sessao) : base(sessao)
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

        public async Task<IActionResult> OnPostAsync()
        {
            if (_service == null || ClienteViewModel == null)
            {
                return Page();
            }

            try
            {
                await _service.DeleteAsync(ClienteViewModel.Id);

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
