using SocialMediaFreelas.Frontend.Helpers;

namespace SocialMediaFreelas.Pages.Experiencias
{
    public class IndexModel : BaseModel
    {
        private readonly IExperienciaService _service;

        public IndexModel(IExperienciaService service, ISessao sessao) 
            : base(sessao)
        {
            _service= service;
        }

        public List<ExperienciaViewModel>? Response { get; set; } = default!;

        public async Task OnGetAsync()
        {
            var tenantId = GetTenantIdUser();
            var response = await _service.GetAllAsync(tenantId);
            Response = response.Body;
        }
    }
}
