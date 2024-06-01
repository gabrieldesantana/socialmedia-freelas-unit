using Microsoft.AspNetCore.Mvc;
using SocialMediaFreelas.Frontend.Helpers;

namespace SocialMediaFreelas.Pages.Experiencias
{
    public class DeleteModel : BaseModel
    {
        private readonly IExperienciaService _service;

        public DeleteModel(IExperienciaService service, ISessao sessao) 
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

        public async Task<IActionResult> OnPostAsync()
        {
            if (_service == null || ExperienciaViewModel == null)
            {
                return Page();
            }

            try
            {
                var tenantId = GetTenantIdUser();
                await _service.DeleteAsync(ExperienciaViewModel.Id, tenantId);

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
