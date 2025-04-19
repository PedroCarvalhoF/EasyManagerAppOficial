using EasyManagerApp.Dtos;
using EasyManagerApp.Dtos.ProdutoCategoria;
using Microsoft.Extensions.Primitives;

namespace EasyManagerApp.Services.Intefaces;

public interface ICategoriaProdutoServices
{
    Task<RequestResult<IEnumerable<T>>> ConsultarCategoriasProdutos<T>(string token, CancellationToken cancellationToken = default);
    Task<RequestResult<T>> CadastrarCategoriaProduto<T>(string token, CategoriaProdutoDtoCreate categoriaCreate, CancellationToken cancellationToken = default);
}
