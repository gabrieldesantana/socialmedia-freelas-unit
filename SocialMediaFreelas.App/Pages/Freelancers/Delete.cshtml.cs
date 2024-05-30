using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SocialMediaFreelas.Pages.Freelancers
{
    public class DeleteModel : PageModel
    {
        private readonly IFreelancerService _service;

        public DeleteModel(IFreelancerService service)
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
