using System.Text.Json.Serialization;

namespace EasyManagerApp.Dtos.UsuarioVinculadoCliente;
public class UsuarioVinculadoClienteDto
{
    [JsonPropertyName("clienteId")]
    public Guid ClienteId { get; set; }

    [JsonPropertyName("clienteNome")]
    public string? ClienteNome { get; set; }

    [JsonPropertyName("idUsuarioVinculado")]
    public Guid IdUsuarioVinculado { get; set; }

    [JsonPropertyName("nomeUsuarioVinculado")]
    public string? NomeUsuarioVinculado { get; set; }

    [JsonPropertyName("emailUsuarioVinculado")]
    public string? EmailUsuarioVinculado { get; set; }

    [JsonPropertyName("acessoPermitido")]
    public bool AcessoPermitido { get; set; }
}
