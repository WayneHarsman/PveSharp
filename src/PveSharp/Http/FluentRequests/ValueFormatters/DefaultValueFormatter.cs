namespace PveSharp;

public class DefaultValueFormatter : IValueFormatter
{
    public string? ToString(object value)
    {
        return value switch
        {
            bool b => b ? "1" : "0",
            _ => value.ToString()
        };
    }
}