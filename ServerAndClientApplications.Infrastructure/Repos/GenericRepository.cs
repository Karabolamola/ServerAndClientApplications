using Microsoft.EntityFrameworkCore;
using ServerAndClientApplications.Data;
using ServerAndClientApplications.Domain.Interfaces;

namespace ServerAndClientApplications.Infrastructure.Repos;

// The following GenericRepository class Implement the IGenericRepository Interface
// And Here T is going to be a class
// While Creating an Instance of the GenericRepository type, we need to specify the Class Name
// That is we need to specify the actual class name of the type T
public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    // The following variable is going to hold the DBContext instance
    private readonly ApplicationDbContext _context;
    // The following Variable is going to hold the DbSet Entity
    private readonly DbSet<T> _table;

    // Using the Parameterless Constructor, we are initializing the context object and table variable
    public GenericRepository()
    {
        _context = new ApplicationDbContext();
        // Whatever class name we specify while creating the instance of GenericRepository, that class name will be stored in the table variable
        _table = _context.Set<T>();
    }
    
    // Using the Parameterized Constructor, we are initializing the context object and table variable
    public GenericRepository(ApplicationDbContext context)
    {
        _context = context;
        _table = _context.Set<T>();
    }

    // This method will return all the Records from the table
    public async Task<IEnumerable<T>> GetAllAsync()
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