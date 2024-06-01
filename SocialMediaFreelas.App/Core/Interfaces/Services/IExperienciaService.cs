public interface IExperienciaService
{
    Task<DefaultResponse<ExperienciaViewModel>> GetAllAsync(string? tenantId = "");
    Task<DefaultResponse<ExperienciaViewModel>> GetByIdAsync(int id, string? tenantId = "");
    Task<DefaultResponse<Experiencia>> PostAsync(ExperienciaInputModel entidade);
    Task<DefaultResponse<Experiencia>> PutAsync(int id, Experiencia entidade, string? tenantId = "");
    Task<bool> DeleteAsync(int id, string? tenantId = "");
}