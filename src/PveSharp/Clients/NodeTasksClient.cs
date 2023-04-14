using PveSharp.Clients.Abstractions;
using PveSharp.Http;
using PveSharp.Models;

namespace PveSharp;

public class NodeTasksClient : ApiClient, INodeTasksClient
{
    public NodeTasksClient(IApiConnection api) : base(api)
    {
    }

    public async Task<List<NodeTaskStatus>?> GetTasks(
        string node,
        bool? errors = null,
        ulong? limit = null,
        ulong? since = null,
        string? fromSource = null,
        ulong? start = null,
        string? withStatus = null,
        string? ofType = null,
        ulong? until = null,
        string? fromUser = null,
        ulong? vmId = null
    )
    {
        var request = new GetNodeTasksRequest(node, errors, limit, since, fromSource, start, withStatus, ofType, until,
            fromUser, vmId);

        return await API.SendRequestAsync<List<NodeTaskStatus>>(request, CancellationToken.None);
    }

    public async Task<NodeTaskStatus?> GetTaskStatus(string node, string upid)
    {
        var request = new GetNodeTaskStatusRequest(node, upid);

        return await API.SendRequestAsync<NodeTaskStatus?>(request, CancellationToken.None);
    }
}