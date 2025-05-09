using EasyManagerApp.Dtos.Account;

namespace EasyManagerApp.Dtos.Role;
public class RoleUserDto
{    
    public UserDto? UserDto { get; set; }
    public List<RoleDto>? Roles { get; set; } = new List<RoleDto>();
}
