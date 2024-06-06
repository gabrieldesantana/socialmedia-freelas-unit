using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SocialMediaFreelas.Frontend.Filters;
using SocialMediaFreelas.Frontend.Helpers;

namespace SocialMediaFreelas.Pages.Experiencias
{
    [TypeFilter(typeof(RestrictedAdminPageFilter))]
    public class DetailsModel : BaseModel
    {
        private readonly IExperienciaService _service;

        public DetailsModel(IExperienciaService service, ISessao sessao)
            : base(sessao)
        {
            _service = service;
        }

        [BindProperty]
        public ExperienciaViewModel ExperienciaViewModel { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int id)
        {
            var tenantId = GetTenantIdUser();
            var model = await _service.GetByIdAsync(id, tenantId);

            if (!model.Body.Any()) return RedirectToPage("./Index");

            ExperienciaViewModel = model.Body[0];

            return Page();
        }
    }
}
