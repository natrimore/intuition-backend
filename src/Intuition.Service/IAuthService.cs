using Google.Apis.Auth;
using Intuition.Domains;
using Intuition.External.Google.Auth.Models;
using Intuition.ViewModels;
using System.Threading.Tasks;
using static Google.Apis.Auth.GoogleJsonWebSignature;

namespace Intuition.Services
{
    public interface IAuthService
    {
        Task<GoogleJsonWebSignature.Payload> VerifyExternalToken(ExternalAuthDTO externalAuth);

        Task<bool> UserExistAsync(Payload payload, ExternalAuthDTO externalAuth);

        Task<TokenViewModel> GenerateTokenAsync(CredentialsViewModel model);
    }
}
