public interface IClienteService 
{
    Task<List<Cliente>> GetAllAsync();
    Task<Cliente> GetByIdAsync(int id);
    Task<Cliente> PostAsync(Cliente entidade);
    Task<Cliente> PutAsync(int id, Cliente entidade);
    Task<bool> DeleteAsync(int id);
}