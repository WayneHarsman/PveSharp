namespace PveSharp.Models;

public class NodeTaskStatus
{
    public string Id { get; set; }
    
    public string Node { get; set; }
    
    public ulong Pid { get; set; }
    
    public ulong PStart { get; set; }
    
    public ulong StartTime { get; set; }
    
    public string Type { get; set; }
    
    public string UPid { get; set; }
    
    public string User { get; set; }
    
    public ulong? EndTime { get; set; }
    
    public string? Status { get; set; }
    
    public string? ExitStatus { get; set; }
}