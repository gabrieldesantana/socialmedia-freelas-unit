using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SocialMediaFreelas.Frontend.Helpers;

namespace SocialMediaFreelas.Pages.Vagas
{
    public class IndexByFreelancerModel : BaseModel
    {
        private readonly IVagaService _service;

        public IndexByFreelancerModel(IVagaService service, ISessao sessao)
            : base(sessao)
        {
            _service = service;
        }

        public List<VagaViewModel>? Response { get; set; } = default!;

        public async Task OnGetAsync(int id)
        {
            //var tenantId = GetTenantIdUser();
            var response = await _service.GetAllByFreelancerIdAsync(id);
            Response = response.Body;
        }
    }
}
