using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace SocialMediaFreelas.App.Pages;

public class HomeClienteModel : PageModel
{
    private readonly ILogger<HomeClienteModel> _logger;

    public HomeClienteModel(ILogger<HomeClienteModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {
        
    }
}
