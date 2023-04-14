using PveSharp.Attributes;

namespace PveSharp.Models;


[PostRequest("/access/ticket")]
public class TicketLoginRequest
{
    [QueryParam("username")]
    public string Username { get; }
    
    [QueryParam("password")]
    public string Password { get; }

    public TicketLoginRequest(string username, string password)
    {
        Username = username;
        Password = password;
    }
}