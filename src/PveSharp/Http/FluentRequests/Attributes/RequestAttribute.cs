namespace PveSharp.Attributes;

[AttributeUsage(AttributeTargets.Class)]
public class RequestAttribute : Attribute
{
    public Type? ValueFormatter { get; }

    public RequestAttribute(Type? formatter = null)
    {
        ValueFormatter = formatter;
    }
}