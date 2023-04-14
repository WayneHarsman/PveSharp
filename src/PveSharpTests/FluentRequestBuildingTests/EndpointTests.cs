using PveSharp;

namespace Tests;

public class EndpointTests
{
    [Fact]
    public void EndpointTest()
    {
        var req = new TestRequest(12, 12);
        var request = new RequestBuilder()
            .FromMetadata(req)
            .Build();

        Assert.Equal(HttpMethod.Get, request.Method);
    }
}