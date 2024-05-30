using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SocialMediaFreelas.Frontend.Helpers;

namespace SocialMediaFreelas.Pages.Freelancers
{
    public class IndexModel : BaseModel
    {
        private readonly IFreelancerService _service;

        public IndexModel(IFreelancerService service, ISessao sessao) 
            : base(sessao)
        {
            _service= service;
        }

        public List<FreelancerViewModel>? Response { get; set; } = default!;

        public async Task OnGetAsync()
        {
            var tenantId = GetTenantIdUser();
            var response = await _service.GetAllAsync(tenantId);
            Response = response.Body;
        }
    }
}
