using Google.Apis.Auth;
using Google.Auth;
using Intuition.Domains;
using Intuition.External.Google.Auth.Models;
using Intuition.Services.Auth;
using Intuition.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace Intuition.Services
{
    public class AuthService : IAuthService
    {
        private readonly IGoogleService _googleService;
        private readonly UserManager<AppUser> _userManager;
        private readonly ILogger<IdentityService> _logger;
        private readonly IJwtFactory _jwtFactory;
        private readonly JwtIssuerOptions _jwtOptions;
        private readonly IJwtTokenValidator _jwtTokenValidator;
        public AuthService(
            IGoogleService googleService,
            UserManager<AppUser> userManager,
            ILogger<IdentityService> logger)
        {
            _googleService = googleService ??
                throw new ArgumentNullException(nameof(googleService));

            _userManager = userManager ??
                throw new ArgumentNullException(nameof(userManager));

            _logger = logger ??
                throw new ArgumentNullException(nameof(logger));
        }

        public async Task<bool> UserExistAsync(GoogleJsonWebSignature.Payload payload, ExternalAuthDTO externalAuth)
        {
            var info = new UserLoginInfo(externalAuth.Provider, payload.Subject, externalAuth.Provider);

            var user = await _userManager.FindByLoginAsync(info.LoginProvider, info.ProviderKey);
            if (user == null)
            {
                user = await _userManager.FindByEmailAsync(payload.Email);
                if (user != null)
                {
                    await _userManager.AddLoginAsync(user, info);
                }
            }

            return user != null ? true : false;
        }

        public Task<GoogleJsonWebSignature.Payload> VerifyExternalToken(ExternalAuthDTO externalAuth)
        {
            return _googleService.VerifyGoogleToken(externalAuth);
        }

        public async Task<TokenViewModel> GenerateTokenAsync(AppUser user)
        {
            try
            {
                //var identity = await GetClaimsIdentity(user, sessionId);

                //if (identity == null)
                //{
                //    _logger.LogError("Couldn't generate claims identity.");

                //    return new TokenGenerationResultViewModel
                //    {
                //        Result = TokenResponseType.ClaimsIdentityGenerationFail,
                //        Token = null
                //    };
                //}

                var jwt = new TokenViewModel
                {
                    //Login = identity.Claims.Single(c => c.Type == "UserName").Value,
                    AuthToken = await _jwtFactory.GenerateEncodedToken(user.UserName),
                    ExpiresIn = (int)_jwtOptions.ValidFor.TotalSeconds
                };

                //jwt.RefreshToken = GenerateRefreshToken();

                //var refreshToken = GetRefreshTokenDomainModel(jwt.RefreshToken, ipAddress, user.Id, sessionId);

                //user.LastSignedInOn = DateTime.UtcNow;

                //await _refreshTokenRepository.DeleteBySessionIdForUserAsync(user.Id, sessionId);

                //await _refreshTokenRepository.CreateAsync(refreshToken);

                //await _identityRepository.SaveChangesAsync();

                return jwt;
                //return new TokenGenerationResultViewModel
                //{
                //    //Result = TokenResponseType.OK,
                //    Token = jwt
                //};
            }
            catch (Exception exc)
            {
                _logger.LogError($"An error occured while creating token. See exception details: {exc.Message}.");
            }
            return null;
        }
    }
}
