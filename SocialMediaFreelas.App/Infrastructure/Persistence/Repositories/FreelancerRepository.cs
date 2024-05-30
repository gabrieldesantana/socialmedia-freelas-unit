
using Microsoft.EntityFrameworkCore;

public class FreelancerRepository : IFreelancerRepository
{
    private readonly AppDbContext _context;

    public FreelancerRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Freelancer>> GetAllAsync(string? tenantId)
    {
        return await _context.Freelancers
        .Where(x => x.Actived && x.TenantId.ToUpper() == tenantId.ToUpper())
        .ToListAsync();
    }

    public async Task<Freelancer> GetByIdAsync(int? id, string? tenantId)
    {
        return await _context.Freelancers.FirstOrDefaultAsync(x => x.Id == id && x.TenantId.ToUpper() == tenantId.ToUpper());
    }

    public async Task<Freelancer> PostAsync(Freelancer entidade)
    {
        await _context.AddAsync(entidade);
        await _context.SaveChangesAsync();
        return entidade;
    }

    public async Task<Freelancer> PutAsync(int id, Freelancer entidade, string? tenantId)
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

    public async Task<bool> DeleteAsync(int id, string? tenantId)
    {
        var retorno = await GetByIdAsync(id, tenantId);
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

    public async Task<Freelancer> LoginAsync(string email, string senha)
    {
        return await _context.Freelancers
            .FirstOrDefaultAsync(
            cliente => cliente.Email.ToUpper() == email.ToUpper()
            &&
            cliente.Senha == senha);
    }
}