using PveSharp.Clients.Abstractions;
using PveSharp.Http;
using PveSharp.Models;

namespace PveSharp;

public class VersionClient : ApiClient, IVersionClient
{
    public VersionClient(IApiConnection api) : base(api)
    {
    }

    public async Task<ApiVersion?> GetVersion()
    {
        var request = new VersionRequest();
        
        return await API.SendRequestAsync<ApiVersion>(request, CancellationToken.None);
    }
}