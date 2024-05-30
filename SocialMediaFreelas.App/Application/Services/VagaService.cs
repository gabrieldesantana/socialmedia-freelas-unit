public class VagaService : IVagaService
{
    private readonly IVagaRepository _repository;
    public VagaService(IVagaRepository repository)
    {
        _repository = repository;
    }
    public async Task<DefaultResponse<VagaViewModel>> GetAllAsync(string? tenantId)
    {
        var vagas = await _repository.GetAllAsync(tenantId);

        if (!vagas.Any())
        {
            return new DefaultResponse<VagaViewModel>
            {
                Success = true,
                ErrorMessage = "Lista vazia",
                Body = new List<VagaViewModel>()
            };
        }

        return new DefaultResponse<VagaViewModel>
        {
            Success = true,
            ErrorMessage = string.Empty,
            Body = vagas.Select(x => new VagaViewModel
            {
                Id = x.Id,
                Titulo = x.Titulo,
                Descricao = x.Descricao,
                Cargo = x.Cargo,
                Tipo = x.Tipo,
                Remuneracao = x.Remuneracao,
                ClienteId = x.ClienteId,
                FreelancerId = x.FreelancerId
            }).ToList()
        };
    }

    public async Task<DefaultResponse<VagaViewModel>> GetByIdAsync(int id, string? tenantId)
    {
        var vaga = await _repository.GetByIdAsync(id, tenantId);

        if (vaga == null) return new DefaultResponse<VagaViewModel>
        {
            Success = false,
            ErrorMessage = "Vazio",
            Body = new List<VagaViewModel>()
        };

        return new DefaultResponse<VagaViewModel>
        {
            Success = true,
            ErrorMessage = string.Empty,
            Body = new List<VagaViewModel>()
            {
                new ()
                {
                Id = vaga.Id,
                Titulo = vaga.Titulo,
                Descricao = vaga.Descricao,
                Cargo = vaga.Cargo,
                Tipo = vaga.Tipo,
                Remuneracao = vaga.Remuneracao,
                ClienteId = vaga.ClienteId,
                FreelancerId = vaga.FreelancerId
                }
            }
        };
    }

    public async Task<DefaultResponse<Vaga>> PostAsync(VagaInputModel inputModel)
    {
        try
        {
            var vagaNew = new Vaga(
            inputModel.Titulo,
            inputModel.Descricao,
            inputModel.Cargo,
            inputModel.Tipo,
            inputModel.Remuneracao,
            inputModel.ClienteId,
            inputModel.FreelancerId);

            vagaNew.TenantId = Guid.NewGuid().ToString();
            var vaga = await _repository.PostAsync(vagaNew);

            return new DefaultResponse<Vaga>
            {
                Success = true,
                ErrorMessage = string.Empty,
                Body = new List<Vaga>() { vaga }
            };
        }
        catch (Exception ex)
        {
            return new DefaultResponse<Vaga>
            {
                Success = false,
                ErrorMessage = ex.Message.ToString(),
                Body = new List<Vaga>()
            };
        }
    }

    public async Task<DefaultResponse<Vaga>> PutAsync(int id, Vaga entidade, string? tenantId)
    {
        try
        {
            var vaga = await _repository.PutAsync(id, entidade, tenantId);

            return new DefaultResponse<Vaga>
            {
                Success = true,
                ErrorMessage = string.Empty,
                Body = new List<Vaga>() { vaga }
            };

        }
        catch (Exception ex)
        {
            return new DefaultResponse<Vaga>
            {
                Success = false,
                ErrorMessage = ex.Message.ToString(),
                Body = new List<Vaga>()
            };
        }

    }

    public async Task<bool> DeleteAsync(int id, string? tenantId)
    {
        try
        {
            var vaga = await _repository.GetByIdAsync(id, tenantId);
            await _repository.DeleteAsync(vaga.Id, tenantId);
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }
}