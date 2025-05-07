using EasyManagerApp.Dtos;
using EasyManagerApp.Dtos.UsuarioVinculadoCliente;
using EasyManagerApp.Services.API;
using EasyManagerApp.Services.Intefaces;

namespace EasyManagerApp.Services.UsuarioClienteVinculo;
public class UsuarioClienteVinculoServices : IUsuarioClienteVinculoServices<UsuarioVinculadoClienteDto>
{
    private readonly IApiServices _apiServices;
    private const string Rota = "UsuarioClienteVinculo/";
    public UsuarioClienteVinculoServices(IApiServices apiServices)
    {
        _apiServices = apiServices;
    }
    public async Task<RequestResult<IEnumerable<UsuarioVinculadoClienteDto>>> SelectUsuariosVinculadosByClienteAsync(string token)
    {
        try
        {
            //api/usuarioclientevinculo/select-usuarios-vinculados-by-cliente-id
            string rota = Rota + "select-usuarios-vinculados-by-cliente-id";
            return await _apiServices.Get<IEnumerable<UsuarioVinculadoClienteDto>>(token, rota, null, default);
        }
        catch (Exception ex)
        {

            return new RequestResult<IEnumerable<UsuarioVinculadoClienteDto>>(ex);
        }
    }
    public async Task<RequestResult<UsuarioVinculadoClienteDto>> VincularUsuarioAoClienteAsync(UsuarioVinculadoClienteDtoRegistrarVinculo dtoRegistrarVinculo, string token)
    {
        try
        {
            //api/usuarioclientevinculo
            string rota = Rota;
            return await _apiServices.Post<UsuarioVinculadoClienteDto>(token, rota, dtoRegistrarVinculo, default);
        }
        catch (Exception ex)
        {

            return new RequestResult<UsuarioVinculadoClienteDto>(ex);
        }
    }
    public async Task<RequestResult<UsuarioVinculadoClienteDto>> LiberarBloquearAcessoUsuarioVinculadoAsync(UsuarioVinculadoClienteDtoLiberarRemoverAcesso liberarRemoverAcesso, string token)
    {
        try
        {
            //api/usuarioclientevinculo/liberar-remover-acesso-usuario-vinculado
            string rota = Rota + "liberar-remover-acesso-usuario-vinculado";
            return await _apiServices.Post<UsuarioVinculadoClienteDto>(token, rota, liberarRemoverAcesso, default);
        }
        catch (Exception ex)
        {

            return new RequestResult<UsuarioVinculadoClienteDto>(ex);
        }
    }
}

