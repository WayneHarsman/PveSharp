using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PveSharp.Models;

namespace Tests;

public class DeserializationTests
{
    [Fact]
    public void TestNodesResponse()
    {
        using var fs = File.Open("./JsonData/NodeResponse.json", FileMode.Open);
        var json = new StreamReader(fs).ReadToEnd();

        var j = JObject.Parse(json)["data"];
        var deserialized = JsonConvert.DeserializeObject<List<NodeStatus>>(j.ToString());

        Assert.NotNull(deserialized);
        Assert.NotEmpty(deserialized);
        Assert.DoesNotContain(deserialized, x => x.Node is null);
    }
}