
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

    public async Task<Freelancer> LoginAsync(string email, string senha)
    {
        return await _context.Freelancers
            .FirstOrDefaultAsync(
            cliente => cliente.Email.ToUpper() == email.ToUpper()
            &&
            cliente.Senha == senha);
    }
}