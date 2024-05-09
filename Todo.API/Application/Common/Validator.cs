namespace Application.Common;
public class Validator : AbstractValidator<Todo>
{
    public Validator()
    {
        RuleFor(x => x.Title).NotEmpty()
                             .WithMessage("Title is required");

        RuleFor(x => x.DeadLine).NotEmpty()
                                .WithMessage("DueDate is required");

        RuleFor(x => x.UserId).NotEmpty()
                              .WithMessage("UserId is required");
    }
}