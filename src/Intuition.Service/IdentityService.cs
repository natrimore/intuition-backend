using Google.Apis.Auth;
using Google.Auth;
using Intuition.Domains;
using Intuition.External.Google.Auth.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace Intuition.Services
{
    public class IdentityService : IIdentityService
    {
        private readonly IGoogleService _googleService;
        private readonly UserManager<AppUser> _userManager;
        private readonly ILogger<IdentityService> _logger;
        public IdentityService(
            IGoogleService googleService,
            UserManager<AppUser> userManager,
            ILogger<IdentityService> logger
        )
        {
            _googleService = googleService ??
                throw new ArgumentNullException(nameof(googleService));

            _userManager = userManager ??
                throw new ArgumentNullException(nameof(userManager));

            _logger = logger ??
                throw new ArgumentNullException(nameof(logger));
        }
    }
}
