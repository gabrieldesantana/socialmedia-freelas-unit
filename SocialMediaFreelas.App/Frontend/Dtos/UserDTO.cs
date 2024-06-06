using SocialMediaFreelas.Frontend.Enums;

namespace SocialMediaFreelas.Frontend.Dtos
{
    public class UserDTO
    {
        public int UserId { get; set; }
        public string? TenantId { get; set; }
        public string? Name { get; set; }
        public EUserRole Role { get; set; }
        public string? Email { get; set; }
    }
}
