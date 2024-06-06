using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SocialMediaFreelas.Frontend.Filters;
using SocialMediaFreelas.Frontend.Helpers;

namespace SocialMediaFreelas.Pages.Freelancers
{
    [TypeFilter(typeof(RestrictedAdminPageFilter))]
    public class DeleteModel : BaseModel
    {
        private readonly IFreelancerService _service;

        public DeleteModel(IFreelancerService service, ISessao sessao) : base(sessao)
        {
            _service = service;
        }

        [BindProperty]
        public FreelancerViewModel FreelancerViewModel { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int id)
        {
            var freelancer = await _service.GetByIdAsync(id);

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
                await _service.DeleteAsync(FreelancerViewModel.Id);

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
