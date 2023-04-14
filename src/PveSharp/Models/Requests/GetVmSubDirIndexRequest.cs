using PveSharp.Attributes;

namespace PveSharp.Models;

[GetRequest("/nodes/{node}/qemu/{vmid}")]
public class GetVmSubDirIndexRequest
{
    [InlineParam("node")]
    public string Node { get; set; }
    
    [InlineParam("vmid")]
    public int VmId { get; set; }

    public GetVmSubDirIndexRequest(string node, int vmId)
    {
        Node = node;
        VmId = vmId;
    }
}