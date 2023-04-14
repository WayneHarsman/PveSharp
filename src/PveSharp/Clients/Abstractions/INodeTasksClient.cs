using PveSharp.Models;

namespace PveSharp.Clients.Abstractions;

public interface INodeTasksClient
{
    /// <summary>
    /// Read task list for one node (finished tasks).
    /// </summary>
    /// <param name="node">The cluster node name.</param>
    /// <param name="errors">Only list tasks with a status of ERROR.</param>
    /// <param name="limit">Only list this amount of tasks.</param>
    /// <param name="since">Only list tasks since this UNIX epoch.</param>
    /// <param name="fromSource">List archived, active or all tasks.</param>
    /// <param name="start">List tasks beginning from this offset.</param>
    /// <param name="withStatus">List of Task States that should be returned</param>
    /// <param name="ofType">Only list tasks of this type (e.g., vzstart, vzdump).</param>
    /// <param name="until">Only list tasks until this UNIX epoch.</param>
    /// <param name="fromUser">Only list tasks from this user.</param>
    /// <param name="vmId">Only list tasks for this VM.</param>
    /// <returns>Node's tasks</returns>
    public Task<List<NodeTaskStatus>?> GetTasks(
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
    );

    /// <summary>
    /// Read task status.
    /// </summary>
    /// <param name="node">The cluster node name</param>
    /// <param name="upid">	The task's unique ID.</param>
    /// <returns>Task status</returns>
    public Task<NodeTaskStatus?> GetTaskStatus(string node, string upid);
}