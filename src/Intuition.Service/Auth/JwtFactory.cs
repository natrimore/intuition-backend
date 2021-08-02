using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Intuition.Services.Auth
{
    public class JwtFactory : IJwtFactory
    {
        public ClaimsIdentity GenerateClaimsIdentity(string userName, IEnumerable<Claim> claims)
        {
            throw new NotImplementedException();
        }

        public Task<string> GenerateEncodedToken(string userName, ClaimsIdentity identity)
        {
            throw new NotImplementedException();
        }
    }
}
