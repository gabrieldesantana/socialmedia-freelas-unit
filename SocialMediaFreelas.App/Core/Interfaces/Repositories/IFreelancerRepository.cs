public interface IFreelancerRepository 
{
    Task<List<Freelancer>> GetAllAsync(string? tenantId);
    Task<Freelancer> GetByIdAsync(int? id, string? tenantId);
    Task<Freelancer> PostAsync(Freelancer entidade);
    Task<Freelancer> PutAsync(int id, Freelancer entidade, string? tenantId);
    Task<bool> DeleteAsync(int id, string? tenantId);
    Task<Freelancer> LoginAsync(string email, string senha);
}