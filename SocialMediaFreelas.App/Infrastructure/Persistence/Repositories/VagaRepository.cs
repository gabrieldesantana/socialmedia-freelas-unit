using Microsoft.EntityFrameworkCore;

public class VagaRepository : IVagaRepository
{
    private readonly AppDbContext _context;

    public VagaRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Vaga>> GetAllAsync()
    {
        return await _context.Vagas
        .Where(x => x.Actived)
        .ToListAsync();
    }

    public async Task<Vaga> GetByIdAsync(int id)
    {
        return await _context.Vagas.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<Vaga> PostAsync(Vaga entidade)
    {
        await _context.AddAsync(entidade);
        await _context.SaveChangesAsync();
        return entidade;
    }

    public async Task<Vaga> PutAsync(int id, Vaga entidade)
    {
        var entidadeDb = await GetByIdAsync(id);
        if (entidadeDb != null)
        {
            try
            {
                var excludedProperties = new[] { "Id", "ClienteId"};

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
}