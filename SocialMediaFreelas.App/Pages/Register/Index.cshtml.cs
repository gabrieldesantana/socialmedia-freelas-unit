using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SocialMediaFreelas.Pages.Register
{
    public class IndexModel : PageModel
    {
        private readonly IFreelancerService _freelancerService;
        private readonly IClienteService _clienteService;

        public IndexModel(IFreelancerService freelancerService, IClienteService clienteService)
        {
            _freelancerService = freelancerService;
            _clienteService = clienteService;
        }

        public void OnGet()
        {
        }

         [BindProperty]
        public UserInputModel UserInputModel { get; set; } = default!;

        public async Task<IActionResult> OnPostAsync()
        {
            var user = UserInputModel;
            DefaultResponse<Cliente> cliente = new();
            DefaultResponse<Freelancer> freelancer = new();


            if (user.Perfil == "Cliente")
            {
                cliente = await _clienteService.PostAsync(new ClienteInputModel()
                {
                    Nome = user.Nome,
                    Sobre = user.Sobre,
                    NumeroDocumento = user.NumeroDocumento,
                    Senha = user.Senha,
                    Email = user.Email,
                    Telefone = RemoverFormatacao(user.Telefone),
                    DataNascimento = user.DataNascimento
                });
            }
            else if (user.Perfil == "Freelancer")
            {
                freelancer = await _freelancerService.PostAsync(new FreelancerInputModel()
                {
                    Nome = user.Nome,
                    Sobre = user.Sobre,
                    NumeroDocumento = user.NumeroDocumento,
                    Senha = user.Senha,
                    Email = user.Email,
                    Telefone = RemoverFormatacao(user.Telefone),
                    DataNascimento = user.DataNascimento,
                    PretensaoSalarial = user.PretensaoSalarial
                });
            }

            if (freelancer.Body != null) return RedirectToPage("../Login/Freelancer/Index");
            if (cliente.Body != null) return RedirectToPage("../Login/Cliente/Index");

            return Page();

        }

        private static string RemoverFormatacao(string numeroFormatado)
        {
            return numeroFormatado.Replace("(", "")
                                  .Replace(") ", "")
                                  .Replace("-", "");
        }
    }
}
