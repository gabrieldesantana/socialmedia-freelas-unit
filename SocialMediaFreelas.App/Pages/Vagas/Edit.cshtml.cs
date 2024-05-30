using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SocialMediaFreelas.Pages.Vagas
{
    public class EditModel : PageModel
    {
        private readonly IVagaService _service;

        public EditModel(IVagaService service)
        {
            _service = service;
        }

        [BindProperty]
        public VagaUpdateModel VagaUpdateModel { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int id)
        {
            var model = await _service.GetByIdAsync(id);

            #pragma warning disable CS8601
            VagaUpdateModel = model.Body.Select(x => new VagaUpdateModel
            {
                Id = x.Id,
                Titulo = x.Titulo,
                Descricao = x.Descricao,
                Cargo = x.Cargo,
                Tipo = x.Tipo,
                Remuneracao = x.Remuneracao,
                FreelancerId = x.FreelancerId
            }).FirstOrDefault();
            #pragma warning restore CS8601

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || _service == null || VagaUpdateModel == null)
            {
                return Page();
            }

            try
            {
                await _service.PutAsync(
                    VagaUpdateModel.Id,
                    new Vaga(
                        VagaUpdateModel.Titulo,
                        VagaUpdateModel.Descricao,
                        VagaUpdateModel.Cargo,
                        VagaUpdateModel.Tipo,
                        VagaUpdateModel.Remuneracao,
                        freelancerId: VagaUpdateModel.FreelancerId)
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
