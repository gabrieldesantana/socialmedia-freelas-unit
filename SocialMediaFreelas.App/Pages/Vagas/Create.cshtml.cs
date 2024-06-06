using Microsoft.AspNetCore.Mvc;
using SocialMediaFreelas.Frontend.Filters;
using SocialMediaFreelas.Frontend.Helpers;

namespace SocialMediaFreelas.Pages.Vagas
{
    [TypeFilter(typeof(RestrictedClientePageFilter))]
    public class CreateModel : BaseModel
    {
        private readonly IVagaService _service;

        public CreateModel(IVagaService service, ISessao sessao)
            : base(sessao)
        {
            _service = service;
        }

        public IActionResult OnGet() 
        {
            var userId = GetUserId();
            VagaInputModel.ClienteId = userId;
            return Page();
        }

        [BindProperty]
        public VagaInputModel VagaInputModel { get; set; } = new VagaInputModel();

        public async Task<IActionResult> OnPostAsync()
        {
            if (_service == null || VagaInputModel == null)
            {
                return Page();
            }

            try
            {
                //VagaInputModel.Status = "Aberta";
                //VagaInputModel.TenantIdOwner = GetTenantIdUser();
                //await _service.PostAsync(VagaInputModel);

                TempData["MensagemSucesso"] = "Vaga publicada com sucesso!";
                return RedirectToPage("./IndexByUser");
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
