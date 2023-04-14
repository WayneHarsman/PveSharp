using PveSharp.Clients.Abstractions;
using PveSharp.Http;

namespace PveSharp;

public class PveClient : IPveClient
{
    public INodeClient NodeClient { get; }
    public IQemuClient QemuClient { get; }
    public IAccessClient AccessClient { get; }
    public IVersionClient VersionClient { get; }
    
    public INodeTasksClient NodeTasksClient { get; }
    
    private readonly IApiConnection _apiConnection;

    public PveClient(IPveClientConfiguration configuration)
    {
        Uri baseUri = new Uri($"https://{configuration.Host}:{configuration.Port}/api2/json", UriKind.Absolute);

        _apiConnection = new ApiConnection(
            httpClient: configuration.HttpClient,
            baseUri: baseUri,
            authenticator: configuration.Authenticator,
            logger: configuration.Logger);
        

        // Configuration of clients
        AccessClient = new AccessClient(_apiConnection);
        NodeClient = new NodeClient(_apiConnection);
        QemuClient = new QemuClient(_apiConnection);
        VersionClient = new VersionClient(_apiConnection);
        NodeTasksClient = new NodeTasksClient(_apiConnection);
    }
    

}