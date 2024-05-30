public interface IVagaRepository 
{
    Task<List<Vaga>> GetAllAsync(string? tenantId);
    Task<Vaga> GetByIdAsync(int id, string? tenantId);
    Task<Vaga> PostAsync(Vaga entidade);
    Task<Vaga> PutAsync(int id, Vaga entidade, string? tenantId);
    Task<bool> DeleteAsync(int id, string? tenantId);
}