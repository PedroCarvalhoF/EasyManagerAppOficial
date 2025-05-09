using System.Text.Json.Serialization;

namespace EasyManagerApp.Dtos.Account;

public class UserDto
{
    [JsonPropertyName("id")]
    public Guid Id { get; set; }

    [JsonPropertyName("nome")]
    public string Nome { get; set; }

    [JsonPropertyName("sobreNome")]
    public string SobreNome { get; set; }

    [JsonPropertyName("email")]
    public string Email { get; set; }
    public UserDto(Guid id, string nome, string sobreNome, string email)
    {
        Id = id;
        Nome = nome;
        SobreNome = sobreNome;
        Email = email;
    }
}
