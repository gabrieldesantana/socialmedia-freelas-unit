public interface IExperienciaService
{
    Task<List<Experiencia>> GetAllAsync();
    Task<Experiencia> GetByIdAsync(int id);
    Task<Experiencia> PostAsync(Experiencia entidade);
    Task<Experiencia> PutAsync(int id, Experiencia entidade);
    Task<bool> DeleteAsync(int id);
}