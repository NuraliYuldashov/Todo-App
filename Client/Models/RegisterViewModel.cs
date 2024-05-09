namespace Client.Models;

public class RegisterViewModel : LoginViewModel
{
    public string FirstName { get; set; } = string.Empty;
    public string? LastName { get; set; } = string.Empty;
    public string ConfirmPassword { get; set; } = string.Empty;

    public List<string> Roles { get; set; } = new() { "User" };
}