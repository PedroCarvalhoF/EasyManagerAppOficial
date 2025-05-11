using EasyManagerApp.Dtos;
using EasyManagerApp.Dtos.Role;

namespace EasyManagerApp.Services.Intefaces;
public interface IUserRoleServices<R> where R : RoleDto
{
    Task<RequestResult<IEnumerable<R>>> SelectRolesAscyn(string token);
    Task<RequestResult<RoleUserDto>> SelectRolesUserAscyn(string token,DtoRequestId requestId);
    Task<RequestResult<RoleUserDto>> AdcionarRoleUser(string token, RoleDtoAddRoleUser roleDtoAddRoleUser);
    Task<RequestResult<RoleUserDto>> RemovarRoleUser(string token, RoleDtoRemoverRoleUser roleDtoRemoverRoleUser);
}
