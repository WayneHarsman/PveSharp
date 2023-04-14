namespace PveSharp.Models;

public class ApiToken
{
    public string User { get; set; }
    
    public string Realm { get; set; }
    
    public string TokenId { get; set; }
    
    public string UUID { get; set; }

    public ApiToken(string user, string realm, string tokenId, string uuid)
    {
        User = user;
        Realm = realm;
        TokenId = tokenId;
        UUID = uuid;
    }
    
    public string ToHeader()
    {
        return $"PVEAPIToken={User}@{Realm}!{TokenId}={UUID}";
    }
}