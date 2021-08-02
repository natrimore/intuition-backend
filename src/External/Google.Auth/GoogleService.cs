using Google.Apis.Auth;
using Intuition.External.Google.Auth.Models;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Google.Auth
{
    public class GoogleService : IGoogleService
    {
        private readonly GoogleAuthOptions _googleOptions;
        public GoogleService(IOptions<GoogleAuthOptions> googleOptions)
        {
            _googleOptions = googleOptions.Value ??
                throw new ArgumentNullException(nameof(googleOptions));
        }
        public async Task<GoogleJsonWebSignature.Payload> VerifyGoogleToken(ExternalAuthDTO externalAuth)
        {
            try
            {
                var settings = new GoogleJsonWebSignature.ValidationSettings()
                {
                    Audience = new List<string>() { _googleOptions.ClientId }
                };
                var payload = await GoogleJsonWebSignature.ValidateAsync(externalAuth.IdToken, settings);
                return payload;
            }
            catch (Exception ex)
            {
                //log an exception
                return null;
            }
        }
    }
}
