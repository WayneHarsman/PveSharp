using PveSharp.Attributes;

namespace PveSharp.Models;

[GetRequest("/nodes/{node}/qemu")]
public class QemuIndexRequest
{
    /// <summary>
    /// The cluster node name
    /// </summary>
    [InlineParam("node")]
    public string Node { get; }

    [QueryParam("full", true)]
    public int Full { get; }
    
    public QemuIndexRequest(string node, bool full = false)
    {
        Node = node;
        Full = full ? 1 : 0;
    }
}