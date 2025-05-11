using EasyManagerApp.Dtos;
using EasyManagerApp.Dtos.Role;
using EasyManagerApp.Services.API;
using EasyManagerApp.Services.Intefaces;

namespace EasyManagerApp.Services.Role;
public class UserRoleServices : IUserRoleServices<RoleDto>
{
    private const string Rota = "accountuserrolecontrolle/";
    private readonly IApiServices _apiServices;
    public UserRoleServices(IApiServices apiServices)
    {
        _apiServices = apiServices;
    }



    public async Task<RequestResult<IEnumerable<RoleDto>>> SelectRolesAscyn(string token)
    {
        try
        {
            return await _apiServices.Get<IEnumerable<RoleDto>>(token, Rota);
        }
        catch (Exception ex)
        {

            return new RequestResult<IEnumerable<RoleDto>>(ex);
        }
    }

    public async Task<RequestResult<RoleUserDto>> SelectRolesUserAscyn(string token, DtoRequestId requestId)
    {
        try
        {
            var rota = Rota + "select-roles-user";

            return await _apiServices.Post<RoleUserDto>(token, rota, requestId);
        }
        catch (Exception ex)
        {

            return new RequestResult<RoleUserDto>(ex);
        }
    }

    public async Task<RequestResult<RoleUserDto>> AdcionarRoleUser(string token, RoleDtoAddRoleUser roleDtoAddRoleUser)
    {
        try
        {
            var rota = Rota + "AddRoleUser";
            return await _apiServices.Post<RoleUserDto>(token, rota, roleDtoAddRoleUser);
        }
        catch (Exception ex)
        {

            return new RequestResult<RoleUserDto>(ex);
        }
    }

    public async Task<RequestResult<RoleUserDto>> RemovarRoleUser(string token, RoleDtoRemoverRoleUser roleDtoRemoverRoleUser)
    {
        try
        {
            var rota = Rota + "RemoverRoleUser";
            return await _apiServices.Post<RoleUserDto>(token, rota, roleDtoRemoverRoleUser);

        }
        catch (Exception ex)
        {

            return new RequestResult<RoleUserDto>(ex);
        }
    }
}
