using PveSharp.Attributes;

namespace PveSharp.Models;

[PostRequest("/nodes/{node}/qemu/{vmid}/status/stop")]
public class StopVmRequest
{
    /// <summary>
    /// The cluster node name.
    /// </summary>
    [InlineParam("node")]
    public string Node { get; }
    
    [InlineParam("vmid")]
    public int VmId { get; }
    
    /// <summary>
    /// Do not deactivate storage volumes.
    /// </summary>
    [QueryParam("keepActive", true)]
    public bool? KeepActive { get; }
    
    /// <summary>
    /// The cluster node name.
    /// </summary>
    [QueryParam("migratedfrom", true)]
    public bool? MigratedFrom { get; }

    [QueryParam("skiplock", true)]
    public bool? SkipLock { get; }
    
    /// <summary>
    /// Wait maximal timeout seconds.
    /// </summary>
    [QueryParam("timeout", true)]
    public uint? Timeout { get; }

    public StopVmRequest(
        string node, 
        int vmId, 
        bool? keepActive = null, 
        bool? migratedFrom = null, 
        bool? skipLock = null,
        uint? timeout = null)
    {
        Node = node;
        VmId = vmId;
        KeepActive = keepActive;
        MigratedFrom = migratedFrom;
        SkipLock = skipLock;
        Timeout = timeout;
    }
}