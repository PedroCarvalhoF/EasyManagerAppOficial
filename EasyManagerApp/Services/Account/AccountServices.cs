using EasyManagerApp.Dtos;
using EasyManagerApp.Dtos.Account;
using EasyManagerApp.Services.API;
using EasyManagerApp.Services.Intefaces;

namespace EasyManagerApp.Services.Account;

public class AccountServices : IAccountServices
{
    private readonly IApiServices _apiServices;
    private const string Rota = "account/";
    public AccountServices(IApiServices apiServices)
    {
        _apiServices = apiServices;
    }

    public async Task<RequestResult<UserDto>> CadastrarUsuario<UserDto>(UserCriarContaCommand userCriarContaCommand, CancellationToken cancellationToken = default)
    {
        try
        {
            string rota_destino = "criar-conta-sem-confirmacao-email";
            string rota = Rota + rota_destino;

            return await _apiServices.Post<UserDto>(string.Empty, rota, userCriarContaCommand, cancellationToken);
        }
        catch (Exception ex)
        {

            throw new Exception(ex.Message);
        }
    }

    public async Task<RequestResult<T>> Login<T>(UserLoginCommand command)
    {
        try
        {
            string rota_destino = "login";
            string rota = Rota + rota_destino;
            return await _apiServices.Post<T>(string.Empty, rota, command);
        }
        catch (Exception ex)
        {

            throw new Exception(ex.Message);
        }
    }
}
