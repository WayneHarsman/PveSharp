using PveSharp.Models;

namespace PveSharp.Clients.Abstractions;

public interface INodeTasksClient
{
    /// <summary>
    /// Read task list for one node (finished tasks).
    /// </summary>
    /// <param name="node">The cluster node name</param>
    /// <returns>List of finished tasks</returns>
    public Task<List<NodeTaskStatus>?> GetTasks(string node);

    /// <summary>
    /// Read task status.
    /// </summary>
    /// <param name="node">The cluster node name</param>
    /// <param name="upid">	The task's unique ID.</param>
    /// <returns>Task status</returns>
    public Task<NodeTaskStatus?> GetTaskStatus(string node, string upid);
}