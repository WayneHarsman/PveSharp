namespace PveSharp.Clients.Abstractions;

public interface IPveClient
{
    public INodeClient NodeClient { get; }
}