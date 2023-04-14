namespace PveSharp.Models;

public class ACL
{
    /// <summary>
    /// Access control path
    /// </summary>
    public string Path { get; set; }
    
    public string RoleId { get; set; }
    
    public string Type { get; set; }
    
    public string Ugid { get; set; }
    
    /// <summary>
    /// Allow to propagate (inherit) permissions. Optional.
    /// </summary>
    public bool? Propagate { get; set; }
}