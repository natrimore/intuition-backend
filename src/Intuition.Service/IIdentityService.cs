using Google.Apis.Auth;
using Intuition.External.Google.Auth.Models;
using System.Threading.Tasks;
using static Google.Apis.Auth.GoogleJsonWebSignature;

namespace Intuition.Services
{
    public interface IIdentityService
    {
        Task<GoogleJsonWebSignature.Payload> VerifyExternalToken(ExternalAuthDTO externalAuth);

        Task<bool> UserExistAsync(Payload payload, ExternalAuthDTO externalAuth);

        Task
    }
}
