using SocialMediaFreelas.Core.Interfaces.Repositories;

public interface IVagaRepository : IGenericRepository<Vaga>
{
    Task<Vaga> PutAsync(int id, Vaga entidade, string? tenantId = "");

    Task<bool> AddFreelancerAsync(int idVaga, int idFreelancer);
}