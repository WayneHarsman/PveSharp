namespace PveSharp.Attributes;

[AttributeUsage(AttributeTargets.Property)]
public class InlineParamAttribute : RequestAttribute
{
    public string Name { get; }

    public InlineParamAttribute(string name, Type? formatter = null) : base(formatter)
    {
        Name = name;
    }
}