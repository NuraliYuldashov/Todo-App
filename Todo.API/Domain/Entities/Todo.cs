using Domain.Entities.Identity;

namespace Domain.Entities;
public class Todo
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public bool IsCompleted { get; set; }
    public DateTime? DeadLine { get; set; }
    public DateTime Created { get; set; } = DateTime.Now;

    public string UserId { get; set; } = string.Empty;
    public ApplicationUser? User { get; set; } = null;
}