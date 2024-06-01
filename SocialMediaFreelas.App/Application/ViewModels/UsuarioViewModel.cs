using SocialMediaFreelas.Frontend.Enums;
using System.ComponentModel.DataAnnotations;

namespace SocialMediaFreelas.Application.ViewModels
{
    public class UsuarioViewModel
    {
        public int UserId { get; set; }
        public string TenantId { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public EUserRole Role { get; set; }
    }
}
