using Microsoft.AspNetCore.Mvc;
using SocialMediaFreelas.Frontend.Helpers;

namespace SocialMediaFreelas.Pages.Vagas
{
    public class DetailsByFreelancerModel : BaseModel
    {
        private readonly IVagaService _service;
        private readonly IFreelancerService _freelancerService;

        public DetailsByFreelancerModel(IVagaService service, IFreelancerService freelancerService, ISessao sessao)
            : base(sessao)
        {
            _service = service;
            _freelancerService = freelancerService;
        }

        [BindProperty]
        public VagaViewModel VagaViewModel { get; set; } = new VagaViewModel();

        public async Task<IActionResult> OnGetAsync(int id)
        {
            var tenantId = GetTenantIdUser();
            var userId = GetUserId();
            var model = await _service.GetByIdAsync(id);

            VagaViewModel.Done = false;

            VagaViewModel = model.Body[0];

            if (model.Body[0].Freelancers.Any(x => x.Id == userId)) 
            {
                VagaViewModel.Done = true;
            }

            VagaViewModel.UserId = userId;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {

            var vagaChanged = await _service.AddFreelancerAsync(idVaga: VagaViewModel.Id, idFreelancer: VagaViewModel.UserId);

            if (vagaChanged == false)
            {
                TempData["MensagemErro"] = "Houve um erro ao tentar se candidatar";
                return Page();
            }

            TempData["MensagemSucesso"] = "Você se candidatou com sucesso!";

            return Page();
        }
    }
}
