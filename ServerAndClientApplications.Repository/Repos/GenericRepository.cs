using ServerAndClientApplications.Repository.Interfaces;

namespace ServerAndClientApplications.Repository.Repos;

public class GenericRepository<T> : IGenericRepository
{
    private readonly GenericApplicationDbContext<T> _context = new GenericApplicationDbContext<T>();
    public async Task<List<T>> GetAllAsync()
    {
        return await _context.DbSets.ToListAsync();
        // return await _context.Set<T>().ToListAsync();
    }

    public async Task<T?> GetByIdAsync(int id)
    {
        return await _context.DbSets.SingleAsync(x => x.Id == id);
        // return await _context.Set<T>().FindAsync(id);
    }

    public async Task InsertAsync(T model)
    {
        await _context.DbSets.AddAsync(model);
    }

    public Task UpdateAsync(T model)
    {
        _context.DbSets.Update(model);
        return Task.CompletedTask;
    }

    public Task DeleteAsync(T model)
    {
        _context.DbSets.Remove(model);
        return Task.CompletedTask;
    }

    public async Task SaveAsync()
    {
        await _context.SaveChangesAsync();
    }
}