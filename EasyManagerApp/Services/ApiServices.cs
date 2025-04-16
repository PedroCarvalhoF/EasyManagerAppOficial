using EasyManagerApp.Dtos;
using EasyManagerApp.Services.API;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace EasyManagerApp.Services;

public class ApiServices : IApiServices
{
    private static readonly HttpClient _httpClient = new()
    {
        BaseAddress = new Uri("https://pw8cff3s-7141.brs.devtunnels.ms/api/"),
        Timeout = TimeSpan.FromSeconds(10) // Evita longos tempos de espera
    };
    public async Task<RequestResult<T>> Post<T>(string? token, string url, object? objPost = null, CancellationToken cancellationToken = default)
    {
        try
        {
            var request = new HttpRequestMessage(HttpMethod.Post, url);

            if (!string.IsNullOrEmpty(token))
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

            if (objPost != null)
            {
                var json = JsonSerializer.Serialize(objPost);
                request.Content = new StringContent(json, Encoding.UTF8, "application/json");
            }

            using var response = await _httpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead, cancellationToken);

            var responseBody = await response.Content.ReadAsStringAsync(cancellationToken);

            if (!response.IsSuccessStatusCode)
            {
                try
                {
                    // Tenta desserializar a resposta como um RequestResult<T>

                    if ((int)response.StatusCode > 500)
                        return RequestResult<T>.ErroRequisicao("Não foi possível acesso com servidor.");

                    var erroResult = JsonSerializer.Deserialize<RequestResult<T>>(responseBody);
                    return erroResult ?? RequestResult<T>.ErroRequisicao("Erro na API desconhecido.", (int)response.StatusCode);
                }
                catch
                {
                    return RequestResult<T>.ErroRequisicao(responseBody, (int)response.StatusCode);
                }
            }

            var result = JsonSerializer.Deserialize<RequestResult<T>>(responseBody);
            return result ?? RequestResult<T>.ErroLeituraAPI();
        }
        catch (TaskCanceledException)
        {
            return RequestResult<T>.ErroRequisicao("Requisição cancelada pelo usuário ou timeout.");
        }
        catch (HttpRequestException ex)
        {
            return RequestResult<T>.ErroRequisicao($"Falha na conexão: {ex.Message}");
        }
        catch (Exception ex)
        {
            return RequestResult<T>.ErroProcessarResultadoApi(ex);
        }
    }
}
