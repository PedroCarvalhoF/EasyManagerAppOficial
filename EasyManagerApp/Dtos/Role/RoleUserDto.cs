using EasyManagerApp.Dtos.Account;
using System.Text.Json.Serialization;

namespace EasyManagerApp.Dtos.Role;
public class RoleUserDto
{
    [JsonPropertyName("userDto")]

    public UserDto? UserDto { get; set; }
    [JsonPropertyName("roles")]
    public List<RoleDto>? Roles { get; set; } = new List<RoleDto>();
}
