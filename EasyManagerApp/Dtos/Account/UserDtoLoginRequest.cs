namespace EasyManagerApp.Dtos.Account;

public class UserDtoLoginRequest
{
    public string? Email { get; set; }
    public string? Senha { get; set; }
    public UserDtoLoginRequest() { }
    public UserDtoLoginRequest(string email, string senha)
    {
        Email = email;
        Senha = senha;
    }
}
