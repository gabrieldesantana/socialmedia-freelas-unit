using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace SocialMediaFreelas.Pages.Freelancers
{
    public class CreateModel : PageModel
    {
        private readonly IFreelancerService _service;

        public CreateModel(IFreelancerService service)
        {
            _service = service;
        }

        public IActionResult OnGet() 
        {
            return Page();
        }

        [BindProperty]
        public FreelancerInputModel FreelancerInputModel { get; set; } = default!;

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || _service == null || FreelancerInputModel == null)
            {
                return Page();
            }

            try
            {
                await _service.PostAsync(FreelancerInputModel);
                return RedirectToPage("./Index");
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
