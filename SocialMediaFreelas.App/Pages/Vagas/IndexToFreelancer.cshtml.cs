using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SocialMediaFreelas.Frontend.Filters;
using SocialMediaFreelas.Frontend.Helpers;

namespace SocialMediaFreelas.Pages.Vagas
{
    [TypeFilter(typeof(RestrictedFreelancerPageFilter))]
    public class IndexToFreelancerModel : BaseModel
    {
        private readonly IVagaService _service;

        public IndexToFreelancerModel(IVagaService service, ISessao sessao)
            : base(sessao)
        {
            _service = service;
        }

        public List<VagaViewModel>? Response { get; set; } = default!;

        public async Task OnGetAsync()
        {
            //var tenantId = GetTenantIdUser();
            var response = await _service.GetAllAsync();
            Response = response.Body;
        }

        public IActionResult OnPost(string query)
        {
            query = query ?? string.Empty;

            var vagas = _service.GetAllAsync().Result.Body;

            if (vagas == null || !vagas.Any())
            {
                vagas = new List<VagaViewModel>();
            }

            vagas = vagas.Where(v =>
            v.Titulo.Contains(query, StringComparison.OrdinalIgnoreCase) ||
            v.Cargo.Contains(query, StringComparison.OrdinalIgnoreCase) ||
            v.Localizacao.Contains(query, StringComparison.OrdinalIgnoreCase) ||
            v.Tipo.Equals(query, StringComparison.OrdinalIgnoreCase) ||
            v.Status.Equals(query, StringComparison.OrdinalIgnoreCase))
            .ToList();

            return Partial("VagasAjax", vagas);
        }
    }
}
