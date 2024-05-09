namespace Application.Common.Helpers;
public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<Todo, TodoDto>().ReverseMap();
        CreateMap<AddTodoDto, Todo>();
    }
}