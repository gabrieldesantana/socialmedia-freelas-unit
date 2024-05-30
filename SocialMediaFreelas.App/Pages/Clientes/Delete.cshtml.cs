using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SocialMediaFreelas.Frontend.Helpers;

namespace SocialMediaFreelas.Pages.Clientes
{
    public class DeleteModel : BaseModel
    {
        private readonly IClienteService _service;

        public DeleteModel(IClienteService service, ISessao sessao)
            : base(sessao)
        {
            _service = service;
        }

        [BindProperty]
        public ClienteViewModel ClienteViewModel { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int id)
        {
            var tenantId = GetTenantIdUser();
            var model = await _service.GetByIdAsync(id, tenantId);

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
                var tenantId = GetTenantIdUser();
                await _service.DeleteAsync(ClienteViewModel.Id, tenantId);

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
