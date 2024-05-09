using Application.DTOs.ApplicationUserDtos;

namespace Todo.test.BLL;

public static class MockData
{
    public static List<RegisterUser> RegisterUsers => new()
    {
        new()
        {
            FirstName = "Test",
            LastName = "Test",
            Email = "Test@gmail.com",
            PhoneNumber = "123456789",
            Password = "Test12!",
            Roles = new List<string> { "User"}
        },
        new ()
        {
            FirstName = "Test2",
            LastName= "Test2",
            Email = "Test2@gmail.com",
            PhoneNumber= "1234567890",
            Password = "Test123!",
            Roles = new List<string> { "User"}
        }
    };
}
