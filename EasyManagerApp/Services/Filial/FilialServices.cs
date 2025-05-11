using EasyManagerApp.Dtos;
using EasyManagerApp.Dtos.Filial;
using EasyManagerApp.Services.API;
using EasyManagerApp.Services.Intefaces;

namespace EasyManagerApp.Services.Filial;
public class FilialServices : IFilialServices<FilialDto>
{
    private readonly IApiServices _apiServices;
    private readonly string _url = "Filial/";
    public FilialServices(IApiServices apiServices)
    {
        _apiServices = apiServices;
    }

    public async Task<RequestResult<FilialDto>> CadastrarFilial(FilialDtoCreate filialDtoCreate, string token)
    {
        try
        {
            var rota = $"{_url}cadastrar-filial";

            var result = await _apiServices.Post<FilialDto>(token, rota, filialDtoCreate);

            return result;
        }
        catch (Exception ex)
        {

            return new RequestResult<FilialDto>(ex);
        }
    }

    public async Task<RequestResult<IEnumerable<FilialDto>>> ConsultarFilialById(string token)
    {
        try
        {
            var rota = $"{_url}consultar-filiais";

            var result = await _apiServices.Get<IEnumerable<FilialDto>>(token, rota);

            return result;
        }
        catch (Exception ex)
        {

            return new RequestResult<IEnumerable<FilialDto>>(ex);
        }
    }
}

