public class ClienteService : IClienteService
{
    private readonly IClienteRepository _repository;
    public ClienteService(IClienteRepository repository)
    {
        _repository = repository;
    }
    public async Task<DefaultResponse<ClienteViewModel>> GetAllAsync()
    {
        var clientes = await _repository.GetAllAsync();

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

    public async Task<DefaultResponse<ClienteViewModel>> GetByIdAsync(int id)
    {
        var cliente = await _repository.GetByIdAsync(id);

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

    public async Task<DefaultResponse<Cliente>> PutAsync(int id, Cliente entidade)
    {
        try
        {
            var cliente = await _repository.PutAsync(id, entidade);

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

    public async Task<bool> DeleteAsync(int id)
    {
        try
        {
            var cliente = await _repository.GetByIdAsync(id);
            await _repository.DeleteAsync(cliente.Id);
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }
}