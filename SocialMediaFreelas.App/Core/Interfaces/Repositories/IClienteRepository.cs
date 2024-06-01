using SocialMediaFreelas.Core.Interfaces.Repositories;

public interface IClienteRepository : IGenericRepository<Cliente>
{
    Task<Cliente> PutAsync(int id, Cliente entidade, string? tenantId = "");
    Task<Cliente> LoginAsync(string email, string senha);
}