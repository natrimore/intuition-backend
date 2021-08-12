using Intuition.Services;
using Intuition.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Intuition.API.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UsersController : ControllerBase
    {
        private readonly IIdentityService _identityService;
        private readonly ILogger<UsersController> _logger;

        public UsersController(
            IIdentityService identityService,
            ILogger<UsersController> logger
            )
        {
            _identityService = identityService;
            _logger = logger;
        }

        [HttpGet("me", Name = nameof(GetMeAsync))]
        public async Task<ActionResult> GetMeAsync()
        {
            var claims = User.Claims;
            try
            {
                var userId = Guid.Parse(claims.SingleOrDefault(w => w.Type == "Id").Value);

                var user = await _identityService.FindByIdAsync(userId);

                if (user == null)
                {
                    return NotFound("User not found");
                }

                return Ok(user);
            }
            catch (Exception exc)
            {
                return BadRequest("Something went wrong");
                //_logger.LogError(exc, $"An error occured while retreiving user with username: {user.Id}. See exception details: {exc.Message}.");
            }
        }

        [HttpPost]
        public async Task<ActionResult<AppUserViewModel>> PostAsync([FromBody] CredentialsViewModel model)
        {
            try
            {
                if (await _identityService.UserExistsAsync(model.UserName))
                {
                    return BadRequest("Something went wrong");
                }

                var user = await _identityService.CreateUserAsync(model);

                if (user != null)
                {
                    return CreatedAtRoute(nameof(GetMeAsync), new { }, user);
                }
            }
            catch (Exception ex)
            {
            }
            
            return BadRequest("Something went wrong");
        }

    }
}
