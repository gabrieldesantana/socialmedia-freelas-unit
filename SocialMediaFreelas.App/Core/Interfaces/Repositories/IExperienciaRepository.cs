using SocialMediaFreelas.Core.Interfaces.Repositories;

public interface IExperienciaRepository : IGenericRepository<Experiencia>
{
    Task<Experiencia> PutAsync(int id, Experiencia entidade, string? tenantId = "");
}