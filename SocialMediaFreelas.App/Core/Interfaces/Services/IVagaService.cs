public interface IVagaService
{
    Task<List<Vaga>> GetAllAsync();
    Task<Vaga> GetByIdAsync(int id);
    Task<Vaga> PostAsync(Vaga entidade);
    Task<Vaga> PutAsync(int id, Vaga entidade);
    Task<bool> DeleteAsync(int id);
}