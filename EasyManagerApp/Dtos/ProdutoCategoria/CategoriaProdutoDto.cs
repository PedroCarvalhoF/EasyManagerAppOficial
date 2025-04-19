using System.Text.Json.Serialization;

namespace EasyManagerApp.Dtos.ProdutoCategoria;

public class CategoriaProdutoDto : BaseClienteDto
{
    [JsonPropertyName("nomeCategoria")]
    public required string NomeCategoria { get; set; }
    public string StatusString => Habilitado ? "Categoria Ativa" : "Categoria Inativa";
}
