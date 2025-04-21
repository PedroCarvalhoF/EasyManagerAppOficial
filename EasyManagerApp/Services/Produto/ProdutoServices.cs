using EasyManagerApp.Dtos;
using EasyManagerApp.Dtos.Produto;
using EasyManagerApp.Dtos.ProdutoCategoria;
using EasyManagerApp.Services.API;
using EasyManagerApp.Services.Intefaces;

namespace EasyManagerApp.Services.Produto;
public class ProdutoServices : IProdutoServices<ProdutoDto>
{
    private readonly IApiServices _apiServices;
    private const string Rota = "Produto/";
    public ProdutoServices(IApiServices apiServices)
    {
        _apiServices = apiServices;
    }
    public async Task<RequestResult<T>>
        CadastrarProduto<T>(string token, ProdutoDtoCreate produtoCreate, CancellationToken cancellationToken = default)
    {
        try
        {
            string rota_destino = "cadastrar-produto";
            string rota = Rota + rota_destino;

            var result = await _apiServices.Post<T>(token, rota, produtoCreate, cancellationToken);

            return result;
        }
        catch (Exception ex)
        {

            throw new Exception(ex.Message);
        }
    }

    public async Task<RequestResult<IEnumerable<ProdutoDto>>> ConsultarProdutos(string token, CancellationToken cancellationToken = default)
    {
        try
        {
            string rota_destino = "consultar-produtos";
            string rota = Rota + rota_destino;

            var result = await _apiServices.Get<IEnumerable<ProdutoDto>>(token, rota, null, cancellationToken);

            return result;
        }
        catch (Exception ex)
        {

            throw new Exception(ex.Message);
        }
    }
}
