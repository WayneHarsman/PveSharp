namespace PveSharp.Utils;

public static class UriExtensions
{
    public static Uri ApplyParameters(this Uri uri, IDictionary<string, string> parameters)
    {
        if (!parameters.Any())
        {
            return uri;
        }

        var queryString = string.Join("&", parameters.Select((parameter) => $"{parameter.Key}={parameter.Value}"));
        var query = string.IsNullOrEmpty(queryString) ? null : queryString;

        var uriBuilder = new UriBuilder(uri)
        {
            Query = query
        };

        return uriBuilder.Uri;
    }
}