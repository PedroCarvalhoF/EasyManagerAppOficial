using EasyManagerApp.Dtos;
using EasyManagerApp.Dtos.Produto;

namespace EasyManagerApp.Services.Intefaces;

public interface IProdutoServices<T> where T : ProdutoDto
{
    Task<RequestResult<T>> CreateAsync(string token, ProdutoDtoCreate produtoCreate);
    Task<RequestResult<T>> UpdateAsync(string token, ProdutoDtoUpdate produtoUpdate);
    Task<RequestResult<T>> SelectAsync(int id);
    Task<RequestResult<IEnumerable<T>>> SelectAsync(string token);
}

