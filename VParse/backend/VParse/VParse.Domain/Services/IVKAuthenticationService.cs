using VParse.Domain.ValueObjects;

namespace VParse.Domain.Services;
 
public interface IVKAuthenticationService
{
    Task<VKCredentials> AuthenticateAsync(string code);
}
