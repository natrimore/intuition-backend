using Intuition.External.Google.Auth.Models;
using Intuition.Services;
using Intuition.ViewModels;
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

        [HttpPost("external-login")]
        public async Task<IActionResult> ExternalLoginAsync([FromBody] ExternalAuthDTO externalAuth)
        {
            var payload = await _service.VerifyExternalToken(externalAuth);

            if (payload == null)
            {
                return BadRequest("Invalid external authentication");
            }

            return Ok();
            //if ()
        }

        [HttpPost("token")]
        public async Task<IActionResult> GenerateTokenAsync([FromBody] CredentialsViewModel credentials)
        {
            return Ok(_service.GenerateTokenAsync(new Domains.AppUser { UserName = credentials.UserName }));
        }
    }
}
