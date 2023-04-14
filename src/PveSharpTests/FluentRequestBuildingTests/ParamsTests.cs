using PveSharp;

namespace Tests;

public class ParamsTests
{
    [Fact]
    public void ParametersBuilderTest()
    {
        var req = new TestRequest(12, 12);
        var request = new RequestBuilder()
            .FromMetadata(req)
            .Build();

        Assert.Contains("12", request.Parameters["vmid"]);
    }

    [Fact]
    public void BoolParamTest()
    {
        var req = new TestRequest(12, 12, false);
        var request = new RequestBuilder()
            .FromMetadata(req)
            .Build();

        Assert.Equal("0", request.Parameters["something"]);
    }

    [Fact]
    public void InlineParamsBuilderTest()
    {
        var req = new TestRequest(12, 12);
        var request = new RequestBuilder()
            .FromMetadata(req)
            .Build();

        Assert.Contains("nodes/12/qemu", request.Endpoint.ToString());
    }
}