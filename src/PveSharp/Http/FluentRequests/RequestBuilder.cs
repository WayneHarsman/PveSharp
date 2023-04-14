using System.Reflection;
using PveSharp.Attributes;
using PveSharp.Http;

namespace PveSharp;

public class RequestBuilder
{
    private Uri? _baseAddress;
    private Uri? _endpoint;
    private HttpMethod? _method;
    private Dictionary<string, string>? _headers;
    private Dictionary<string, string>? _parameters;
    private object? _body;
    
    
    public RequestBuilder()
    {
        
    }
    
    public RequestBuilder FromMetadata(object request)
    {
        _parameters = BuildParameters(request);
        _endpoint = BuildEndpoint(request);

        return this;
    }
    
    public RequestBuilder WithBaseAddress(Uri baseAddress)
    {
        _baseAddress = baseAddress;
        return this;
    }
    
    public RequestBuilder WithMethod(HttpMethod method)
    {
        _method = method;
        return this;
    }
    
    public RequestBuilder WithDefaults()
    {
        _baseAddress ??= new Uri("localhost");
        _endpoint ??= new Uri("/", UriKind.Relative);
        _method ??= HttpMethod.Get;
        _headers ??= new Dictionary<string, string>();
        _parameters ??= new Dictionary<string, string>();
        _body ??= null;
        
        return this;
    }

    public Request Build()
    {
        return new Request(_baseAddress, _endpoint,  _headers, _parameters, _method, _body);
    }

    private Dictionary<string, string> BuildParameters(object request)
    {
        var requestProperties = request.GetType().GetProperties();
        var queryProperties = requestProperties
            .Where(x => x.GetCustomAttributes(typeof(QueryParamAttribute), true).Any());
        
        var queryParameters = new Dictionary<string, string>();
        foreach (var queryProperty in queryProperties)
        {
            // It is possible that there are several query parameters. Only one of those will be processed
            // TODO: revisit this behavior
            var queryAttribute = queryProperty.GetCustomAttribute<QueryParamAttribute>();
            var queryValue = queryProperty.GetValue(request);
            
            // Skip unused optional parameters
            if (queryValue is null && queryAttribute.Optional)
                continue;

            if (queryValue is null)
                throw new ArgumentNullException(queryProperty.Name,
                    "Non optional query parameter cannot be null");
            
            var paramFormatter = BuildFormatter(queryAttribute?.ValueFormatter);
            queryParameters.Add(queryAttribute.Name, paramFormatter.ToString(queryValue));
        }

        return queryParameters;
    }

    private Uri BuildEndpoint(object request)
    {
        var endpointAttribute = request.GetType().GetCustomAttribute<EndpointAttribute>();
        if (endpointAttribute is null)
            throw new ArgumentNullException(nameof(EndpointAttribute), "Request template must have an endpoint attribute");
        
        // Retrieve all inline query parameters...
        var inlineProperties = request.GetType().GetProperties()
            .Where(x => x.GetCustomAttributes(typeof(InlineParamAttribute), true).Any());

        // ...and apply those on path.
        var endpoint = endpointAttribute.Path;
        _method = endpointAttribute.Method;
        foreach (var queryProperty in inlineProperties)
        {
            var queryAttribute = queryProperty.GetCustomAttribute<InlineParamAttribute>();
            var parameterValue = queryProperty.GetValue(request);
            
            if (parameterValue is null)
                throw new ArgumentNullException(queryProperty.Name,
                    "Inline query parameter cannot be null");

            var paramFormatter = BuildFormatter(queryAttribute?.ValueFormatter);
            endpoint = endpoint.Replace($"{{{queryAttribute?.Name}}}", paramFormatter.ToString(parameterValue));
        }


        return new Uri(endpoint, UriKind.Relative);
    }


    private static IValueFormatter BuildFormatter(Type? formatter)
    {
        if (formatter is null)
        {
            return new DefaultValueFormatter();
        }

        var instance = Activator.CreateInstance(formatter) as IValueFormatter;

        return instance ?? 
                         throw new ArgumentException("Failed to create instance of IValueFormatter", nameof(formatter));
    }
}