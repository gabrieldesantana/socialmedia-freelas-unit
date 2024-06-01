using SocialMediaFreelas.Frontend.Helpers;

namespace SocialMediaFreelas.Pages.Vagas
{
    public class IndexModel : BaseModel
    {
        private readonly IVagaService _service;

        public IndexModel(IVagaService service, ISessao sessao)
            : base(sessao)
        {
            _service= service;
        }

        public List<VagaViewModel>? Response { get; set; } = default!;

        public async Task OnGetAsync()
        {
            var tenantId = GetTenantIdUser();
            var response = await _service.GetAllAsync(tenantId);
            Response = response.Body;
        }
    }
}
