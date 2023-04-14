namespace PveSharp.Attributes;

[AttributeUsage(AttributeTargets.Property)]
public class QueryParamAttribute : RequestAttribute
{
    public string Name { get; }
    
    public bool Optional { get; }

    public QueryParamAttribute(string name, bool optional = false, Type? formatter = null) : base(formatter)
    {
        Name = name;
        Optional = optional;
    }
}