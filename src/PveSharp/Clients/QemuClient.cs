using PveSharp.Clients.Abstractions;
using PveSharp.Http;
using PveSharp.Models;

namespace PveSharp;

public class QemuClient : ApiClient, IQemuClient
{
    public QemuClient(IApiConnection api) : base(api)
    {
    }

    public async Task<List<QemuStatus>?> Vms(string node)
    {
        var request = new QemuIndexRequest(node, true);

        return await  API.SendRequestAsync<List<QemuStatus>>(request, CancellationToken.None);
    }

    public async Task<List<string>?> GetVmDirIndex(string node, int vmid)
    {
        var request = new GetVmSubDirIndexRequest(node, vmid);

        return await API.SendRequestAsync<List<string>?>(request, CancellationToken.None);
    }

    public async Task<string?> CreateVm(string node, int vmid)
    {
        var request = new CreateVmRequest(node, vmid);

        return await API.SendRequestAsync<string?>(request, CancellationToken.None);
    }

    public async Task<string?> DestroyVm(string node, int vmid, bool destroyUnrefDisks = false, bool purge = false, bool skipLock = false)
    {
        var request = new DestroyVmRequest(node, vmid, destroyUnrefDisks, purge, skipLock);

        return await API.SendRequestAsync<string?>(request, CancellationToken.None);
    }

    public async Task<string?> StartVm(string node, int vmid)
    {
        var request = new StartVmRequest(node, vmid);
        
        return await API.SendRequestAsync<string?>(request, CancellationToken.None);
    }
    
    public async Task<string?> StopVm(string node, int vmid)
    {
        var request = new StopVmRequest(node, vmid);
        
        return await API.SendRequestAsync<string?>(request, CancellationToken.None);
    }
    
    public async Task<string?> ShutdownVm(string node, int vmid)
    {
        var request = new ShutdownVmRequest(node, vmid);
        
        return await API.SendRequestAsync<string?>(request, CancellationToken.None);
    }
}