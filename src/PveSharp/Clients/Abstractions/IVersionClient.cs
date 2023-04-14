using PveSharp.Models;

namespace PveSharp.Clients.Abstractions;

public interface IVersionClient
{
    public Task<ApiVersion?> GetVersion();
}