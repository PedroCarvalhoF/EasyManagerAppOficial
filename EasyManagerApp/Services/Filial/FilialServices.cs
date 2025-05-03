using EasyManagerApp.Dtos;
using EasyManagerApp.Dtos.Filial;
using EasyManagerApp.Services.API;
using EasyManagerApp.Services.Intefaces;

namespace EasyManagerApp.Services.Filial;
public class FilialServices : IFilialServices<FilialDto>
{
    private readonly IApiServices _apiServices;
    private readonly string _url = "Filial";
    public FilialServices(IApiServices apiServices)
    {
        _apiServices = apiServices;
    }
    public async Task<RequestResult<IEnumerable<FilialDto>>> SelectAllAsync(string token)
    {
        try
        {
            var ulr = $"{_url}/consultar-filiais";

            var result = await _apiServices.Get<IEnumerable<FilialDto>>(token, ulr);
            return result;

        }
        catch (Exception ex)
        {

            return new RequestResult<IEnumerable<FilialDto>>(ex);
        }

    }
}

