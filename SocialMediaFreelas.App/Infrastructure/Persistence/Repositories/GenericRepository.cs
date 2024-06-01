using Microsoft.EntityFrameworkCore;
using SocialMediaFreelas.Core.Interfaces.Repositories;

namespace SocialMediaFreelas.Infrastructure.Persistence.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        protected readonly AppDbContext _context;
        protected readonly DbSet<T> _dbSet;

        public GenericRepository(AppDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public virtual async Task<List<T>> GetAllAsync(string? tenantId = "")
        {
            return (string.IsNullOrEmpty(tenantId))
              ?  await _dbSet.Where(x => x.Actived).ToListAsync()
              :  await _dbSet.Where(x => x.Actived && x.TenantId == tenantId).ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id, string? tenantId = "")
        {
            return (string.IsNullOrEmpty(tenantId))
            ? await _dbSet.FirstOrDefaultAsync(x => x.Id == id)
            : await _dbSet.FirstOrDefaultAsync(x => x.Id == id && x.TenantId == tenantId);
        }

        public async Task<T> PostAsync(T entidade)
        {
          await _dbSet.AddAsync(entidade);
          await _context.SaveChangesAsync();
          return entidade;
        }

        public async Task<bool> DeleteAsync(int id, string? tenantId = "")
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
    }
}
