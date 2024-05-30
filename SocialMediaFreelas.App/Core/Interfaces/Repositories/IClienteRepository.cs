public interface IClienteRepository
{
    Task<List<Cliente>> GetAllAsync(string? tenantId);
    Task<Cliente> GetByIdAsync(int id, string? tenantId);
    Task<Cliente> PostAsync(Cliente entidade);
    Task<Cliente> PutAsync(int id, Cliente entidade, string? tenantId);
    Task<bool> DeleteAsync(int id, string? tenantId);
    Task<Cliente> LoginAsync(string email, string senha);
}