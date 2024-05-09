using Application.DTOs.TodoDtos;

namespace Application.Interfaces;
public interface ITodoService
{
    Task<List<TodoDto>> GetTodosAsync(string userId);
    Task<TodoDto> UpdateTodoAsync(TodoDto todo);
    Task UpdateStatusAsync(int id);
    Task<TodoDto> CreateTodoAsync(AddTodoDto todo);
    Task DeleteTodoAsync(int id);
}