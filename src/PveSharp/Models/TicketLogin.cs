namespace PveSharp.Models;

public class TicketLogin
{
    public string Username { get; set; }
    public string? Ticket { get; set; }
    public string? ClusterName { get; set; }
    public string? CSRFPreventionToken { get; set; }

    public string ToHeader()
    {
        return $"PVEAuthCookie=PVE:{Username}:{Ticket}";
    }
}