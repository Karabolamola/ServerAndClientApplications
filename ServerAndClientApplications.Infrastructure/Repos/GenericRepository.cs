using Microsoft.EntityFrameworkCore;
using ServerAndClientApplications.Data;
using ServerAndClientApplications.Domain.Interfaces;

namespace ServerAndClientApplications.Infrastructure.Repos;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    private readonly ApplicationDbContext _context;
    private readonly DbSet<T> _table;

    public GenericRepository()
    {
        _context = new ApplicationDbContext();
        _table = _context.Set<T>();
    }
    
    public GenericRepository(ApplicationDbContext context)
    {
        _context = context;
        _table = _context.Set<T>();
    }

    public async Task<List<T>> GetAllAsync()
    {
        return await _context.Set<T>().ToListAsync();
    }

    public async Task<T?> GetByIdAsync(int id)
    {
        return await _context.Set<T>().FindAsync(id);
    }

    public async Task InsertAsync(T model)
    {
        await _context.Set<T>().AddAsync(model);
    }

    public Task UpdateAsync(T model)
    {
        _context.Set<T>().Update(model);
        return Task.CompletedTask;
    }

    public Task DeleteAsync(T model)
    {
        _context.Set<T>().Remove(model);
        return Task.CompletedTask;
    }

    public async Task SaveAsync()
    {
        await _context.SaveChangesAsync();
    }
}