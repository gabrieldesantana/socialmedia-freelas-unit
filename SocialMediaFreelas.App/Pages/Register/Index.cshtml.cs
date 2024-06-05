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

        try
            {
            (user.Perfil == "Cliente")
            ? _clienteService.PostAsync(new ClienteInputModel() 
            {
                Nome = user.Nome,
                Sobre = user.Sobre,
                NumeroDocumento = user.NumeroDocumento,
                Senha = user.Senha,
                Email = user.Email,
                Telefone = user.Telefone,
                DataNascimento = user.DataNascimento
            })
            : _freelancerService.PostAsync(new FreelancerInputModel() 
            {
                Nome = user.Nome,
                Sobre = user.Sobre,
                NumeroDocumento = user.NumeroDocumento,
                Senha = user.Senha,
                Email = user.Email,
                Telefone = user.Telefone,
                DataNascimento = user.DataNascimento,
                PretensaoSalarial = user.PretensaoSalarial
            })


                // await _service.PostAsync(FreelancerInputModel);
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
