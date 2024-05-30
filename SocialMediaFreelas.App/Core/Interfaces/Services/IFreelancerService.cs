public interface IFreelancerService 
{
    Task<DefaultResponse<FreelancerViewModel>> GetAllAsync();
    Task<DefaultResponse<FreelancerViewModel>> GetByIdAsync(int id);
    Task<DefaultResponse<Freelancer>> PostAsync(FreelancerInputModel entidade);
    Task<DefaultResponse<Freelancer>> PutAsync(int id, Freelancer entidade);
    Task<bool> DeleteAsync(int id);
    Task<FreelancerViewModel> LoginAsync(string email, string senha);
}