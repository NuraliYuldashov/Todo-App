namespace Application.DTOs.TodoDtos;
public record AddTodoDto ( 
    string Title, 
    DateTime? DeadLine, 
    string UserId
);