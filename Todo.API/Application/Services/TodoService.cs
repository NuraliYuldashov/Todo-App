using Application.Common.Exceptions;

namespace Application.Services;
public class TodoService(ITodoInterface todoInterface,
                         IMapper mapper,
                         IValidator<Todo> validator,
                         UserManager<ApplicationUser> userManager)
    : ITodoService
{
    private readonly ITodoInterface _todoInterface = todoInterface;
    private readonly IMapper _mapper = mapper;
    private readonly IValidator<Todo> _validator = validator;
    private readonly UserManager<ApplicationUser> _userManager = userManager;

    public async Task<TodoDto> CreateTodoAsync(AddTodoDto todo)
    {
        var model = _mapper.Map<Todo>(todo);

        var validationResult = _validator.Validate(model);
        if (!validationResult.IsValid)
        {
            throw new ValidationException(validationResult.Errors);
        }

        var user = await _userManager.FindByIdAsync(todo.UserId);
        if (user == null)
        {
            throw new NotFoundException("User not found");
        }

        var todoDto = await _todoInterface.CreateAsync(model);
        return _mapper.Map<TodoDto>(todoDto);
    }

    public async Task DeleteTodoAsync(int id)
    {
        var todo = await _todoInterface.GetByIdAsync(id);
        if (todo is null)
        {
            throw new NotFoundException("Todo not found");
        }
        _todoInterface.Delete(id);
    }

    public async Task<List<TodoDto>> GetTodosAsync(string userId)
    {
        var user = await _userManager.FindByIdAsync(userId);
        if (user == null)
        {
            throw new NotFoundException("User not found");
        }

        var todos = await _todoInterface.GetAllAsync(t => t.UserId == userId);
        return todos.Select(x => _mapper.Map<TodoDto>(x)).ToList();
    }

    public async Task UpdateStatusAsync(int id)
    {
        var todo = await _todoInterface.GetByIdAsync(id);
        if (todo is null)
        {
            throw new NotFoundException("Todo not found");
        }

        todo.IsCompleted = !todo.IsCompleted;
        await _todoInterface.UpdateAsync(todo);
    }

    public async Task<TodoDto> UpdateTodoAsync(TodoDto todo)
    {
        var todoModel = await _todoInterface.GetByIdAsync(todo.Id);
        if (todoModel is null)
        {
            throw new NotFoundException("Todo not found");
        }

        var model = _mapper.Map<Todo>(todo);

        var validationResult = _validator.Validate(model);
        if (!validationResult.IsValid)
        {
            throw new ValidationException(validationResult.Errors);
        }

        var user = await _userManager.FindByIdAsync(todo.UserId);
        if (user == null)
        {
            throw new NotFoundException("User not found");
        }

        var todoDto = await _todoInterface.UpdateAsync(model);
        return _mapper.Map<TodoDto>(todoDto);
    }
}
