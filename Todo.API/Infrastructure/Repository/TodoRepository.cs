using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository;
public class TodoRepository(ApplicationDbContext dbContext)
    : ITodoInterface
{
    private readonly ApplicationDbContext _dbContext = dbContext;

    public async Task<Todo> CreateAsync(Todo todo)
    {
        _dbContext.Todos.Add(todo);
        await _dbContext.SaveChangesAsync();
        return todo;
    }

    public void Delete(int id)
    {
        var todo = _dbContext.Todos.FirstOrDefault(t => t.Id == id);
        if (todo != null)
        {
            _dbContext.Todos.Remove(todo);
            _dbContext.SaveChanges();
        }
    }

    public Task<IQueryable<Todo>> GetAllAsync(Func<Todo, bool> func)
        => Task.FromResult(_dbContext.Todos.Where(func)
                                           .OrderByDescending(t => t.Created)
                                           .AsQueryable()
                                           .AsNoTracking());

    public async Task<Todo?> GetByIdAsync(int id)
        => await _dbContext.Todos
                           .AsNoTracking()
                           .FirstOrDefaultAsync(t => t.Id == id);

    public async Task<Todo> UpdateAsync(Todo todo)
    {
        _dbContext.Todos.Update(todo);
        await _dbContext.SaveChangesAsync();
        return todo;
    }
}