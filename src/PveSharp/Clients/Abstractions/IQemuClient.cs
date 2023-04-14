using PveSharp.Models;

namespace PveSharp.Clients.Abstractions;


public interface IQemuClient
{
    /// <summary>
    /// Virtual machine index
    /// </summary>
    /// <param name="node">The cluster node name</param>
    /// <returns>List of vm's</returns>
    public Task<List<QemuStatus>?> Vms(string node);

    
    /// <summary>
    /// Directory index
    /// </summary>
    /// <param name="node">The cluster node name</param>
    /// <param name="vmid">	The (unique) ID of the VM.</param>
    /// <returns>List of subdirectories </returns>
    public Task<List<string>?> GetVmDirIndex(string node, int vmid);

    /// <summary>
    /// Create or restore a virtual machine
    /// </summary>
    /// <param name="node">Target node name</param>
    /// <param name="vmid">Id of new vm</param>
    /// <returns>Internal proxmox task ID</returns>
    public Task<string?> CreateVm(string node, int vmid);
    
    /// <summary>
    /// Destroy the VM and all used/owned volumes. Removes any VM specific permissions and firewall rules
    /// </summary>
    /// <param name="node">The cluster node name.</param>
    /// <param name="vmid">The (unique) ID of the VM.</param>
    /// <param name="destroyUnrefDisks">If set, destroy additionally all disks not referenced in the config but with a matching VMID from all enabled storages.</param>
    /// <param name="purge">Remove VMID from configurations, like backup & replication jobs and HA.</param>
    /// <param name="skipLock">Ignore locks - only root is allowed to use this option.</param>
    /// <returns>Internal proxmox task id</returns>
    public Task<string?> DestroyVm(
        string node, 
        int vmid, 
        bool destroyUnrefDisks = false, 
        bool purge = false, 
        bool skipLock = false);

    /// <summary>
    /// Start virtual machine.
    /// </summary>
    /// <param name="node">The cluster node name.</param>
    /// <param name="vmid">The (unique) ID of the VM.</param>
    /// <returns></returns>
    public Task<string?> StartVm(string node, int vmid);
    
    /// <summary>
    /// Stop virtual machine. The qemu process will exit immediately. Thisis akin to pulling the power plug of a running computer and may damage the VM data.
    /// </summary>
    /// <param name="node"></param>
    /// <param name="vmid"></param>
    /// <returns></returns>
    public Task<string?> StopVm(string node, int vmid);


    /// <summary>
    /// Shutdown virtual machine. This is similar to pressing the power button on a physical machine.This will send an ACPI event for the guest OS, which should then proceed to a clean shutdown.
    /// </summary>
    /// <param name="node">The cluster node name.</param>
    /// <param name="vmid">The (unique) ID of the VM.</param>
    /// <returns></returns>
    public Task<string?> ShutdownVm(string node, int vmid);

}