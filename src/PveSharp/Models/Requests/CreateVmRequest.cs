using PveSharp.Attributes;

namespace PveSharp.Models;

[PostRequest("/nodes/{node}/qemu")]
public class CreateVmRequest
{
    /// <summary>
    /// The cluster node name
    /// </summary>
    [InlineParam("node")]
    public string Node { get; }
    
    /// <summary>
    /// The (unique) ID of the VM.
    /// </summary>
    [QueryParam("vmid")]
    public int Vmid { get; }

    public CreateVmRequest(string node, int vmid)
    {
        Node = node;
        Vmid = vmid;
    }
}