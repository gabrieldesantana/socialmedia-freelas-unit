using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SocialMediaFreelas.Pages.Vagas
{
    public class IndexModel : PageModel
    {
        private readonly IVagaService _service;

        public IndexModel(IVagaService service)
        {
            _service= service;
        }

        public List<VagaViewModel>? Response { get; set; } = default!;

        public async Task OnGetAsync()
        {
            var response = await _service.GetAllAsync();
            Response = response.Body;
        }
    }
}
