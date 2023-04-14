using PveSharp.Attributes;

namespace PveSharp.Models;

[DeleteRequest("/nodes/{node}/qemu/{vmid}")]
public class DestroyVmRequest
{
    [InlineParam("node")] public string Node { get; set; }

    [InlineParam("vmid")] public int VmId { get; set; }

    [QueryParam("destroy-unreferenced-disks", true)]
    public bool? DestroyUnreferencedDisks { get; set; }

    [QueryParam("purge", true)] public bool? Purge { get; set; }

    [QueryParam("skiplock", true)] public bool? SkipLock { get; set; }

    public DestroyVmRequest(string node, int vmId, bool? destroyUnreferencedDisks = false, bool? purge = false,
        bool? skipLock = false)
    {
        Node = node;
        VmId = vmId;
        DestroyUnreferencedDisks = destroyUnreferencedDisks;
        Purge = purge;
        SkipLock = skipLock;
    }
}