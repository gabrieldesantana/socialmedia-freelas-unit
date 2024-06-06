using Microsoft.EntityFrameworkCore;
using SocialMediaFreelas.Infrastructure.Persistence.Repositories;

public class ExperienciaRepository : GenericRepository<Experiencia>,IExperienciaRepository
{

    public ExperienciaRepository(AppDbContext context)
        : base(context)
    {
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

    public override async Task<List<Experiencia>> GetAllAsync(string? tenantId = "")
    {
        return string.IsNullOrEmpty(tenantId)
          ? await _context.Experiencias
          .Include(x => x.Freelancer)
          .Where(x => x.Actived).ToListAsync()
          : await _context.Experiencias
          .Include(x => x.Freelancer)
          .Where(x => x.Actived && x.TenantId == tenantId).ToListAsync();
    }

    public async Task<List<Experiencia>> GetAllByUserIdAsync(int userId)
    {
        return await _context.Experiencias
         .Include(x => x.Freelancer)
         .Where(x => x.Actived && x.FreelancerId == userId).ToListAsync();
    }
}