public interface IVagaService
{
    Task<DefaultResponse<VagaViewModel>> GetAllAsync();
    Task<DefaultResponse<VagaViewModel>> GetByIdAsync(int id);
    Task<DefaultResponse<Vaga>> PostAsync(VagaInputModel entidade);
    Task<DefaultResponse<Vaga>> PutAsync(int id, Vaga entidade);
    Task<bool> DeleteAsync(int id);
}