namespace Application.DTOs.TodoDtos;
public record TodoDto(
    int Id,
    string Title,
    DateTime? DeadLine,
    bool IsCompleted,
    string UserId
);