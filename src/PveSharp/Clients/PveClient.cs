using PveSharp.Clients.Abstractions;
using PveSharp.Http;

namespace PveSharp;

public class PveClient
{
    public INodeClient NodeClient { get; }
    public INodeQemuClient NodeQemuClient { get; }
    public IAccessClient AccessClient { get; }
    public IVersionClient VersionClient { get; }

    public INodeTasksClient NodeTasksClient { get; }

    public IApiConnection ApiConnection { get; }

    public PveClient(IPveClientConfiguration configuration)
    {
        Uri baseUri = new Uri($"https://{configuration.Host}:{configuration.Port}/api2/json", UriKind.Absolute);

        ApiConnection = new ApiConnection(
            httpClient: configuration.HttpClient,
            baseUri: baseUri,
            authenticator: configuration.Authenticator,
            logger: configuration.Logger);


        // Configuration of clients
        AccessClient = new AccessClient(ApiConnection);
        NodeClient = new NodeClient(ApiConnection);
        NodeQemuClient = new NodeQemuClient(ApiConnection);
        VersionClient = new VersionClient(ApiConnection);
        NodeTasksClient = new NodeTasksClient(ApiConnection);
    }
}