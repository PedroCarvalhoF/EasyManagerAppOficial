using EasyManagerApp.Dtos;
using EasyManagerApp.Dtos.Produto;

namespace EasyManagerApp.Services.Intefaces;

public interface IProdutoServices<T> where T : ProdutoDto
{
    Task<RequestResult<T>> CadastrarProduto<T>(string token, ProdutoDtoCreate produtoCreate, CancellationToken cancellationToken = default);
    Task<RequestResult<IEnumerable<T>>> ConsultarProdutos(string token, CancellationToken cancellationToken = default);
}
