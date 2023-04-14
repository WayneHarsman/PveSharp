using Microsoft.Extensions.Logging;

namespace PveSharp;

public interface IPveClientConfiguration
{
    /// <summary>
    /// Server ip or hostname
    /// </summary>
    public string Host { get; set; }
    
    /// <summary>
    /// Server port
    /// </summary>
    public int Port { get; set; }
    
    public IAuthenticator Authenticator { get; set; }
    
    public HttpClient HttpClient { get; set; }
    
    public ILogger Logger { get; set; }
}