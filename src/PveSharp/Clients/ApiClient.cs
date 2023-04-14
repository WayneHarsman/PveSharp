using PveSharp.Http;

namespace PveSharp;

public class ApiClient
{
    protected IApiConnection API { get; }

    public ApiClient(IApiConnection api)
    {
        API = api;
    }
}