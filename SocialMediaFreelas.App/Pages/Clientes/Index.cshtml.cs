using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SocialMediaFreelas.Frontend.Helpers;

namespace SocialMediaFreelas.Pages.Clientes
{
    public class IndexModel : BaseModel
    {
        private readonly IClienteService _service;

        public IndexModel(IClienteService service, ISessao sessao) 
            : base(sessao)
        {
            _service= service;
        }

        public List<ClienteViewModel>? Response { get; set; } = default!;

        public async Task OnGetAsync()
        {
            var tenantId = GetTenantIdUser();
            var response = await _service.GetAllAsync(tenantId);
            Response = response.Body;
        }
    }
}
