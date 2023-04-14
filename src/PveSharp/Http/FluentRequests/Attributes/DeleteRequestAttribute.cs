namespace PveSharp.Attributes;

[AttributeUsage(AttributeTargets.Class)]
public class DeleteRequestAttribute : EndpointAttribute
{
    public DeleteRequestAttribute(string path, bool authRequired = false) 
        : base(path, HttpMethod.Delete, authRequired)
    {
    }
}