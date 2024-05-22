public class FreelancerService : IFreelancerService
{
    private readonly IFreelancerRepository _repository;
    public FreelancerService(IFreelancerRepository repository)
    {
        _repository = repository;
    }
    public async Task<DefaultResponse<FreelancerViewModel>> GetAllAsync()
    {
        var freelancers = await _repository.GetAllAsync();

        if (!freelancers.Any())
        {
            return new DefaultResponse<FreelancerViewModel> 
            {
                Success = true,
                ErrorMessage = "Lista vazia",
                Body = new List<FreelancerViewModel>()
            };
        }

        return new DefaultResponse<FreelancerViewModel> 
            {
                Success = true,
                ErrorMessage = string.Empty,
                Body = freelancers.Select(x => new FreelancerViewModel 
                {
                    Id = x.Id,
                    Nome = x.Nome,
                    NumeroDocumento = x.NumeroDocumento,
                    Email = x.Email,
                    Telefone = x.Telefone,
                    PretensaoSalarial = x.PretensaoSalarial
                }).ToList()
            };
    }

    public async Task<DefaultResponse<FreelancerViewModel>> GetByIdAsync(int id)
    {
        var freelancer = await _repository.GetByIdAsync(id);

        if (freelancer == null) return new DefaultResponse<FreelancerViewModel> 
        {
            Success = false,
            ErrorMessage = "Vazio",
            Body = new List<FreelancerViewModel>()
        };

        return new DefaultResponse<FreelancerViewModel>
        {
            Success = true,
            ErrorMessage = string.Empty,
            Body = new List<FreelancerViewModel>()
            {
                new () 
                {
                Id = freelancer.Id,
                NumeroDocumento = freelancer.NumeroDocumento,
                Nome = freelancer.Nome,
                DataNascimento = freelancer.DataNascimento,
                Email = freelancer.Email,
                Telefone = freelancer.Telefone,
                PretensaoSalarial = freelancer.PretensaoSalarial
                }
            }
        };
    }

    public async Task<DefaultResponse<Freelancer>> PostAsync(FreelancerInputModel inputModel)
    {
        try
        {
            var freelancerNew = new Freelancer(
            inputModel.NumeroDocumento,
            inputModel.Nome,
            inputModel.DataNascimento,
            inputModel.Email,
            inputModel.Telefone,
            inputModel.PretensaoSalarial);

            freelancerNew.SetPasswordHash(inputModel.Senha);
            var freelancer = await _repository.PostAsync(freelancerNew);
        
            return new DefaultResponse<Freelancer>
            {
                Success = true,
                ErrorMessage = string.Empty,
                Body = new List<Freelancer>(){freelancer}
            };
        }
        catch (Exception ex)
        {
            return new DefaultResponse<Freelancer> 
            {
                Success = false,
                ErrorMessage = ex.Message.ToString(),
                Body = new List<Freelancer>()
            };
        }
    }

    public async Task<DefaultResponse<Freelancer>> PutAsync(int id, Freelancer entidade)
    {
        try
        {
            var freelancer = await _repository.PutAsync(id, entidade);

            return new DefaultResponse<Freelancer> 
            {
                Success = true,
                ErrorMessage = string.Empty,
                Body = new List<Freelancer>(){freelancer}
            };

        }
        catch (Exception ex)
        {
            return new DefaultResponse<Freelancer> 
            {
                Success = false,
                ErrorMessage = ex.Message.ToString(),
                Body = new List<Freelancer>()
            };
        }

    }

    public async Task<bool> DeleteAsync(int id)
    {
        try
        {
            var freelancer = await _repository.GetByIdAsync(id);
            await _repository.DeleteAsync(freelancer.Id);
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }
}