using EasyManagerApp.Dtos;

namespace EasyManagerApp.Services.Intefaces;

public interface ICategoriaProdutoServices
{
    Task<RequestResult<IEnumerable<T>>> ConsultarCategoriasProdutos<T>(string token, CancellationToken cancellationToken = default);
}
