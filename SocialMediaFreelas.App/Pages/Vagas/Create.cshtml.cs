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
            return Page();
        }

        [BindProperty]
        public VagaInputModel VagaInputModel { get; set; } = default!;

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || _service == null || VagaInputModel == null)
            {
                return Page();
            }

            try
            {
                VagaInputModel.TenantIdOwner = GetTenantIdUser();
                await _service.PostAsync(VagaInputModel);
                TempData["MensagemSucesso"] = "Cadastro feito com sucesso!";
                return RedirectToPage("./Index");
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
