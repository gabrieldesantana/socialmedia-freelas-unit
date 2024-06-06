using Microsoft.AspNetCore.Mvc;
using SocialMediaFreelas.Application.ViewModels;
using SocialMediaFreelas.Frontend.Dtos;
using SocialMediaFreelas.Frontend.Helpers;

namespace SocialMediaFreelas.Pages.Vagas
{
    public class DetailsModel : BaseModel
    {
        private readonly IVagaService _service;
        private readonly IFreelancerService _freelancerService;

        public DetailsModel(IVagaService service, IFreelancerService freelancerService, ISessao sessao) 
            : base(sessao)
        {
            _service = service;
            _freelancerService= freelancerService;
        }

        [BindProperty]
        public VagaViewModel VagaViewModel { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int id)
        {
            var tenantId = GetTenantIdUser();
            var model = await _service.GetByIdAsync(id);

            VagaViewModel = model.Body[0];

            return Page();
        }

    }
}
