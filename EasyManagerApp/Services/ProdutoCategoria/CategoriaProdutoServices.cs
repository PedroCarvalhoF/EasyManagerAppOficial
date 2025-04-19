using EasyManagerApp.Dtos;
using EasyManagerApp.Dtos.ProdutoCategoria;
using EasyManagerApp.Services.API;
using EasyManagerApp.Services.Intefaces;
using System.Threading;

namespace EasyManagerApp.Services.ProdutoCategoria;
public class CategoriaProdutoServices : ICategoriaProdutoServices
{
    private readonly IApiServices _apiServices;
    private const string Rota = "CategoriaProduto/";
    public CategoriaProdutoServices(IApiServices apiServices)
    {
        _apiServices = apiServices;
    }
    public async Task<RequestResult<IEnumerable<CategoriaProdutoDto>>> ConsultarCategoriasProdutos<CategoriaProdutoDto>(string token, CancellationToken cancellationToken = default)
    {
        try
        {
            string rota_destino = "consultar-categorias-produtos";
            string rota = Rota + rota_destino;

            var result = await _apiServices.Get<IEnumerable<CategoriaProdutoDto>>(token, rota, null, cancellationToken);

            return result;
        }
        catch (Exception ex)
        {

            throw new Exception(ex.Message);
        }
    }
}
