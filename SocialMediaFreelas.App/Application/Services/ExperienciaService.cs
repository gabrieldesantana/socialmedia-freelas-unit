public class ExperienciaService : IExperienciaService
{
    private readonly IExperienciaRepository _repository;
    public ExperienciaService(IExperienciaRepository repository)
    {
        _repository = repository;
    }
    public async Task<DefaultResponse<ExperienciaViewModel>> GetAllAsync(string? tenantId)
    {
        var experiencias = await _repository.GetAllAsync(tenantId);

        if (!experiencias.Any())
        {
            return new DefaultResponse<ExperienciaViewModel>
            {
                Success = true,
                ErrorMessage = "Lista vazia",
                Body = new List<ExperienciaViewModel>()
            };
        }

        return new DefaultResponse<ExperienciaViewModel>
        {
            Success = true,
            ErrorMessage = string.Empty,
            Body = experiencias.Select(x => new ExperienciaViewModel
            {
                Id = x.Id,
                Projeto = x.Projeto,
                Empresa = x.Empresa,
                Tecnologia = x.Tecnologia,
                Valor = x.Valor,
                Avaliacao = x.Avaliacao,
                FreelancerId = x.FreelancerId
            }).ToList()
        };
    }

    public async Task<DefaultResponse<ExperienciaViewModel>> GetByIdAsync(int id, string? tenantId)
    {
        var experiencia = await _repository.GetByIdAsync(id, tenantId);

        if (experiencia == null) return new DefaultResponse<ExperienciaViewModel>
        {
            Success = false,
            ErrorMessage = "Vazio",
            Body = new List<ExperienciaViewModel>()
        };

        return new DefaultResponse<ExperienciaViewModel>
        {
            Success = true,
            ErrorMessage = string.Empty,
            Body = new List<ExperienciaViewModel>()
            {
                new ()
                {
                Id = experiencia.Id,
                Projeto = experiencia.Projeto,
                Empresa = experiencia.Empresa,
                Tecnologia = experiencia.Tecnologia,
                Valor = experiencia.Valor,
                Avaliacao = experiencia.Avaliacao,
                FreelancerId = experiencia.FreelancerId,
                }
            }
        };
    }

    public async Task<DefaultResponse<Experiencia>> PostAsync(ExperienciaInputModel inputModel)
    {
        try
        {
            var experienciaNew = new Experiencia(
            inputModel.Projeto,
            inputModel.Empresa,
            inputModel.Tecnologia,
            inputModel.Valor,
            inputModel.Avaliacao,
            inputModel.FreelancerId);

            experienciaNew.TenantId = inputModel.TenantIdOwner;

            var experiencia = await _repository.PostAsync(experienciaNew);

            return new DefaultResponse<Experiencia>
            {
                Success = true,
                ErrorMessage = string.Empty,
                Body = new List<Experiencia>() { experiencia }
            };
        }
        catch (Exception ex)
        {
            return new DefaultResponse<Experiencia>
            {
                Success = false,
                ErrorMessage = ex.Message.ToString(),
                Body = new List<Experiencia>()
            };
        }
    }

    public async Task<DefaultResponse<Experiencia>> PutAsync(int id, Experiencia entidade, string? tenantId)
    {
        try
        {
            var experiencia = await _repository.PutAsync(id, entidade, tenantId);

            return new DefaultResponse<Experiencia>
            {
                Success = true,
                ErrorMessage = string.Empty,
                Body = new List<Experiencia>() { experiencia }
            };

        }
        catch (Exception ex)
        {
            return new DefaultResponse<Experiencia>
            {
                Success = false,
                ErrorMessage = ex.Message.ToString(),
                Body = new List<Experiencia>()
            };
        }

    }

    public async Task<bool> DeleteAsync(int id, string? tenantId)
    {
        try
        {
            var experiencia = await _repository.GetByIdAsync(id, tenantId);
            await _repository.DeleteAsync(experiencia.Id, tenantId);
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }
}