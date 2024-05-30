using Microsoft.EntityFrameworkCore;

public class ExperienciaRepository : IExperienciaRepository
{
    private readonly AppDbContext _context;

    public ExperienciaRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Experiencia>> GetAllAsync(string? tenantId)
    {
        return await _context.Experiencias
        .Where(x => x.Actived && x.TenantId.ToUpper() == tenantId.ToUpper())
        .ToListAsync();
    }

    public async Task<Experiencia> GetByIdAsync(int id, string? tenantId)
    {
        return await _context.Experiencias.FirstOrDefaultAsync(x => x.Id == id && x.TenantId.ToUpper() == tenantId.ToUpper());
    }

    public async Task<Experiencia> PostAsync(Experiencia entidade)
    {
        await _context.AddAsync(entidade);
        await _context.SaveChangesAsync();
        return entidade;
    }

    public async Task<Experiencia> PutAsync(int id, Experiencia entidade, string? tenantId)
    {
        var entidadeDb = await GetByIdAsync(id, tenantId);
        if (entidadeDb != null)
        {
            try
            {
                var excludedProperties = new[] { "Id", "FreelancerId", "TenantId" };

                foreach (var property in entidadeDb.GetType().GetProperties())
                {
                    if (!excludedProperties.Contains(property.Name) && property.CanWrite)
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
}