namespace PveSharp.Attributes;

[AttributeUsage(AttributeTargets.Class)]
public class GetRequestAttribute : EndpointAttribute
{
    public GetRequestAttribute(string path, bool authRequired = false) 
        : base(path, HttpMethod.Get, authRequired)
    {
    }
}