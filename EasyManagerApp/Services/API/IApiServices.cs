using EasyManagerApp.Dtos;

namespace EasyManagerApp.Services.API;

public interface IApiServices
{
    Task<RequestResult<T>> Post<T>(string? token, string url, object? objPost = null, CancellationToken cancellationToken = default);
    Task<RequestResult<T>> Get<T>(string? token, string url, object? objPost = null, CancellationToken cancellationToken = default);
}
