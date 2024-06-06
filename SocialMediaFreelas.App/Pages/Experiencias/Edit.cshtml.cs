using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SocialMediaFreelas.Frontend.Filters;
using SocialMediaFreelas.Frontend.Helpers;

namespace SocialMediaFreelas.Pages.Experiencias
{
    [TypeFilter(typeof(RestrictedAdminPageFilter))]
    public class EditModel : BaseModel
    {
        private readonly IExperienciaService _service;

        public EditModel(IExperienciaService service, ISessao sessao) 
            : base(sessao)
        {
            _service = service;
        }

        [BindProperty]
        public ExperienciaUpdateModel ExperienciaUpdateModel { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int id)
        {
            var tenantId = GetTenantIdUser();
            var model = await _service.GetByIdAsync(id, tenantId);

            #pragma warning disable CS8601
            ExperienciaUpdateModel = model.Body.Select(x => new ExperienciaUpdateModel
            {
                Id = x.Id,
                Projeto = x.Projeto,
                Empresa = x.Empresa,
                Tecnologia = x.Tecnologia,
                Valor = x.Valor,
                Avaliacao = x.Avaliacao
            }).FirstOrDefault();
            #pragma warning restore CS8601

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || _service == null || ExperienciaUpdateModel == null)
            {
                return Page();
            }

            try
            {
                var tenantId = GetTenantIdUser();
                await _service.PutAsync(
                    ExperienciaUpdateModel.Id,
                    new Experiencia(
                        ExperienciaUpdateModel.Projeto,
                        ExperienciaUpdateModel.Empresa,
                        ExperienciaUpdateModel.Tecnologia,
                        ExperienciaUpdateModel.Valor,
                        ExperienciaUpdateModel.Avaliacao),
                    tenantId
                    );

                TempData["MensagemSucesso"] = "Atualização feita com sucesso!";
                return RedirectToPage("./Index");
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
