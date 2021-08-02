using Google.Apis.Auth;
using Intuition.External.Google.Auth.Models;
using System.Threading.Tasks;

namespace Google.Auth
{
    public interface IGoogleService
    {
        Task<GoogleJsonWebSignature.Payload> VerifyGoogleToken(ExternalAuthDTO externalAuth);
    }
}
