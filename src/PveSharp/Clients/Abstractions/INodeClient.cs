using PveSharp.Models;

namespace PveSharp.Clients.Abstractions;

public interface INodeClient
{
    public Task<List<NodeStatus>?> Nodes();
}