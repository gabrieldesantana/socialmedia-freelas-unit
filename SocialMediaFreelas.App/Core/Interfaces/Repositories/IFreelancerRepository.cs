using SocialMediaFreelas.Core.Interfaces.Repositories;

public interface IFreelancerRepository : IGenericRepository<Freelancer>
{
    Task<Freelancer> PutAsync(int id, Freelancer entidade, string? tenantId = "");
    Task<Freelancer> LoginAsync(string email, string senha);
}