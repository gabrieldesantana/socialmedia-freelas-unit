
using Microsoft.EntityFrameworkCore;
using SocialMediaFreelas.Infrastructure.Persistence.Repositories;

public class FreelancerRepository : GenericRepository<Freelancer>, IFreelancerRepository
{

    public FreelancerRepository(AppDbContext context)
        : base(context)
    {
    }

    public async Task<Freelancer> PutAsync(int id, Freelancer entidade, string? tenantId = "")
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

    public override async Task<Freelancer> GetByIdAsync(int id, string? tenantId = "")
    {
        return (string.IsNullOrEmpty(tenantId))
        ? await _dbSet.Include(x => x.Experiencias).FirstOrDefaultAsync(x => x.Id == id)
        : await _dbSet.Include(x => x.Experiencias).FirstOrDefaultAsync(x => x.Id == id && x.TenantId == tenantId);
    }

    public override async Task<List<Freelancer>> GetAllAsync(string? tenantId = "")
    {
        return (string.IsNullOrEmpty(tenantId))
          ? await _dbSet.Include(x => x.Vagas).Where(x => x.Actived).ToListAsync()
          : await _dbSet.Where(x => x.Actived && x.TenantId == tenantId).ToListAsync();
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