using Microsoft.AspNetCore.Mvc;
using SocialMediaFreelas.Frontend.Filters;
using SocialMediaFreelas.Frontend.Helpers;

namespace SocialMediaFreelas.Pages.Vagas
{
    [TypeFilter(typeof(RestrictedClientePageFilter))]
    public class EditModel : BaseModel
    {
        private readonly IVagaService _service;

        public EditModel(IVagaService service, ISessao sessao) 
            : base(sessao)
        {
            _service = service;
        }

        [BindProperty]
        public VagaUpdateModel VagaUpdateModel { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int id)
        {
            var tenantId = GetTenantIdUser();
            var model = await _service.GetByIdAsync(id, tenantId);

            #pragma warning disable CS8601
            VagaUpdateModel = model.Body.Select(x => new VagaUpdateModel
            {
                Id = x.Id,
                Titulo = x.Titulo,
                Descricao = x.Descricao,
                Cargo = x.Cargo,
                Tipo = x.Tipo,
                Localizacao = x.Localizacao,
                Status = x.Status,
                Remuneracao = x.Remuneracao
            }).FirstOrDefault();
            #pragma warning restore CS8601

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || _service == null || VagaUpdateModel == null)
            {
                return Page();
            }

            try
            {
                var tenantId = GetTenantIdUser();

                await _service.PutAsync(
                    VagaUpdateModel.Id,
                    new Vaga(
                        VagaUpdateModel.Titulo,
                        VagaUpdateModel.Descricao,
                        VagaUpdateModel.Cargo,
                        VagaUpdateModel.Tipo,
                        VagaUpdateModel.Localizacao,
                        VagaUpdateModel.Status,
                        VagaUpdateModel.Remuneracao),
                    tenantId
                    );

                TempData["MensagemSucesso"] = "Atualização feita com sucesso!";
                return RedirectToPage("./IndexByUser");
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
