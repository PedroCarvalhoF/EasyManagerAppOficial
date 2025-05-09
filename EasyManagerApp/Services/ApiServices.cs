using EasyManagerApp.Dtos;
using EasyManagerApp.Services.API;
using System.Net;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace EasyManagerApp.Services;

public class ApiServices : IApiServices
{
    private static readonly HttpClient _httpClient = new()
    {
        BaseAddress = new Uri("https://pw8cff3s-7141.brs.devtunnels.ms/api/"),
        Timeout = TimeSpan.FromSeconds(10)
    };

    public async Task<RequestResult<T>> Get<T>(string? token, string url, object? body = null, CancellationToken cancellationToken = default)
    {
        var request = new HttpRequestMessage(HttpMethod.Get, url);
        if (!string.IsNullOrEmpty(token))
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

        if (body != null)
        {
            var json = JsonSerializer.Serialize(body);
            request.Content = new StringContent(json, Encoding.UTF8, "application/json");
        }

        return await SendRequest<T>(request, cancellationToken);
    }

    public async Task<RequestResult<T>> Post<T>(string? token, string url, object? body = null, CancellationToken cancellationToken = default)
    {
        var request = new HttpRequestMessage(HttpMethod.Post, url);
        if (!string.IsNullOrEmpty(token))
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

        if (body != null)
        {
            var json = JsonSerializer.Serialize(body);
            request.Content = new StringContent(json, Encoding.UTF8, "application/json");
        }

        return await SendRequest<T>(request, cancellationToken);
    }

    public async Task<RequestResult<T>> Put<T>(string token, string url, object? body, CancellationToken cancellationToken = default)
    {
        var request = new HttpRequestMessage(HttpMethod.Put, url);
        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

        if (body != null)
        {
            var json = JsonSerializer.Serialize(body);
            request.Content = new StringContent(json, Encoding.UTF8, "application/json");
        }

        return await SendRequest<T>(request, cancellationToken);
    }

    private async Task<RequestResult<T>> SendRequest<T>(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        try
        {
            using var response = await _httpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead, cancellationToken);
            var responseBody = await response.Content.ReadAsStringAsync(cancellationToken);

            if (response.IsSuccessStatusCode)
            {
                var successResult = JsonSerializer.Deserialize<RequestResult<T>>(responseBody);
                return successResult ?? RequestResult<T>.ErroLeituraAPI();
            }

            return HandleErrorResponse<T>(response, responseBody);
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

    private static RequestResult<T> HandleErrorResponse<T>(HttpResponseMessage response, string responseBody)
    {
        try
        {
            var statusCode = (int)response.StatusCode;

            return response.StatusCode switch
            {
                HttpStatusCode.BadRequest => RequestResult<T>.ErroRequisicao("Algo deu errado com as informações enviadas. Confira e tente de novo.", statusCode),
                HttpStatusCode.Unauthorized => RequestResult<T>.ErroRequisicao("Você precisa estar logado para fazer isso.", statusCode),
                HttpStatusCode.Forbidden => RequestResult<T>.ErroRequisicao("Você não tem permissão pra isso.", statusCode),
                HttpStatusCode.NotFound => RequestResult<T>.ErroRequisicao("Não encontramos o que você procurava.", statusCode),
                HttpStatusCode.Conflict => RequestResult<T>.ErroRequisicao("Tem algo em conflito com o que você tentou fazer.", statusCode),
                HttpStatusCode.UnprocessableEntity => RequestResult<T>.ErroRequisicao("Algum dado está incorreto. Corrija e tente de novo.", statusCode),
                HttpStatusCode.TooManyRequests => RequestResult<T>.ErroRequisicao("Muitas tentativas em pouco tempo. Espere um pouco e tente de novo.", statusCode),
                HttpStatusCode.InternalServerError => RequestResult<T>.ErroRequisicao("O servidor teve um problema. Tente novamente mais tarde.", statusCode),
                HttpStatusCode.BadGateway => RequestResult<T>.ErroRequisicao("Problema de comunicação com o servidor. Tente mais tarde.", statusCode),
                HttpStatusCode.ServiceUnavailable => RequestResult<T>.ErroRequisicao("O serviço está fora do ar no momento. Tente de novo em breve.", statusCode),
                HttpStatusCode.GatewayTimeout => RequestResult<T>.ErroRequisicao("Demorou demais pra responder. Tente de novo.", statusCode),
                _ when statusCode >= 500 => RequestResult<T>.ErroRequisicao("Algo deu errado do lado do servidor. Tente de novo mais tarde.", statusCode),

                _ => JsonSerializer.Deserialize<RequestResult<T>>(responseBody)
                     ?? RequestResult<T>.ErroRequisicao("Aconteceu um erro inesperado. Tente novamente.", statusCode)
            };
        }
        catch
        {
            return RequestResult<T>.ErroRequisicao($"Não conseguimos entender a resposta do servidor. Detalhes: {responseBody}", (int)response.StatusCode);
        }
    }


}
