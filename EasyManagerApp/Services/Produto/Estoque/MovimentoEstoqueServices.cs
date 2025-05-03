using EasyManagerApp.Dtos;
using EasyManagerApp.Dtos.Produto.Estoque.Movimento;
using EasyManagerApp.Services.API;
using EasyManagerApp.Services.Intefaces;

namespace EasyManagerApp.Services.Produto.Estoque;
public class MovimentoEstoqueServices : IMovimentoEstoqueServices<MovimentoEstoqueDto>
{
    private readonly IApiServices _apiServices;
    private const string Rota = "MovimentoEstoque/";
    public MovimentoEstoqueServices(IApiServices apiServices)
    {
        _apiServices = apiServices;
    }
    public async Task<RequestResult<IEnumerable<MovimentoEstoqueDto>>> SelectMovimentoFiltro(string token, MovimentoEstoqueDtoFiltro filtroMovimentoEstoque)
    {
        try
        {
            var rota = $"{Rota}select-filtro-movimentacao-produto-estoque";

            var result = await _apiServices.Post<IEnumerable<MovimentoEstoqueDto>>(token, rota, filtroMovimentoEstoque, default);

            return result;
        }
        catch (Exception ex)
        {

            return new RequestResult<IEnumerable<MovimentoEstoqueDto>>(ex);
        }
    }
}
