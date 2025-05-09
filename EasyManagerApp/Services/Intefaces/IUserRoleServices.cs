using EasyManagerApp.Dtos;
using EasyManagerApp.Dtos.Role;

namespace EasyManagerApp.Services.Intefaces;
public interface IUserRoleServices<R> where R : RoleDto
{
    Task<RequestResult<IEnumerable<R>>> SelectRolesAscyn(string token);
}
