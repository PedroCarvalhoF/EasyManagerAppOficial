namespace EasyManagerApp.Dtos.Account;

public class UserLoginCommand
{
    public UserDtoLoginRequest UserLoginDtoRequest { get; set; }

    public UserLoginCommand(UserDtoLoginRequest userLoginDtoRequest)
    {
        UserLoginDtoRequest = userLoginDtoRequest;
    }
}
