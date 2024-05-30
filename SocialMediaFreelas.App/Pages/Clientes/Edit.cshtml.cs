using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SocialMediaFreelas.Pages.Clientes
{
    public class EditModel : PageModel
    {
        private readonly IClienteService _service;

        public EditModel(IClienteService service)
        {
            _service = service;
        }

        [BindProperty]
        public ClienteUpdateModel ClienteUpdateModel { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int id)
        {
            var freelancer = await _service.GetByIdAsync(id);

            #pragma warning disable CS8601
            ClienteUpdateModel = freelancer.Body.Select(x => new ClienteUpdateModel
            {
                Id = x.Id,
                NumeroDocumento = x.NumeroDocumento,
                Nome = x.Nome,
                DataNascimento = x.DataNascimento,
                Email = x.Email,
                Telefone = x.Telefone
            }).FirstOrDefault();
            #pragma warning restore CS8601

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || _service == null || ClienteUpdateModel == null)
            {
                return Page();
            }

            try
            {
                await _service.PutAsync(
                    ClienteUpdateModel.Id,
                    new Cliente(
                        ClienteUpdateModel.Nome,
                        ClienteUpdateModel.NumeroDocumento,
                        ClienteUpdateModel.DataNascimento,
                        ClienteUpdateModel.Email,
                        ClienteUpdateModel.Telefone)
                    );

                TempData["MensagemSucesso"] = "Atualização feita com sucesso!";
                return RedirectToPage("./Index");
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
