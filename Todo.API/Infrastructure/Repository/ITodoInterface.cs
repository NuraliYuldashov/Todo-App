using Domain.Entities;

namespace Infrastructure.Repository;
public interface ITodoInterface
{
    public Task<IQueryable<Todo>> GetAllAsync(Func<Todo, bool> func);
    public Task<Todo?> GetByIdAsync(int id);
    public Task<Todo> CreateAsync(Todo todo);
    public Task<Todo> UpdateAsync(Todo todo);
    public void Delete(int id);
}