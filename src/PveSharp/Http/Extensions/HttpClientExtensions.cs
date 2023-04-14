using System.Text;
using PveSharp.Utils;

namespace PveSharp.Http.Extensions;

public static class HttpClientExtensions
{
    public static async Task<HttpResponseMessage> SendRequestAsync(this HttpClient client, IRequest request, CancellationToken cancellationToken = default)
    {
        var httpRequest = BuildRequestMessage(request);


        return await client
            .SendAsync(httpRequest, HttpCompletionOption.ResponseContentRead, cancellationToken);
    }
    
    private static HttpRequestMessage BuildRequestMessage(IRequest request)
    {
        var fullUri = request.FullUri.ApplyParameters(request.Parameters);
        var requestMsg = new HttpRequestMessage(request.Method, fullUri);
        foreach (var header in request.Headers)
        {
            requestMsg.Headers.TryAddWithoutValidation(header.Key, header.Value);
        }

        switch (request.Body)
        {
            case HttpContent body:
                requestMsg.Content = body;
                break;
            case string body:
                requestMsg.Content = new StringContent(body, Encoding.UTF8, "application/json");
                break;
            case Stream body:
                requestMsg.Content = new StreamContent(body);
                break;
        }

        return requestMsg;
    }
    
}