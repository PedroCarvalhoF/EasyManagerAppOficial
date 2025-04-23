using EasyManagerApp.Dtos;
using EasyManagerApp.Dtos.Produto.UnidadeMedida;

namespace EasyManagerApp.Services.Intefaces;

public interface IUnidadeMedidaProdutoServices<T> where T : UnidadeMedidaProdutoDto
{
    Task<RequestResult<T>> CreateAsync(UnidadeMedidaProdutoDtoCreate unidadeCreate);
    Task<RequestResult<T>> UpdateAsync(UnidadeMedidaProdutoDtoUpdate unidadeUpdate);
    Task<RequestResult<T>> SelectAsync(int id);
    Task<RequestResult<IEnumerable<T>>> SelectAsync();
}

