using System.Text.Json.Serialization;

namespace EasyManagerApp.Dtos;

public abstract class BaseClienteDto
{
    [JsonPropertyName("id")]
    public Guid Id { get; set; }
    [JsonPropertyName("clienteId")]
    public Guid ClienteId { get; set; }
    [JsonPropertyName("usuarioRestroId")]
    public Guid UsuarioRegistroId { get; set; }
    [JsonPropertyName("habilitado")]
    public bool Habilitado { get; set; }
    [JsonPropertyName("createAt")]
    public DateTime CreateAt { get; set; }
    [JsonPropertyName("updateAt")]
    public DateTime UpdateAt { get; set; }
}
