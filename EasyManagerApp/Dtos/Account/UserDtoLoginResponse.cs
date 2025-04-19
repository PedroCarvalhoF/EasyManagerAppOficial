using System.Text.Json.Serialization;

namespace EasyManagerApp.Dtos.Account;

public class UserDtoLoginResponse
{
    [JsonPropertyName("sucesso")]
    public bool Sucesso => !Erros.Any();
    [JsonPropertyName("erros")]
    public List<string> Erros { get; } = new();
    [JsonPropertyName("idUser")]
    public Guid IdUser { get; set; }
    [JsonPropertyName("nome")]
    public string? Nome { get; set; }
    [JsonPropertyName("email")]
    public string? Email { get; set; }
    [JsonPropertyName("accessToken")]
    public string? AccessToken { get; set; }
    [JsonPropertyName("refreshToken")]
    public string? RefreshToken { get; set; }

    public UserDtoLoginResponse() { }
    public UserDtoLoginResponse(string accessToken, string refreshToken)
    {
        AccessToken = accessToken;
        RefreshToken = refreshToken;
    }
    public void DefinirDetalhesUsuario(Guid idUser, string nome, string email)
    {
        IdUser = idUser;
        Nome = nome;
        Email = email;
    }

    public void AdicionarErro(string erro) => Erros.Add(erro);
    public void AdicionarErros(params string[] erros) => Erros.AddRange(erros);
    public void AdicionarErros(IEnumerable<string> erros) => Erros.AddRange(erros);
}
