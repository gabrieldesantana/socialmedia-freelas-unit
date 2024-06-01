using SocialMediaFreelas.Application.ViewModels;
using SocialMediaFreelas.Frontend.Enums;

public class FreelancerService : IFreelancerService
{
    private readonly IFreelancerRepository _repository;
    public FreelancerService(IFreelancerRepository repository)
    {
        _repository = repository;
    }
    public async Task<DefaultResponse<FreelancerViewModel>> GetAllAsync(string? tenantId = "")
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

    public async Task<DefaultResponse<FreelancerViewModel>> GetByIdAsync(int id, string? tenantId = "")
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
            inputModel.Nome,
            inputModel.NumeroDocumento,
            inputModel.DataNascimento,
            inputModel.Email,
            inputModel.Telefone,
            inputModel.PretensaoSalarial);

            freelancerNew.TenantId = Guid.NewGuid().ToString();
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

    public async Task<DefaultResponse<Freelancer>> PutAsync(int id, Freelancer entidade, string? tenantId = "")
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

    public async Task<bool> DeleteAsync(int id, string? tenantId = "")
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

    public async Task<UsuarioViewModel> LoginAsync(string email, string senha)
    {
        var senhaCriptografada = senha.GenerateHash();

        var freelancer = await _repository.LoginAsync(email, senhaCriptografada);

        if (freelancer == null) return null;

        return new UsuarioViewModel
        {
            UserId = freelancer.Id,
            TenantId = freelancer.TenantId,
            Nome = freelancer.Nome,
            Email = freelancer.Email,
            Role = EUserRole.Freelancer
        };
    }
}