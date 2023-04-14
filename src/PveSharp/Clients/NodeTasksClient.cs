using PveSharp.Clients.Abstractions;
using PveSharp.Http;
using PveSharp.Models;

namespace PveSharp;

public class NodeTasksClient : ApiClient, INodeTasksClient
{
    public NodeTasksClient(IApiConnection api) : base(api)
    {
    }
    
    public async Task<List<NodeTaskStatus>?> GetTasks(string node)
    {
        var request = new GetNodeTasksRequest(node);
        
        return await API.SendRequestAsync<List<NodeTaskStatus>>(request, CancellationToken.None);
    }

    public async Task<NodeTaskStatus?> GetTaskStatus(string node, string upid)
    {
        var request = new GetNodeTaskStatusRequest(node, upid);
        
        return await API.SendRequestAsync<NodeTaskStatus?>(request, CancellationToken.None);
    }
}