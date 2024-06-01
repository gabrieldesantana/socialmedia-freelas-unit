using SocialMediaFreelas.Application.ViewModels;

public interface IClienteService 
{
    Task<DefaultResponse<ClienteViewModel>> GetAllAsync(string? tenantId = "");
    Task<DefaultResponse<ClienteViewModel>> GetByIdAsync(int id, string? tenantId = "");
    Task<DefaultResponse<Cliente>> PostAsync(ClienteInputModel entidade);
    Task<DefaultResponse<Cliente>> PutAsync(int id, Cliente entidade, string? tenantId = "");
    Task<bool> DeleteAsync(int id, string? tenantId = "");
    Task<UsuarioViewModel> LoginAsync(string email, string senha);
}