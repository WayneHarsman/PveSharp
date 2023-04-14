namespace PveSharp.Models;

public class QemuStatus
{
    /// <summary>
    /// QEMU process status (stopped / running )
    /// </summary>
    public string Status { get; set; }
    
    
    /// <summary>
    /// The (unique) ID of the VM. Format: pve-vmid
    /// </summary>
    public uint Vmid { get; set; }
    
    /// <summary>
    /// Maximum usable CPUs
    /// </summary>
    public uint? CPUs { get; set; }
    
    /// <summary>
    /// The current config lock, if any
    /// </summary>
    public string? Lock { get; set; }
    
    /// <summary>
    /// Root disk size in bytes
    /// </summary>
    public ulong? MaxDisk { get; set; }
    
    public string? Name { get; set; }
    
    // TODO: complete this class
}