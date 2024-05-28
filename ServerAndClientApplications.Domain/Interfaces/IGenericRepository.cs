namespace ServerAndClientApplications.Domain.Interfaces;

// Here we are creating the IGenericRepository interface as a Generic interface
// Here we are applying the Generic constraint, the constraint is T
// The constraint T is going to be a class
public interface IGenericRepository<T> where T : class
{
    Task<IEnumerable<T>> GetAllAsync();
    Task<T?> GetByIdAsync(int id);
    Task InsertAsync(T model);
    Task UpdateAsync(T model);
    Task DeleteAsync(int id);
    Task SaveAsync();
}