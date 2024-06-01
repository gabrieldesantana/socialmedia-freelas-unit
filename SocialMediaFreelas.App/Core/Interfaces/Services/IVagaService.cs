public interface IVagaService
{
    Task<DefaultResponse<VagaViewModel>> GetAllAsync(string? tenantId = "");
    Task<DefaultResponse<VagaViewModel>> GetByIdAsync(int id, string? tenantId = "");
    Task<DefaultResponse<Vaga>> PostAsync(VagaInputModel entidade);
    Task<DefaultResponse<Vaga>> PutAsync(int id, Vaga entidade, string? tenantId = "");
    Task<bool> DeleteAsync(int id, string? tenantId = "");

    Task<bool> AddFreelancerAsync(int idVaga, int idFreelancer);
}