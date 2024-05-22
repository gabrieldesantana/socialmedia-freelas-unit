
public class ClienteRepository : IClienteRepository
{
    public Task<bool> DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<List<Cliente>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Cliente> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<Cliente> PostAsync(Cliente entidade)
    {
        throw new NotImplementedException();
    }

    public Task<Cliente> PutAsync(int id, Cliente entidade)
    {
        throw new NotImplementedException();
    }
}