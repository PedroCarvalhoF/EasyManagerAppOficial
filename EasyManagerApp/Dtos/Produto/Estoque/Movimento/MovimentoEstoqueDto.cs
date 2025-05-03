using System.Text.Json.Serialization;

namespace EasyManagerApp.Dtos.Produto.Estoque.Movimento;
public class MovimentoEstoqueDto
{
    [JsonPropertyName("id")]
    public Guid ProdutoId { get; set; }

    [JsonPropertyName("nomeProduto")]
    public string? NomeProduto { get; set; }

    [JsonPropertyName("filialId")]
    public Guid FilialId { get; set; }

    [JsonPropertyName("nomeFilial")]
    public string? NomeFilial { get; set; }

    [JsonPropertyName("quantidade")]
    public decimal Quantidade { get; set; }

    [JsonPropertyName("tipo")]
    public string? Tipo { get; set; }

    [JsonPropertyName("observacao")]
    public string? Observacao { get; set; }

    [JsonPropertyName("dataMovimentacao")]
    public DateTime DataMovimentacao { get; set; }

    [JsonPropertyName("usuarioRegistroId")]
    public Guid UsuarioRegistroId { get; set; }

    [JsonPropertyName("nomeUsuarioRegistro")]
    public string? NomeUsuarioRegistro { get; set; }

}
