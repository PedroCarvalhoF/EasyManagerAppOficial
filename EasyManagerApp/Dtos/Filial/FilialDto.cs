using System.Text.Json.Serialization;

namespace EasyManagerApp.Dtos.Filial;
public class FilialDto
{
    [JsonPropertyName("id")]
    public Guid Id { get; set; }

    [JsonPropertyName("nomeFilial")]
    public string NomeFilial { get; set; }
    public FilialDto(Guid id, string nomeFilial)
    {
        Id = id;
        NomeFilial = nomeFilial;
    }
}