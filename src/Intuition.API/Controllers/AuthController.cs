using Intuition.External.Google.Auth.Models;
using Intuition.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Intuition.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _service;
        public AuthController(IAuthService service)
        {
            _service = service ??
                throw new ArgumentNullException(nameof(service));
        }

        [HttpPost]
        public async Task<IActionResult> ExternalLogin([FromBody] ExternalAuthDTO externalAuth)
        {
            var payload = await _service.VerifyExternalToken(externalAuth);

            if (payload == null)
            {
                return BadRequest("Invalid external authentication");
            }

            if ()
        }
    }
}
