using ServerAndClientApplications.Domain.Interfaces;

namespace ServerAndClientApplications.Infrastructure.Repos;

public class GenericRepository<T> : IGenericRepository<T>
{
    public Task<List<T>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<T?> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task InsertAsync(T model)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(T model)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(T model)
    {
        throw new NotImplementedException();
    }

    public Task SaveAsync()
    {
        throw new NotImplementedException();
    }
}