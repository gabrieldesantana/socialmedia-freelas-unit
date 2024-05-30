using Microsoft.AspNetCore.Mvc;
using SocialMediaFreelas.Frontend.Helpers;

namespace SocialMediaFreelas.Pages.Vagas
{
    public class DetailsModel : BaseModel
    {
        private readonly IVagaService _service;

        public DetailsModel(IVagaService service, ISessao sessao) 
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
    }
}
