using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SocialMediaFreelas.Pages.Experiencias
{
    public class IndexModel : PageModel
    {
        private readonly IExperienciaService _service;

        public IndexModel(IExperienciaService service)
        {
            _service= service;
        }

        public List<ExperienciaViewModel>? Response { get; set; } = default!;

        public async Task OnGetAsync()
        {
            var response = await _service.GetAllAsync();
            Response = response.Body;
        }
    }
}
