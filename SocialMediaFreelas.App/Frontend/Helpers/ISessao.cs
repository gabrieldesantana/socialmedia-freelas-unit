using SocialMediaFreelas.Frontend.Dtos;

namespace SocialMediaFreelas.Frontend.Helpers
{
    public interface ISessao
    {
        void CreateUserSession(UserDTO userDTO);
        void RemoveUserSession();
        UserDTO GetUserSession();
        string GetTenantIdUser();
        int GetUserId();
    }
}
