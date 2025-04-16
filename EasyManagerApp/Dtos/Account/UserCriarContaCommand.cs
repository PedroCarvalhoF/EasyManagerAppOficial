namespace EasyManagerApp.Dtos.Account;

public class UserCriarContaCommand
{
    public UserDtoCriarContaRequest UserDtoCriarContaRequest { get; set; }

    public UserCriarContaCommand(UserDtoCriarContaRequest userDtoCriarContaRequest)
    {
        UserDtoCriarContaRequest = userDtoCriarContaRequest;
    }
}
