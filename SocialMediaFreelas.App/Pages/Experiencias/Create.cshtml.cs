using Microsoft.AspNetCore.Mvc;
using SocialMediaFreelas.Frontend.Helpers;

namespace SocialMediaFreelas.Pages.Experiencias
{
    public class CreateModel : BaseModel
    {
        private readonly IExperienciaService _service;
        private readonly IFreelancerService _freelancerService;

        public CreateModel(IExperienciaService service, ISessao sessao, IFreelancerService freelancerService)
            : base(sessao)
        {
            _service = service;
            _freelancerService = freelancerService;
        }

        public IActionResult OnGet() 
        {
            var freelancers = _freelancerService.GetAllAsync();
            ExperienciaInputModel.Freelancers = freelancers.Result.Body;
            return Page();
        }

        [BindProperty]
        public ExperienciaInputModel ExperienciaInputModel { get; set; } = default!;

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || _service == null || ExperienciaInputModel == null)
            {
                return Page();
            }

            try
            {
                ExperienciaInputModel.TenantIdOwner = GetTenantIdUser();
                await _service.PostAsync(ExperienciaInputModel);
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
