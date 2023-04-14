using PveSharp.Clients.Abstractions;
using PveSharp.Http;
using PveSharp.Models;

namespace PveSharp;

public class AccessClient : ApiClient, IAccessClient
{
    public AccessClient(IApiConnection api) : base(api)
    {
    }
    
    /*public Task<TicketLogin?> GetTicket(string username, string password)
    {
        var request = new TicketLoginRequest(username, password);
        
        return API.SendRequestAsync<TicketLogin>(request, CancellationToken.None);
    }*/

    public Task<TicketLogin?> GetTicket(string username, string password)
    {
        var request = new TicketLoginRequest(username, password);

        return API.SendRequestAsync<TicketLogin>(request, CancellationToken.None);
    }

    public async Task<List<ACL>?> GetACLs()
    {
        var request = new GetACLsRequest();
        return await API.SendRequestAsync<List<ACL>?>(request, CancellationToken.None);
    }
}