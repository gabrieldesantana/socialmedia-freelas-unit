public interface IExperienciaRepository 
{
    Task<List<Experiencia>> GetAllAsync(string? tenantId);
    Task<Experiencia> GetByIdAsync(int id, string? tenantId);
    Task<Experiencia> PostAsync(Experiencia entidade);
    Task<Experiencia> PutAsync(int id, Experiencia entidade, string? tenantId);
    Task<bool> DeleteAsync(int id, string? tenantId);
}