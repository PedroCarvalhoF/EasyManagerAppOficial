using EasyManagerApp.Dtos;
using EasyManagerApp.Dtos.Produto.Estoque.Movimento;

namespace EasyManagerApp.Services.Intefaces;
public interface IMovimentoEstoqueServices<M> where M : MovimentoEstoqueDto
{
    Task<RequestResult<IEnumerable<M>>> SelectMovimentoFiltro(string token, MovimentoEstoqueDtoFiltro filtroMovimentoEstoque);
}
