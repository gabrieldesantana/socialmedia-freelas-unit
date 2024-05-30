public interface IFreelancerService 
{
    Task<DefaultResponse<FreelancerViewModel>> GetAllAsync(string? tenantId);
    Task<DefaultResponse<FreelancerViewModel>> GetByIdAsync(int id, string? tenantId);
    Task<DefaultResponse<Freelancer>> PostAsync(FreelancerInputModel entidade);
    Task<DefaultResponse<Freelancer>> PutAsync(int id, Freelancer entidade, string? tenantId);
    Task<bool> DeleteAsync(int id, string? tenantId);
    Task<FreelancerViewModel> LoginAsync(string email, string senha);
}