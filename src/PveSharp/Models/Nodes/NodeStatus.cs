namespace PveSharp.Models;

public class NodeStatus
{
    public string Node { get; set; }
    
    public Status Status { get; set; }
    
    public float? CpuUtilization { get; set; }
    
    public string? SupportLevel { get; set; }
    
    public uint? MaxCpu { get; set; }
    
    public ulong? MaxMem { get; set; }
    
    public ulong? Mem { get; set; }
    
    public string? SslFingerprint { get; set; }
    
    public ulong? Uptime { get; set; }

    public NodeStatus()
    {
        Node = string.Empty;
        Status = Status.Unknown;
    }
}