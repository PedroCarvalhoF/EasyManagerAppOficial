using System.Text.Json.Serialization;

namespace EasyManagerApp.Dtos.Produto.Estoque;
public class EstoqueProdutoDto
{
    [JsonPropertyName("produtoId")]
    public Guid ProdutoId { get; set; }
    [JsonPropertyName("nomeProduto")]
    public string NomeProduto { get; set; }

    [JsonPropertyName("categoriaProdutoEntityId")]
    public Guid CategoriaProdutoEntityId { get; set; }

    [JsonPropertyName("categoriaProduto")]
    public string CategoriaProduto { get; set; }

    [JsonPropertyName("filialId")]
    public Guid FilialId { get; set; }

    [JsonPropertyName("nomeFilial")]
    public string NomeFilial { get; set; }

    [JsonPropertyName("quantidade")]
    public decimal Quantidade { get; set; }
    [JsonPropertyName("unidadeMedidaProduto")]
    public string UnidadeMedidaProduto { get; set; }

}

