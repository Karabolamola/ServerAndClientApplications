namespace ServerAndClientApplications.Domain.Interfaces;

public interface IGenericRepository<T>
{
    Task<List<T>> GetAllAsync();
    Task<T?> GetByIdAsync(int id);
    Task InsertAsync(T model);
    Task UpdateAsync(T model);
    Task DeleteAsync(T model);
    Task SaveAsync();
}