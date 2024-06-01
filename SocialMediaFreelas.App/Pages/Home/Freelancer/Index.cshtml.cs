using Microsoft.AspNetCore.Mvc.RazorPages;
using SocialMediaFreelas.Frontend.Helpers;
using SocialMediaFreelas.Pages;

namespace SocialMediaFreelas.App.Pages.Home.Freelancer;

public class IndexModel : BaseModel
{
    private readonly ILogger<IndexModel> _logger;

    public IndexModel(ILogger<IndexModel> logger, ISessao sessao) : base(sessao)
    {
        _logger = logger;
    }

    public void OnGet()
    {
        
    }
}
