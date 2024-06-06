using Microsoft.AspNetCore.Mvc;
using SocialMediaFreelas.Frontend.Filters;
using SocialMediaFreelas.Frontend.Helpers;

namespace SocialMediaFreelas.Pages.Vagas
{
    [TypeFilter(typeof(RestrictedClientePageFilter))]
    public class DeleteModel : BaseModel
    {
        private readonly IVagaService _service;

        public DeleteModel(IVagaService service, ISessao sessao) 
            : base(sessao)
        {
            _service = service;
        }

        [BindProperty]
        public VagaViewModel VagaViewModel { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int id)
        {
            var tenantId = GetTenantIdUser();

            var model = await _service.GetByIdAsync(id, tenantId);

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
                var tenantId = GetTenantIdUser();
                await _service.DeleteAsync(VagaViewModel.Id, tenantId);

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
