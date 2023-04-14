namespace PveSharp.Attributes;

[AttributeUsage(AttributeTargets.Class)]
public class PostRequestAttribute : EndpointAttribute
{
    public PostRequestAttribute(string path, bool authRequired = false) 
        : base(path, HttpMethod.Post, authRequired)
    {
    }
}