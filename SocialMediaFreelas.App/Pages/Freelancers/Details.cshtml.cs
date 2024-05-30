using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SocialMediaFreelas.Pages.Freelancers
{
    public class DetailsModel : PageModel
    {
        private readonly IFreelancerService _service;

        public DetailsModel(IFreelancerService service)
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
    }
}
