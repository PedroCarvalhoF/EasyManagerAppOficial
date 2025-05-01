using EasyManagerApp.Dtos;
using EasyManagerApp.Dtos.Produto.Estoque;
using EasyManagerApp.Services.API;
using EasyManagerApp.Services.Intefaces;

namespace EasyManagerApp.Services.Produto.Estoque;
public class EstoqueProdutoServices : IEstoqueProdutoServices<EstoqueProdutoDto>
{
    private readonly IApiServices _apiServices;
    private const string Rota = "EstoqueProduto/";
    public EstoqueProdutoServices(IApiServices apiServices)
    {
        _apiServices = apiServices;
    }
    public async Task<RequestResult<EstoqueProdutoDto>> MovimentarEstoque(string token, EstoqueProdutoDtoManter estoqueProdutoDto)
    {
        try
        {
            string rota = Rota;

            return await _apiServices.Post<EstoqueProdutoDto>(token, rota, estoqueProdutoDto, default);
        }
        catch (Exception ex)
        {

            throw new Exception(ex.Message);
        }
    }

    public async Task<RequestResult<IEnumerable<EstoqueProdutoDto>>> SelectAllAsync(string token)
    {
        try
        {
            string rota = Rota;

            return await _apiServices.Get<IEnumerable<EstoqueProdutoDto>>(token, rota, null, default);
        }
        catch (Exception ex)
        {

            throw new Exception(ex.Message);
        }
    }
}
