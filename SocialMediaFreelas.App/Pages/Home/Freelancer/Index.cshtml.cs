using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace SocialMediaFreelas.App.Pages;

public class HomeFreelancerModel : PageModel
{
    private readonly ILogger<HomeFreelancerModel> _logger;

    public HomeFreelancerModel(ILogger<HomeFreelancerModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {
        
    }
}
