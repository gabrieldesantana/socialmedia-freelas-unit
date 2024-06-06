using Microsoft.EntityFrameworkCore;
using SocialMediaFreelas.Infrastructure.Persistence.Repositories;

public class VagaRepository : GenericRepository<Vaga>, IVagaRepository
{
    public VagaRepository(AppDbContext context)
        : base(context)
    {
    }


    public async Task<Vaga> PutAsync(int id, Vaga entidade, string? tenantId = "")
    {
        var entidadeDb = await GetByIdAsync(id, tenantId);
        if (entidadeDb != null)
        {
            try
            {
                var excludedProperties = new[] { "Id", "ClienteId", "TenantId"};

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

    public override async Task<List<Vaga>> GetAllAsync(string? tenantId = "")
    {
        return string.IsNullOrEmpty(tenantId)
          ? await _context.Vagas
          .Include(x => x.Freelancers)
          .Include(x => x.Cliente)
          .Where(x => x.Actived).ToListAsync()
          : await _context.Vagas
          .Include(x => x.Freelancers)
          .Include(x => x.Cliente)
          .Where(x => x.Actived && x.TenantId == tenantId).ToListAsync();
    }

    public virtual async Task<Vaga> GetByIdAsync(int id, string? tenantId = "")
    {
        return (string.IsNullOrEmpty(tenantId))
        ? await _dbSet.Include(v => v.Freelancers).FirstOrDefaultAsync(x => x.Id == id)
        : await _dbSet.FirstOrDefaultAsync(x => x.Id == id && x.TenantId == tenantId);
    }

    public async Task<bool> AddFreelancerAsync(int idVaga,int idFreelancer)
    {
        var vaga = await GetByIdAsync(idVaga);
        var freelancer = _context.Freelancers.First(x => x.Id == idFreelancer);

        try
        {
            vaga.CadastrarFreelancer(freelancer);

            await _context.SaveChangesAsync();
            return true;
        }
        catch (Exception)
        {
        }
        return false;
    }

    public Task<List<Vaga>> GetAllByFreelancerIdAsync(int freelancerId)
    {
        var vagasPorFreelancer = _context.Vagas.Include(v => v.Freelancers).Where(vaga => vaga.Freelancers.Any(f => f.Id == freelancerId)).Include(c => c.Cliente).ToList();

        return Task.FromResult(vagasPorFreelancer);
    }
}