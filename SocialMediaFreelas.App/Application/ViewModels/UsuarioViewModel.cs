using System.ComponentModel.DataAnnotations;

namespace SocialMediaFreelas.Application.ViewModels
{
    public class UsuarioViewModel
    {
        public string TenantId { get; set; }
        public string Nome { get; set; }
        public string Email { get; private set; }
    }
}
