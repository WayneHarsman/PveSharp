namespace PveSharp.Attributes;

[AttributeUsage(AttributeTargets.Class)]
public class EndpointAttribute : Attribute
{
    public string Path { get; }
    
    public HttpMethod Method { get; }
    
    public bool AuthRequired { get; }

    public EndpointAttribute(string path, HttpMethod method, bool authRequired = false)

    {
        Path = path;
        Method = method;
        AuthRequired = authRequired;
    }
}