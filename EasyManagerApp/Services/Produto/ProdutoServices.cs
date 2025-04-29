using EasyManagerApp.Dtos;
using EasyManagerApp.Dtos.Produto;
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
    public Task<RequestResult<ProdutoDto>> SelectAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<RequestResult<IEnumerable<ProdutoDto>>> SelectAsync(string token)
    {
        string rota = Rota;
        return await _apiServices.Get<IEnumerable<ProdutoDto>>(token, rota, null, default);
    }
    public async Task<RequestResult<ProdutoDto>> CreateAsync(string token, ProdutoDtoCreate produtoCreate)
    {
        try
        {
            string rota = Rota;

            return await _apiServices.Post<ProdutoDto>(token, rota, produtoCreate, default);
        }
        catch (Exception ex)
        {

            throw new Exception(ex.Message);
        }
    }

    public async Task<RequestResult<ProdutoDto>> UpdateAsync(string token, ProdutoDtoUpdate produtoUpdate)
    {
        try
        {
            string rota = Rota ;

            return await _apiServices.Put<ProdutoDto>(token, rota, produtoUpdate, default);
        }
        catch (Exception ex)
        {

            throw new Exception(ex.Message);
        }
    }



    //public async Task<RequestResult<ProdutoDto>> CadastrarProduto(string token, ProdutoDtoCreate produtoCreate, CancellationToken cancellationToken = default)
    //{
    //    string rota = Rota + "cadastrar-produto";
    //    return await _apiServices.Post<ProdutoDto>(token, rota, produtoCreate, cancellationToken);
    //}

    //public async Task<RequestResult<IEnumerable<ProdutoDto>>> ConsultarProdutos(string token, CancellationToken cancellationToken = default)
    //{
    //    string rota = Rota + "consultar-produtos";
    //    return await _apiServices.Get<IEnumerable<ProdutoDto>>(token, rota, null, cancellationToken);
    //}
}
