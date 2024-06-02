using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SocialMediaFreelas.Frontend.Helpers;

namespace SocialMediaFreelas.Pages.Freelancers
{
    public class EditModel : BaseModel
    {
        private readonly IFreelancerService _service;

        public EditModel(IFreelancerService service, ISessao sessao) : base(sessao)
        {
            _service = service;
        }

        [BindProperty]
        public FreelancerUpdateModel FreelancerUpdateModel { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int id)
        {
            var freelancer = await _service.GetByIdAsync(id);

            #pragma warning disable CS8601
            FreelancerUpdateModel = freelancer.Body.Select(x => new FreelancerUpdateModel
            {
                Id = x.Id,
                NumeroDocumento = x.NumeroDocumento,
                Nome = x.Nome,
                DataNascimento = x.DataNascimento,
                Email = x.Email,
                Telefone = x.Telefone,
                Sobre = x.Sobre,
                PretensaoSalarial = x.PretensaoSalarial
            }).FirstOrDefault();
            #pragma warning restore CS8601

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || _service == null || FreelancerUpdateModel == null)
            {
                return Page();
            }

            try
            {
                await _service.PutAsync(
                    FreelancerUpdateModel.Id,
                    new Freelancer(
                        FreelancerUpdateModel.Nome,
                        FreelancerUpdateModel.NumeroDocumento,
                        FreelancerUpdateModel.DataNascimento,
                        FreelancerUpdateModel.Email,
                        FreelancerUpdateModel.Telefone,
                        FreelancerUpdateModel.Sobre,
                        FreelancerUpdateModel.PretensaoSalarial)
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
