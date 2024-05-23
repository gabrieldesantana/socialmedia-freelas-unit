public interface IExperienciaService
{
    Task<DefaultResponse<ExperienciaViewModel>> GetAllAsync();
    Task<DefaultResponse<ExperienciaViewModel>> GetByIdAsync(int id);
    Task<DefaultResponse<Experiencia>> PostAsync(ExperienciaInputModel entidade);
    Task<DefaultResponse<Experiencia>> PutAsync(int id, Experiencia entidade);
    Task<bool> DeleteAsync(int id);
}