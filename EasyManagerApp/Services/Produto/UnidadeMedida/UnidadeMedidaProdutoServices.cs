using EasyManagerApp.Dtos;
using EasyManagerApp.Dtos.Produto.UnidadeMedida;
using EasyManagerApp.Services.API;
using EasyManagerApp.Services.Intefaces;

namespace EasyManagerApp.Services.Produto.UnidadeMedida;

public class UnidadeMedidaProdutoServices : IUnidadeMedidaProdutoServices<UnidadeMedidaProdutoDto>
{
    private readonly IApiServices _apiServices;
    private const string Rota = "UnidadeMedidaProduto/";
    public UnidadeMedidaProdutoServices(IApiServices apiServices)
    {
        _apiServices = apiServices;
    }
    public async Task<RequestResult<UnidadeMedidaProdutoDto>> SelectAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<RequestResult<IEnumerable<UnidadeMedidaProdutoDto>>> SelectAsync()
    {
        try
        {
            string rota_destino = "consultar-unidades-medidas-produtos";
            string rota = Rota + rota_destino;

            var result = await _apiServices.Get<IEnumerable<UnidadeMedidaProdutoDto>>(string.Empty, rota, null, default);

            return result;
        }
        catch (Exception ex)
        {

            throw new Exception(ex.Message);
        }
    }
    public Task<RequestResult<UnidadeMedidaProdutoDto>> CreateAsync(UnidadeMedidaProdutoDtoCreate unidadeCreate)
    {
        throw new NotImplementedException();
    }
    public Task<RequestResult<UnidadeMedidaProdutoDto>> UpdateAsync(UnidadeMedidaProdutoDtoUpdate unidadeUpdate)
    {
        throw new NotImplementedException();
    }
}
