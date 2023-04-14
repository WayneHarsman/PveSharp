using PveSharp.Models;

namespace PveSharp.Clients.Abstractions;

public interface IAccessClient
{
    public Task<TicketLogin?> GetTicket(string username, string password);

    public Task<List<ACL>?> GetACLs();
}