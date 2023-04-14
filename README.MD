# PveSharp
PveSharp is a .net client library that partially implements proxmox's API.


# Usage
## Create a client

To create a client, you need to create a configuration and authenticator first. To simplify configuration process you can use PveConfigurationBuilder.

```csharp
var authenticator = new TokenAuthenticator("user", "realm", "tokenId", "uuid");

var config = new PveConfigurationBuilder(authenticator)
    .WithHost("host-ip", 8006)
    .Build();

var client = new PveClient(config);
```

## Authentication
For now you can only use token authentication. Refer to proxmox documentation for how to create a token.

```csharp
var authenticator = new TokenAuthenticator("user", "realm", "tokenId", "uuid");
```

PveSharp client will apply provided token as a header to every request when OnRequest event is called.

## Subclients
PveClient has subclients for each proxmox API endpoint. You can access them by using client's properties.

For example, to get a list of nodes in your cluster, you can use NodeClient.
```csharp
List<NodeStatus>? nodes = await client.NodeClient.Nodes();
```

For the sake of consistency, all subclients implement endpoints from a specific folders found in official API reference page.
Since proxmox API contains unholy amount of endpoints, at the moment not all of them are implemented. To avoid nesting hell, subclients are not nested. 
Instead, they are named after the folder they are in. For example, NodeClient contains all endpoints from /nodes folder.

For now there are subclients for:
- /access
- /nodes
- /node/qemu
- /version
- /node/tasks

This list will be updated as more endpoints are implemented. If you need an endpoint that is not implemented, feel free to open an issue or create a pull request.

# Configuration
PveClient requires PveConfiguration to be created. You can create it manually or use PveConfigurationBuilder which is a preferred way.

## Host
You can specify host and port by using WithHost method. Default value for host is localhost. If you don't specify port, it will default to 8006.

```csharp
var config = new PveConfigurationBuilder(authenticator)
    .WithHost("...", 42)
    ...
    .Build();
```

## HttpClient
You can bring your own HttpClient by using WithHttpClient method.

```csharp
var config = new PveConfigurationBuilder(authenticator)
    ...
    .WithHttpClient(...<your http client>...)
    ...
    .Build();
```

Also you can use overload that takes custom delegate for configuring HttpClient. If your node or cluster has selfsigned certificate, you can use following to ignore certificate validation:

```csharp
var config = new PveConfigurationBuilder(authenticator)
    ...
    .WithHttpClient(x => x.WithHandler(ignoreSslErrors: true))
    ...
    .Build();
```

## Logging
PveSharp uses Microsoft.Extensions.Logging for logging. You can configure logging by using PveConfigurationBuilder.

```csharp
var config = new PveConfigurationBuilder(authenticator)
    .WithLogger(...<your logger>...)
    .Build();
```

Also you can use ApiConnection's OnRequest event to log requests and responses.

```csharp
var client = new PveClient(config);
client.ApiConnection.OnRequest += request => Console.WriteLine(request.FullUri);
client.ApiConnection.OnResponse += (request, response) => Console.WriteLine($"{response.StatusCode} {response.ReasonPhrase}");
```

# Manual requests
## Bare requests
If you need to make a request that is not implemented in PveSharp, you can use PveClient's ApiConnection to manually send 
request, but it still will require you to make custom model class for deserialization of the response.

```csharp
Request request = new Request(...<request method, endpoint, etc>...);
var response = await client.ApiConnection.SendRequestAsync<ResponseModel>(request);
```

## Fluent requests
You also can use FluentRequests functionality to make requests. It allows you to build requests fluently from metadata of request model class. 
By using this functionality you can avoid manual configuration of request's parameters, headers, etc.

Let's take a look at DestroyVmRequest:

```csharp
[DeleteRequest("/nodes/{node}/qemu/{vmid}")]
public class DestroyVmRequest
{
    [InlineParam("node")]
    public string Node { get; set; }
    
    [InlineParam("vmid")]
    public int VmId { get; set; }
    
    [QueryParam("destroy-unreferenced-disks", true)]
    public bool? DestroyUnreferencedDisks { get; set; }
    
    [QueryParam("purge", true)]
    public bool? Purge { get; set; }
    
    [QueryParam("skiplock", true)]
    public bool? SkipLock { get; set; }

    public DestroyVmRequest(string node, int vmId, bool? destroyUnreferencedDisks = false, bool? purge = false, bool? skipLock = false)
    {
        Node = node;
        VmId = vmId;
        DestroyUnreferencedDisks = destroyUnreferencedDisks;
        Purge = purge;
        SkipLock = skipLock;
    }
}
```

Any request model class must be decorated with a request attribute. This attribute contains information about request method and endpoint.
For every parameter in endpoint you must create a property and decorate it with InlineParam attribute with exactly same name as it is in endpoint.
Query parameters are passed as query parameters and must be decorated with QueryParam attribute.
Default values for query parameters can be specified in request's constructor. 
If query parameter is marked as optional and default value is null then it will not be included in request.

After all that you can use this request model class to make a request:

```csharp
var request = new DestroyVmRequest("node", 100);
var response = await client.ApiConnection.SendRequestAsync<ResponseModel>(request);
```