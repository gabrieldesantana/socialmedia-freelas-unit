using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SocialMediaFreelas.Frontend.Filters;
using SocialMediaFreelas.Frontend.Helpers;
using System.Xml.Linq;

namespace SocialMediaFreelas.Pages.Experiencias
{
    [TypeFilter(typeof(RestrictedFreelancerPageFilter))]
    public class IndexByUserModel : BaseModel
    {
        private readonly IExperienciaService _service;

        public IndexByUserModel(IExperienciaService service, ISessao sessao)
            : base(sessao)
        {
            _service = service;
        }

        public List<ExperienciaViewModel>? Response { get; set; } = default!;

        public async Task OnGetAsync()
        {
            var userId = GetUserId();
            var response = await _service.GetAllByUserIdAsync(userId);
            Response = response.Body;
        }

        public IActionResult OnPost(string query)
        {
            var tenantId = "";

            var userId = GetUserId();
            query = query ?? string.Empty;

            var experiencias = _service.GetAllByFilterAsync(query, tenantId, userId).Result.Body;

            if (experiencias == null || !experiencias.Any())
            {
                // Retorne uma lista vazia ou lide com o caso de 'nenhuma experiência encontrada'
                experiencias = new List<ExperienciaViewModel>();
            }

            return Partial("ExperienciasAjax", experiencias);
        }
    }
}
