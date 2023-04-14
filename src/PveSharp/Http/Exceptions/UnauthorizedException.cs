namespace PveSharp.Http.Exceptions;

public class UnauthorizedException : Exception
{
    public IRequest Request { get; }
    
    public string Message { get; }
    
    public UnauthorizedException(IRequest request, string message) : base(message: message)
    {
        Request = request;
        Message = message;
    }
}