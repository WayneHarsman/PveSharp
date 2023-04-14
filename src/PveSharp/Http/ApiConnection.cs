using System.Net;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using PveSharp.Http.Deserialization;
using PveSharp.Http.Exceptions;
using PveSharp.Http.Extensions;
using PveSharp.Http.Logging;

namespace PveSharp.Http;

public class ApiConnection : IApiConnection
{
    public Uri BaseUri { get; }

    private readonly HttpClient _httpClient;
    private readonly HttpLogger? _httpLogger;
    
    public event Action<IRequest> OnRequest;
    public event Action<IRequest, HttpResponseMessage> OnResponse;

    public ApiConnection(HttpClient httpClient, Uri baseUri, IAuthenticator authenticator, ILogger? logger = null)
    {
        _httpClient = httpClient;
        BaseUri = baseUri;
        _httpClient.BaseAddress = baseUri;
        _httpLogger = logger is not null ? new HttpLogger(logger) : null;


        // Add authenticator to the request pipeline
        OnRequest += authenticator.Apply;
        
        if (_httpLogger is not null)
        {
            OnRequest += _httpLogger.OnRequest;
            OnResponse += _httpLogger.OnResponse;
        }
    }

    public async Task<T?> SendRequestAsync<T>(object apiRequest, CancellationToken cancellationToken = default)
    {
        var request = new RequestBuilder()
            .WithBaseAddress(BaseUri)
            .FromMetadata(apiRequest)
            .WithDefaults()
            .Build();
        
        return await SendRequestAsync<T>(request, cancellationToken);
    }

    public async Task<T?> SendRequestAsync<T>(IRequest request, CancellationToken cancellationToken = default)
    {
        OnRequest?.Invoke(request);
        
        var response = await _httpClient.SendRequestAsync(request, cancellationToken);
        OnResponse?.Invoke(request, response);
        
        // TODO: add retry logic
        
        ProcessErrors(request, response);
        
        // Since we handle common errors in ProcessErrors we can assume that the response is OK.
        var data = await response.Content.ReadAsStringAsync(cancellationToken);
        return DeserializeData<T>(data);
    }
    
    // TODO: move to utils?
    private static T? DeserializeData<T>(string response)
    {
        // There is always a "data" field in the response. Even if it's empty.
        return JsonConvert.DeserializeObject<PveResponse<T>>(response)!.Data;
    }

    private void ProcessErrors(IRequest request, HttpResponseMessage response)
    {
        if ((int)response.StatusCode > 200 && (int)response.StatusCode < 399)
            return;

        if (response.StatusCode is HttpStatusCode.Unauthorized or HttpStatusCode.Forbidden)
            throw new UnauthorizedException(request, response.ReasonPhrase);
        
        if (response.StatusCode is HttpStatusCode.NotFound)
            throw new Exception("Requested endpoint not found.");
    }
}