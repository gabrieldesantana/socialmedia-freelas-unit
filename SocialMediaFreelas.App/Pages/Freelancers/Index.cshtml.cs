using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SocialMediaFreelas.Pages.Freelancers
{
    public class IndexModel : PageModel
    {
        private readonly IFreelancerService _service;

        public IndexModel(IFreelancerService service)
        {
            _service= service;
        }

        public List<FreelancerViewModel>? Response { get; set; } = default!;

        public async Task OnGetAsync()
        {
            var response = await _service.GetAllAsync();
            Response = response.Body;
        }
    }
}
