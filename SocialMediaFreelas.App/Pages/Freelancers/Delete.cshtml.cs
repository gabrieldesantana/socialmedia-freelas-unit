using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SocialMediaFreelas.Frontend.Helpers;

namespace SocialMediaFreelas.Pages.Freelancers
{
    public class DeleteModel : BaseModel
    {
        private readonly IFreelancerService _service;

        public DeleteModel(IFreelancerService service, ISessao sessao) 
            : base(sessao)
        {
            _service = service;
        }

        [BindProperty]
        public FreelancerViewModel FreelancerViewModel { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int id)
        {
            var tenantId = GetTenantIdUser();
            var freelancer = await _service.GetByIdAsync(id, tenantId);

            if (!freelancer.Body.Any()) return RedirectToPage("./Index");

            FreelancerViewModel = freelancer.Body[0];

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (_service == null || FreelancerViewModel == null)
            {
                return Page();
            }

            try
            {
                var tenantId = GetTenantIdUser();
                await _service.DeleteAsync(FreelancerViewModel.Id, tenantId);

                TempData["MensagemSucesso"] = "Deleção feita com sucesso!";
                return RedirectToPage("./Index");
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
