namespace PveSharp.Models;

public class ApiVersion
{
    /// <summary>
    /// The current Proxmox VE point release in `x.y` format.
    /// </summary>
    public string Release { get; set; }
    
    /// <summary>
    /// The short git revision from which this version was build.
    /// </summary>
    public string RepoId { get; set; }
    
    /// <summary>
    /// The full pve-manager package version of this node.
    /// </summary>
    public string Version { get; set; }
    
    /// <summary>
    /// The default console viewer to use. Optional.
    /// </summary>
    public string? Console { get; set; }
}