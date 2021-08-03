﻿using Google.Apis.Auth;
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
    }
}