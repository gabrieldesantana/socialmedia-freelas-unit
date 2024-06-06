using Microsoft.AspNetCore.Mvc;
using SocialMediaFreelas.Frontend.Helpers;

namespace SocialMediaFreelas.Pages.Vagas
{
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
                VagaInputModel.Status = "Aberta";
                VagaInputModel.TenantIdOwner = GetTenantIdUser();
                await _service.PostAsync(VagaInputModel);
                TempData["MensagemSucesso"] = "Cadastro feito com sucesso!";
                return RedirectToPage("./IndexByUser");
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
