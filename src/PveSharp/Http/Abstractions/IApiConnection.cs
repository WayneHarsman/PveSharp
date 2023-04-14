namespace PveSharp.Http;

public interface IApiConnection
{
    public Uri BaseUri { get; }
    
    /// <summary>
    /// Builds request from metadata and sends it
    /// </summary>
    /// <param name="request">Request object that has endpoint attribute</param>
    /// <param name="cancellationToken"></param>
    /// <typeparam name="T">Response type model</typeparam>
    /// <returns>Response model</returns>
    public Task<T?> SendRequestAsync<T>(object request, CancellationToken cancellationToken);
    
    public Task<T?> SendRequestAsync<T>(IRequest request, CancellationToken cancellationToken);
}