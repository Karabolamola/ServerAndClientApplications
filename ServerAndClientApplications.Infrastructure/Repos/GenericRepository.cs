using Microsoft.EntityFrameworkCore;
using ServerAndClientApplications.Data;
using ServerAndClientApplications.Domain.Interfaces;

namespace ServerAndClientApplications.Infrastructure.Repos;

// The following GenericRepository class Implement the IGenericRepository Interface and Here T is going to be a class
// While Creating an Instance of the GenericRepository type, we need to specify the Class Name that is we need to specify the actual class name of the type T
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
        return await _table.ToListAsync();
    }

    // This method will return the specified record from the table based on the ID which it received as an argument
    public async Task<T?> GetByIdAsync(int id)
    {
        return await _table.FindAsync(id);
    }

    // This method will Insert one object into the table, it will receive the object as an argument which needs to be inserted into the database
    public async Task InsertAsync(T model)
    {
        // It will mark the Entity state as Added State
        await _table.AddAsync(model);
    }

    // This method is going to update the record in the table, it will receive the object as an argument
    public Task UpdateAsync(T model)
    {
        // First attach the object to the table
        _table.Attach(model);
        // Then set the state of the Entity as Modified
        _context.Entry(model).State = EntityState.Modified;
        return Task.CompletedTask;
    }

    // This method is going to remove the record from the table, it will receive the primary key value as an argument whose information needs to be removed from the table
    public async Task DeleteAsync(int id)
    {
        // First, fetch the record from the table
        T? model = await _table.FindAsync(id);
        // This will mark the Entity State as Deleted
        if (model != null)
        {
            _table.Remove(model);
        }
    }

    // This method will make the changes permanent in the database, that means once we call Insert, Update, and Delete Methods, then we need to call the Save method to make the changes permanent in the database
    public async Task SaveAsync()
    {
        await _context.SaveChangesAsync();
    }
}