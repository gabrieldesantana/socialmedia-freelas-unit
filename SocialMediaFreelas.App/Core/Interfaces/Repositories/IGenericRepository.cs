﻿namespace SocialMediaFreelas.Core.Interfaces.Repositories
{
    public interface IGenericRepository<T> where T: BaseEntity
    {
        Task<List<T>> GetAllAsync(string? tenantId = "");
        Task<T> GetByIdAsync(int id, string? tenantId = "");
        Task<T> PostAsync(T entidade);
        //Task<T> PutAsync(int id, T entidade, string? tenantId = "");
        Task<bool> DeleteAsync(int id, string? tenantId = "");
    }
}
