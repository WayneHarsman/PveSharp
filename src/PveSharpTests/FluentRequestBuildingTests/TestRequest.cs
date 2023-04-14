using PveSharp;
using PveSharp.Attributes;

namespace Tests;

[GetRequest("nodes/{id}/qemu")]
public class TestRequest
{
    [InlineParam("id")] public int Id { get; }

    [QueryParam("vmid", formatter: typeof(DefaultValueFormatter))]
    public int Vmid { get; }

    [QueryParam("something", formatter: typeof(DefaultValueFormatter))]
    public bool IsSomething { get; }

    public TestRequest(int id, int vmid, bool isSomething = false)
    {
        Id = id;
        Vmid = vmid;
        IsSomething = isSomething;
    }
}