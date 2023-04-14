using PveSharp.Http;
using PveSharp.Models;

namespace PveSharp;

public class TokenAuthenticator : IAuthenticator
{
    public ApiToken ApiToken { get; }

    public TokenAuthenticator(string user, string realm, string tokenId, string uuid)
    {
        ApiToken = new ApiToken(user, realm, tokenId, uuid);
    }

    public void Apply(IRequest request)
    {
        request.Headers["Authorization"] = ApiToken.ToHeader();
    }
}