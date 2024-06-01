using Microsoft.EntityFrameworkCore;
using SocialMediaFreelas.Infrastructure.Persistence.Repositories;

public class ClienteRepository : GenericRepository<Cliente>, IClienteRepository
{
    public ClienteRepository(AppDbContext context)
        :base(context)
    {
    }

    public async Task<Cliente> PutAsync(int id, Cliente entidade, string? tenantId)
    {
        var entidadeDb = await GetByIdAsync(id, tenantId);
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

    public async Task<Cliente> LoginAsync(string email, string senha)
    {
        return await _context.Clientes
            .FirstOrDefaultAsync(
            cliente => cliente.Email.ToUpper() == email.ToUpper()
            &&
            cliente.Senha == senha);
    }
}