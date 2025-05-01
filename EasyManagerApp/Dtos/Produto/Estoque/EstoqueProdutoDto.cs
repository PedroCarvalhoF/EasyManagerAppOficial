using System.Text.Json.Serialization;

namespace EasyManagerApp.Dtos.Produto.Estoque;
public class EstoqueProdutoDto
{
    [JsonPropertyName("produtoId")]
    public Guid ProdutoId { get; set; }
    [JsonPropertyName("nomeProduto")]
    public string NomeProduto { get; set; }
    [JsonPropertyName("filialId")]
    public Guid FilialId { get; set; }

    [JsonPropertyName("nomeFilial")]
    public string NomeFilial { get; set; }


    [JsonPropertyName("quantidade")]
    public decimal Quantidade { get; set; }

}

