using System.Text.Json.Serialization;

namespace EasyManagerApp.Dtos.Role;
public class RoleDto
{
    [JsonPropertyName("id")]
    public Guid Id { get; set; }

    [JsonPropertyName("roleName")]
    public string? RoleName { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    public bool IsSelected { get; set; }
}
