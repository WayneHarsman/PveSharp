namespace PveSharp.Http;

public class Request : IRequest
{
    public Uri BaseAddress { get; }
    public Uri Endpoint { get; }
    
    public Uri FullUri => new Uri($"{BaseAddress}{Endpoint}");
    public IDictionary<string, string> Headers { get; }
    public IDictionary<string, string> Parameters { get; }
    public HttpMethod Method { get; }
    public object? Body { get; set; }

    public Request(Uri baseAddress, Uri endpoint, IDictionary<string, string> headers, IDictionary<string, string> parameters, HttpMethod method, object? body)
    {
        BaseAddress = baseAddress;
        Endpoint = endpoint;
        Headers = headers;
        Parameters = parameters;
        Method = method;
        Body = body;
    }
}