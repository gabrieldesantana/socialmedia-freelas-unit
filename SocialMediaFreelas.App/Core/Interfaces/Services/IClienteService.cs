public interface IClienteService 
{
    Task<DefaultResponse<ClienteViewModel>> GetAllAsync();
    Task<DefaultResponse<ClienteViewModel>> GetByIdAsync(int id);
    Task<DefaultResponse<Cliente>> PostAsync(ClienteInputModel entidade);
    Task<DefaultResponse<Cliente>> PutAsync(int id, Cliente entidade);
    Task<bool> DeleteAsync(int id);
}