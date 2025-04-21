using System.Text.Json.Serialization;

namespace EasyManagerApp.Dtos.Produto;

public class ProdutoDto
{
    [JsonPropertyName("id")]
    public Guid Id { get; set; }
    [JsonPropertyName("nomeProduto")]
    public string? NomeProduto { get; set; }
    [JsonPropertyName("codigoProduto")]
    public string? CodigoProduto { get; set; }
    [JsonPropertyName("categoriaProdutoEntityId")]
    public Guid CategoriaProdutoEntityId { get; set; }
    [JsonPropertyName("categoriaProduto")]
    public string? CategoriaProduto { get; set; }
}
