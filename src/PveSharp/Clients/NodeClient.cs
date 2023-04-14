using PveSharp.Clients.Abstractions;
using PveSharp.Http;
using PveSharp.Models;

namespace PveSharp;

public class NodeClient : ApiClient, INodeClient
{
    public NodeClient(IApiConnection api) : base(api)
    {
    }
    

    public Task<List<NodeStatus>?> Nodes()
    {
        var request = new NodeRequest();

        return API.SendRequestAsync<List<NodeStatus>?>(request, CancellationToken.None);
    }
}