using Microsoft.AspNetCore.Mvc;
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
            //var tenantId = GetTenantIdUser();
            var response = await _service.GetAllAsync();
            Response = response.Body;
        }

        public IActionResult OnPost(string query)
        {
            query = query ?? string.Empty;

            var experiencias = _service.GetAllByFilterAsync(query).Result.Body;

            if (experiencias == null || !experiencias.Any())
            {
                // Retorne uma lista vazia ou lide com o caso de 'nenhuma experiência encontrada'
                experiencias = new List<ExperienciaViewModel>();
            }

            return Partial("ExperienciasAjax", experiencias);
        }
    }
}
