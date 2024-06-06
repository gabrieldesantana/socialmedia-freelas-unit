using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SocialMediaFreelas.Frontend.Filters;
using SocialMediaFreelas.Frontend.Helpers;

namespace SocialMediaFreelas.Pages.Clientes
{
    [TypeFilter(typeof(RestrictedAdminPageFilter))]
    public class CreateModel : BaseModel
    {
        private readonly IClienteService _service;

        public CreateModel(IClienteService service, ISessao sessao) : base(sessao)
        {
            _service = service;
        }

        public IActionResult OnGet() 
        {
            return Page();
        }

        [BindProperty]
        public ClienteInputModel ClienteInputModel { get; set; } = default!;

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || _service == null || ClienteInputModel == null)
            {
                return Page();
            }

            try
            {
                await _service.PostAsync(ClienteInputModel);
                TempData["MensagemSucesso"] = "Cadastro feito com sucesso!";
                return RedirectToPage("./Index");
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
