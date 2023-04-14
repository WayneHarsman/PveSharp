using PveSharp.Attributes;

namespace PveSharp.Models;

[PostRequest("/nodes/{node}/qemu/{vmid}/status/start")]
public class StartVmRequest
{
    /// <summary>
    /// The cluster node name.
    /// </summary>
    [InlineParam("node")]
    public string Node { get; }
    
    /// <summary>
    /// The (unique) ID of the VM.
    /// </summary>
    [InlineParam("vmid")]
    public int VmId { get; }
    
    /// <summary>
    /// Override QEMU's -cpu argument with the given string.
    /// </summary>
    [QueryParam("force-cpu", true)]
    public string? ForceCPU { get; }
    
    /// <summary>
    /// Specifies the QEMU machine type.
    /// </summary>
    [QueryParam("machine", true)]
    public string? Machine { get; }
    
    /// <summary>
    /// The cluster node name.
    /// </summary>
    [QueryParam("migratedfrom", true)]
    public string? MigratedFrom { get; }
    
    /// <summary>
    /// CIDR of the (sub) network that is used for migration.
    /// </summary>
    [QueryParam("migration_network", true)]
    public string? MigrationNetwork { get; }
    
    /// <summary>
    /// Migration traffic is encrypted using an SSH tunnel by default. On secure, completely private networks this can be disabled to increase performance.
    /// </summary>
    [QueryParam("migration_type", true)]
    public string? MigrationType { get; }
    
    /// <summary>
    /// Ignore locks - only root is allowed to use this option.
    /// </summary>
    [QueryParam("skiplock", true)]
    public bool? SkipLock { get; }
    
    /// <summary>
    /// Some command save/restore state from this location.
    /// </summary>
    [QueryParam("stateuri", true)]
    public string? StateUri { get; }
    
    /// <summary>
    /// Mapping from source to target storages. Providing only a single storage ID maps all source storages to that storage. Providing the special value '1' will map each source storage to itself.
    /// </summary>
    [QueryParam("tagetstorage", true)]
    public string? TargetStorage { get; }
    
    /// <summary>
    /// Wait maximal timeout seconds.
    /// </summary>
    [QueryParam("timeout", true)]
    public ulong? Timeout { get; }

    public StartVmRequest(
        string node,
        int vmId,
        string? forceCpu = null, 
        string? machine = null, 
        string? migratedFrom = null, 
        string? migrationNetwork = null, 
        string? migrationType = null, 
        bool? skipLock = null, 
        string? stateUri = null, 
        string? targetStorage = null, 
        ulong? timeout = null)
    {
        Node = node;
        VmId = vmId;
        ForceCPU = forceCpu;
        Machine = machine;
        MigratedFrom = migratedFrom;
        MigrationNetwork = migrationNetwork;
        MigrationType = migrationType;
        SkipLock = skipLock;
        StateUri = stateUri;
        TargetStorage = targetStorage;
        Timeout = timeout;
    }
}