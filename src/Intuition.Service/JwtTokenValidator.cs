using Intuition.Services.Auth;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Intuition.ViewModels
{
    public class JwtTokenValidator : IJwtTokenValidator
    {
        private readonly JwtIssuerOptions _jwtOptions;
        private readonly TokenValidationParameters _validationParameters;
        private readonly ILogger<JwtTokenValidator> _logger;
        public JwtTokenValidator(
            IOptions<JwtIssuerOptions> jwtOptions,
            IOptions<TokenValidationParameters> validationParameters,
            ILogger<JwtTokenValidator> logger)
        {
            _jwtOptions = jwtOptions.Value ??
                throw new ArgumentNullException(nameof(jwtOptions));

            _validationParameters = validationParameters.Value ??
                throw new ArgumentNullException(nameof(validationParameters));

            _logger = logger ??
                throw new ArgumentNullException(nameof(logger));
        }
        public ClaimsPrincipal GetPrincipalFromToken(string token)
        {
            var tokenValidationParameters = _validationParameters;

            tokenValidationParameters.ValidateLifetime = false;

            tokenValidationParameters.IssuerSigningKey = _jwtOptions.SigningCredentials.Key as SymmetricSecurityKey;
            tokenValidationParameters.ValidIssuer = _jwtOptions.Issuer;
            tokenValidationParameters.ValidateAudience = false;

            var tokenHandler = new JwtSecurityTokenHandler();

            try
            {
                var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out var securityToken);

                if (
                    !(securityToken is JwtSecurityToken jwtSecurityToken) ||
                    !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase)
                   )
                {
                    throw new SecurityTokenException("Invalid token");
                }

                return principal;
            }
            catch (Exception e)
            {
                _logger.LogError($"Token validation Error {e.Message}");
            }

            return null;
        }
    }
}
