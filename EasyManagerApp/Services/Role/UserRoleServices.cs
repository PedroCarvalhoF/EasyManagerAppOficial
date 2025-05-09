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
}
