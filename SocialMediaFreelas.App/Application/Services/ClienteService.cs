using SocialMediaFreelas.Application.ViewModels;

public class ClienteService : IClienteService
{
    private readonly IClienteRepository _repository;
    public ClienteService(IClienteRepository repository)
    {
        _repository = repository;
    }
    public async Task<DefaultResponse<ClienteViewModel>> GetAllAsync(string? tenantId)
    {
        var clientes = await _repository.GetAllAsync(tenantId);

        if (!clientes.Any())
        {
            return new DefaultResponse<ClienteViewModel>
            {
                Success = true,
                ErrorMessage = "Lista vazia",
                Body = new List<ClienteViewModel>()
            };
        }

        return new DefaultResponse<ClienteViewModel>
        {
            Success = true,
            ErrorMessage = string.Empty,
            Body = clientes.Select(x => new ClienteViewModel
            {
                Id = x.Id,
                Nome = x.Nome,
                NumeroDocumento = x.NumeroDocumento,
                Email = x.Email,
                Telefone = x.Telefone
            }).ToList()
        };
    }

    public async Task<DefaultResponse<ClienteViewModel>> GetByIdAsync(int id, string? tenantId)
    {
        var cliente = await _repository.GetByIdAsync(id, tenantId);

        if (cliente == null) return new DefaultResponse<ClienteViewModel>
        {
            Success = false,
            ErrorMessage = "Vazio",
            Body = new List<ClienteViewModel>()
        };

        return new DefaultResponse<ClienteViewModel>
        {
            Success = true,
            ErrorMessage = string.Empty,
            Body = new List<ClienteViewModel>()
            {
                new ()
                {
                Id = cliente.Id,
                NumeroDocumento = cliente.NumeroDocumento,
                Nome = cliente.Nome,
                DataNascimento = cliente.DataNascimento,
                Email = cliente.Email,
                Telefone = cliente.Telefone
                }
            }
        };
    }

    public async Task<DefaultResponse<Cliente>> PostAsync(ClienteInputModel inputModel)
    {
        try
        {
            var clienteNew = new Cliente(
            inputModel.NumeroDocumento,
            inputModel.Nome,
            inputModel.DataNascimento,
            inputModel.Email,
            inputModel.Telefone);

            clienteNew.TenantId = Guid.NewGuid().ToString();
            clienteNew.SetPasswordHash(inputModel.Senha);

            var cliente = await _repository.PostAsync(clienteNew);

            return new DefaultResponse<Cliente>
            {
                Success = true,
                ErrorMessage = string.Empty,
                Body = new List<Cliente>() { cliente }
            };
        }
        catch (Exception ex)
        {
            return new DefaultResponse<Cliente>
            {
                Success = false,
                ErrorMessage = ex.Message.ToString(),
                Body = new List<Cliente>()
            };
        }
    }

    public async Task<DefaultResponse<Cliente>> PutAsync(int id, Cliente entidade, string? tenantId)
    {
        try
        {
            var cliente = await _repository.PutAsync(id, entidade, tenantId);

            return new DefaultResponse<Cliente>
            {
                Success = true,
                ErrorMessage = string.Empty,
                Body = new List<Cliente>() { cliente }
            };

        }
        catch (Exception ex)
        {
            return new DefaultResponse<Cliente>
            {
                Success = false,
                ErrorMessage = ex.Message.ToString(),
                Body = new List<Cliente>()
            };
        }

    }

    public async Task<bool> DeleteAsync(int id, string? tenantId)
    {
        try
        {
            var cliente = await _repository.GetByIdAsync(id, tenantId);
            await _repository.DeleteAsync(cliente.Id, tenantId);
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

        var cliente = await _repository.LoginAsync(email, senhaCriptografada);

        if (cliente == null) return null;

        return new UsuarioViewModel
        {
            TenantId = cliente.TenantId,
            Id = cliente.Id,
            NumeroDocumento = cliente.NumeroDocumento,
            Nome = cliente.Nome,
            DataNascimento = cliente.DataNascimento,
            Email = cliente.Email,
            Telefone = cliente.Telefone
        };
    }
}