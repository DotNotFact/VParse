namespace VParse.Domain.ValueObjects;
 
public class VKCredentials(string accessToken, DateTime expiresAt)
{
    public string AccessToken { get; private set; } = accessToken;
    public DateTime ExpiresAt { get; private set; } = expiresAt;

    public bool IsValid()
    {
        return DateTime.UtcNow < ExpiresAt;
    }
}
