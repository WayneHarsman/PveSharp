using PveSharp.Attributes;

namespace PveSharp.Models;

[PostRequest("/nodes/{node}/qemu/{vmid}/status/shutdown")]
public class ShutdownVmRequest
{
    [InlineParam("node")]
    public string Node { get; }
    
    [InlineParam("vmid")]
    public int VmId { get; }
    
    [QueryParam("forcestop", true)]
    public bool? ForceStop { get; }
    
    [QueryParam("keepActive", true)]
    public bool? KeepActive { get; }
    
    [QueryParam("skiplock", true)]
    public bool? SkipLock { get; }
    
    [QueryParam("timeout", true)]
    public uint? Timeout { get; }

    public ShutdownVmRequest(
        string node, 
        int vmId,
        bool? forceStop = null,
        bool? keepActive = null,
        bool? skipLock = null,
        uint? timeout = null)
    {
        Node = node;
        VmId = vmId;
        ForceStop = forceStop;
        KeepActive = keepActive;
        SkipLock = skipLock;
        Timeout = timeout;
    }
}