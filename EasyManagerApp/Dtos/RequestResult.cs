using System.Text.Json.Serialization;

namespace EasyManagerApp.Dtos;

public class RequestResult<T>
{
    [JsonPropertyName("status")]
    public bool Status { get; set; }

    [JsonPropertyName("statusCode")]
    public int StatusCode { get; set; }

    [JsonPropertyName("mensagem")]
    public string? Mensagem { get; set; }

    [JsonPropertyName("data")]
    public T? Data { get; set; }

    public RequestResult() { }    
    public RequestResult(bool status, int statusCode, string? mensagem = null, T? data = default)
    {
        Status = status;
        StatusCode = statusCode;
        Mensagem = mensagem;
        Data = data;
    }

    public static RequestResult<T> ErroLeituraAPI()
        => new RequestResult<T>(false, 400, "Erro inesperado. Verifique a conexão.");

    public static RequestResult<T> ErroProcessarResultadoApi(Exception ex)
        => new RequestResult<T>(false, 500, $"Erro ao processar resultado da API: {ex.Message}");

    public static RequestResult<T> ErroRequisicao(string mensagem, int statusCode = 400)
        => new RequestResult<T>(false, statusCode, mensagem);
}
