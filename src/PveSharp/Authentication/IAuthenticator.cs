using PveSharp.Http;

namespace PveSharp;

public interface IAuthenticator
{
    void Apply(IRequest request);
}