using Microsoft.Extensions.Logging;

namespace PveSharp.Http.Logging;

public class HttpLogger
{
    private ILogger _logger;

    public HttpLogger(ILogger logger)
    {
        _logger = logger;
    }

    public void OnRequest(IRequest request)
    {
        _logger.LogInformation("Sending... [{Method}] {Endpoint}", request.Method, request.Endpoint);
    }
    
    public void OnResponse(IRequest request, HttpResponseMessage response)
    {
        _logger.LogInformation("Received... [{StatusCode}] {ReasonPhrase}", response.StatusCode, response.ReasonPhrase);
    }
}