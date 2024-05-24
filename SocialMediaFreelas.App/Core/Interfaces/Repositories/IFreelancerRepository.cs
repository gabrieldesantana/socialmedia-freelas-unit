public interface IFreelancerRepository 
{
    Task<List<Freelancer>> GetAllAsync();
    Task<Freelancer> GetByIdAsync(int? id);
    Task<Freelancer> PostAsync(Freelancer entidade);
    Task<Freelancer> PutAsync(int id, Freelancer entidade);
    Task<bool> DeleteAsync(int id);
}