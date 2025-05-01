using EasyManagerApp.Dtos;
using EasyManagerApp.Dtos.Produto.Estoque;

namespace EasyManagerApp.Services.Intefaces;
public interface IEstoqueProdutoServices<E> where E : EstoqueProdutoDto
{
    Task<RequestResult<E>> MovimentarEstoque(string token, EstoqueProdutoDtoManter estoqueProdutoDto);
    Task<RequestResult<IEnumerable<E>>> SelectAllAsync(string token);
}
