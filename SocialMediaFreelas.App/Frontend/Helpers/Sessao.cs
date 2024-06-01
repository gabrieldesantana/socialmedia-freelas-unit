using Newtonsoft.Json;
using SocialMediaFreelas.Frontend.Dtos;

namespace SocialMediaFreelas.Frontend.Helpers
{
    public class Sessao : ISessao
    {
        private readonly IHttpContextAccessor _contextAccessor;
        public Sessao(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }
        public UserDTO GetUserSession()
        {
            string userSession = _contextAccessor.HttpContext.Session.GetString("userSessionLogged");
            if (string.IsNullOrEmpty(userSession)) return null;

            return JsonConvert.DeserializeObject<UserDTO>(userSession);
        }

        public string GetTenantIdUser()
        {
            string userSession = _contextAccessor.HttpContext.Session.GetString("userSessionLogged");
            if (string.IsNullOrEmpty(userSession)) return string.Empty;

            var user = JsonConvert.DeserializeObject<UserDTO>(userSession);

            string tenantId = user.TenantId.ToString();

            if (user == null) return string.Empty;

            return user.TenantId.ToString();
        }

        public void CreateUserSession(UserDTO userDTO)
        {
            string value = JsonConvert.SerializeObject(userDTO);
            _contextAccessor.HttpContext.Session.SetString("userSessionLogged", value);
        }

        public void RemoveUserSession()
        {
            _contextAccessor.HttpContext?.Session?.Remove("userSessionLogged");
        }

        public int GetUserId()
        {
            string userSession = _contextAccessor.HttpContext.Session.GetString("userSessionLogged");
            if (string.IsNullOrEmpty(userSession)) return 0;

            var user = JsonConvert.DeserializeObject<UserDTO>(userSession);

            int userId = user.UserId;

            if (user == null) return 0;

            return user.UserId;
        }
    }
}
