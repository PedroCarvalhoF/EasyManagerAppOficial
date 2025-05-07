using EasyManagerApp.Dtos;
using EasyManagerApp.Dtos.UsuarioVinculadoCliente;

namespace EasyManagerApp.Services.Intefaces;
public interface IUsuarioClienteVinculoServices<DTO> where DTO : UsuarioVinculadoClienteDto
{
    Task<RequestResult<DTO>> VincularUsuarioAoClienteAsync(UsuarioVinculadoClienteDtoRegistrarVinculo dtoRegistrarVinculo, string token);
    Task<RequestResult<DTO>> LiberarBloquearAcessoUsuarioVinculadoAsync(UsuarioVinculadoClienteDtoLiberarRemoverAcesso liberarRemoverAcesso, string token);
    Task<RequestResult<IEnumerable<DTO>>> SelectUsuariosVinculadosByClienteAsync(string token);
}
