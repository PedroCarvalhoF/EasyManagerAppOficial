using EasyManagerApp.Dtos;
using EasyManagerApp.Dtos.Account;

namespace EasyManagerApp.Services.Intefaces;

public interface IAccountServices
{
    Task<RequestResult<T>> CadastrarUsuario<T>(UserCriarContaCommand userCriarContaCommand, CancellationToken cancellationToken = default);
    Task<RequestResult<T>> Login<T>(UserLoginCommand command);
}
