using System.Text.Json.Serialization;

namespace EasyManagerApp.Dtos.Produto.UnidadeMedida;
public class UnidadeMedidaProdutoDto
{
    [JsonPropertyName("id")]
    public Guid Id { get; set; }
    [JsonPropertyName("nome")]
    public string? Nome { get; set; }
    [JsonPropertyName("sigla")]
    public string? Sigla { get; set; }
    [JsonPropertyName("descricao")]
    public string? Descricao { get; set; }
}
