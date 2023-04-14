using PveSharp.Attributes;

namespace PveSharp.Models;

[GetRequest("/nodes/{node}/tasks")]
public class GetNodeTasksRequest
{
    [InlineParam("node")]
    public string Node { get; }
    
    [QueryParam("errors", true)]
    public bool? Errors { get; }
    
    [QueryParam("limit", true)]
    public ulong? Limit { get; }
    
    [QueryParam("since", true)]
    public ulong? Since { get; }
    
    [QueryParam("source", true)]
    public string? FromSource { get; }
    
    [QueryParam("start", true)]
    public ulong? Start { get; }
    
    [QueryParam("statusfilter", true)]
    public string? WithStatus { get; }
    
    [QueryParam("typefilter", true)]
    public string? OfType { get; }
    
    [QueryParam("until", true)]
    public ulong? Until { get; }
    
    [QueryParam("userfilter", true)]
    public string? FromUser { get; }
    
    [QueryParam("vmid", true)]
    public ulong? VmID { get; }

    public GetNodeTasksRequest(
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
        ulong? vmId = null)
    {
        Node = node;
        Errors = errors;
        Limit = limit;
        Since = since;
        FromSource = fromSource;
        Start = start;
        WithStatus = withStatus;
        OfType = ofType;
        Until = until;
        FromUser = fromUser;
        VmID = vmId;
    }
}