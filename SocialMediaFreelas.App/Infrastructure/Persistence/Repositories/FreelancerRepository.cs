
using Microsoft.EntityFrameworkCore;

public class FreelancerRepository : IFreelancerRepository
{
    private readonly AppDbContext _context;

    public FreelancerRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Freelancer>> GetAllAsync()
    {
        return await _context.Freelancers
        .Where(freelancer => freelancer.Actived)
        .ToListAsync();
    }

    public async Task<Freelancer> GetByIdAsync(int id)
    {
        return await _context.Freelancers.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<Freelancer> PostAsync(Freelancer entidade)
    {
        await _context.AddAsync(entidade);
        await _context.SaveChangesAsync();
        return entidade;
    }

    public async Task<Freelancer> PutAsync(int id, Freelancer entidade)
    {
        var entidadeDb = await GetByIdAsync(id);
        if (entidadeDb != null)
        {
            try
            {
                _context.Entry(entidadeDb).CurrentValues.SetValues(entidade);
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
}