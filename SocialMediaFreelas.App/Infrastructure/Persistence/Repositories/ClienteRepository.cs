using Microsoft.EntityFrameworkCore;

public class ClienteRepository : IClienteRepository
{
    private readonly AppDbContext _context;

    public ClienteRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Cliente>> GetAllAsync()
    {
        return await _context.Clientes
        .Where(x => x.Actived)
        .ToListAsync();
    }

    public async Task<Cliente> GetByIdAsync(int id)
    {
        return await _context.Clientes.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<Cliente> PostAsync(Cliente entidade)
    {
        await _context.AddAsync(entidade);
        await _context.SaveChangesAsync();
        return entidade;
    }

    public async Task<Cliente> PutAsync(int id, Cliente entidade)
    {
        var entidadeDb = await GetByIdAsync(id);
        if (entidadeDb != null)
        {
            try
            {
                // Exclude the 'Id' property from the update
                var excludedProperties = new[] { "Id", "Senha", "TenantId" };

                foreach (var property in entidadeDb.GetType().GetProperties())
                {
                    if (!excludedProperties.Contains(property.Name) && property.CanWrite) // Check for CanWrite
                    {
                        property.SetValue(entidadeDb, entidade.GetType().GetProperty(property.Name).GetValue(entidade));
                    }
                }

                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
            }
        }
        return entidadeDb;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var retorno = await GetByIdAsync(id);
        try
        {
            retorno.Actived = retorno.Actived ? false : true;
            await _context.SaveChangesAsync();
            return true;
        }
        catch (Exception)
        {
        }
        return false;
    }

    public async Task<Cliente> LoginAsync(string email, string senha)
    {
        return await _context.Clientes
            .FirstOrDefaultAsync(
            cliente => cliente.Email.ToUpper() == email.ToUpper()
            &&
            cliente.Senha == senha);
    }
}