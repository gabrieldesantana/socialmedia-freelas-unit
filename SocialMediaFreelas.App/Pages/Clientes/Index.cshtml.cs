using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SocialMediaFreelas.Frontend.Filters;
using SocialMediaFreelas.Frontend.Helpers;

namespace SocialMediaFreelas.Pages.Clientes
{
    [TypeFilter(typeof(RestrictedAdminPageFilter))]
    public class IndexModel : BaseModel
    {
        private readonly IClienteService _service;

        public IndexModel(IClienteService service, ISessao sessao) : base(sessao)
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
