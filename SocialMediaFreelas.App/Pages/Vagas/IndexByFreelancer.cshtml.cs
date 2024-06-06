using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SocialMediaFreelas.Frontend.Filters;
using SocialMediaFreelas.Frontend.Helpers;

namespace SocialMediaFreelas.Pages.Vagas
{
    [TypeFilter(typeof(RestrictedFreelancerPageFilter))]
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

        public IActionResult OnPost(string query)
        {
            query = query ?? string.Empty;

            var vagas = Response;

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
