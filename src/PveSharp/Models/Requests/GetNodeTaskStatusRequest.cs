using PveSharp.Attributes;

namespace PveSharp.Models;

[GetRequest("/nodes/{node}/tasks/{upid}/status")]
public class GetNodeTaskStatusRequest
{
    [InlineParam("node")]
    public string Node { get; }
    
    [InlineParam("upid")]
    public string UPid { get; }

    public GetNodeTaskStatusRequest(string node, string uPid)
    {
        Node = node;
        UPid = uPid;
    }
}