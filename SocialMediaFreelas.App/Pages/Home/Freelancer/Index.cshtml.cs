using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SocialMediaFreelas.App.Pages.Home.Freelancer;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;

    public IndexModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {
        
    }
}
