using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SocialMediaFreelas.Pages.Clientes
{
    public class IndexModel : PageModel
    {
        private readonly IClienteService _service;

        public IndexModel(IClienteService service)
        {
            _service= service;
        }

        public List<ClienteViewModel>? Response { get; set; } = default!;

        public async Task OnGetAsync()
        {
            var response = await _service.GetAllAsync();
            Response = response.Body;
        }
    }
}
