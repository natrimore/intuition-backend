using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Intuition.Services.Auth
{
    public class JwtFactory : IJwtFactory
    {
        private readonly JwtIssuerOptions _jwtOptions;

        public JwtFactory(IOptions<JwtIssuerOptions> jwtOptions)
        {
            _jwtOptions = jwtOptions.Value;
            ThrowIfInvalidOptions(_jwtOptions);
        }
        public ClaimsIdentity GenerateClaimsIdentity(string userName, IEnumerable<Claim> claims)
        {
            return new ClaimsIdentity(claims);
        }

        public Task<string> GenerateEncodedToken(string userName, ClaimsIdentity identity)
        {
            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = identity,
                Expires = _jwtOptions.Expiration,
                Audience = _jwtOptions.Audience,
                SigningCredentials = _jwtOptions.SigningCredentials,
                Issuer = _jwtOptions.Issuer,
                IssuedAt = _jwtOptions.IssuedAt,
                NotBefore = _jwtOptions.NotBefore
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            // var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            return Task.FromResult(tokenHandler.WriteToken(token));
        }

        private static void ThrowIfInvalidOptions(JwtIssuerOptions options)
        {
            if (options == null) throw new ArgumentNullException(nameof(options));

            if (options.ValidFor <= TimeSpan.Zero)
            {
                throw new ArgumentException("Must be a non-zero TimeSpan.", nameof(JwtIssuerOptions.ValidFor));
            }

            if (options.SigningCredentials == null)
            {
                throw new ArgumentNullException(nameof(JwtIssuerOptions.SigningCredentials));
            }

            if (options.JtiGenerator == null)
            {
                throw new ArgumentNullException(nameof(JwtIssuerOptions.JtiGenerator));
            }
        }
    }
}
