using AutoMapper;
using Google.Auth;
using Intuition.Domains;
using Intuition.Services.Repositories.Interfaces;
using Intuition.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Intuition.Services
{
    public class IdentityService : IIdentityService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly ILogger<IdentityService> _logger;
        private readonly IIdentityRepository _identityRepository;
        private readonly IMapper _mapper;
        public IdentityService(
            UserManager<AppUser> userManager,
            ILogger<IdentityService> logger,
            IIdentityRepository identityRepository,
            IMapper mapper
        )
        {
            _userManager = userManager ??
                throw new ArgumentNullException(nameof(userManager));

            _logger = logger ??
                throw new ArgumentNullException(nameof(logger));

            _identityRepository = identityRepository ??
                throw new ArgumentNullException(nameof(identityRepository));

            _mapper = mapper ??
                throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<AppUserViewModel> CreateUserAsync(CredentialsViewModel model)
        {
            //var status = _referenceContainer
            //     .UserStatuses
            //     .SingleOrDefault(w => w.Name.Equals("inactive", StringComparison.InvariantCultureIgnoreCase));

            var id = Guid.NewGuid();

            var entity = new AppUser
            {
                Id = id,
                UserName = model.UserName,
                PhoneNumber = model.UserName,
                PhoneNumberConfirmed = false,
                StatusId = 1,
            };

            var userResult = await _userManager.CreateAsync(entity, model.Password);

            var roleResult = await _userManager.AddToRoleAsync(entity, "Customer");

            var claims = new[]
            {
                new Claim("IsCustomer", "True"),
                new Claim("PhoneNumberConfirmed", "True")
            };

            var claimResult = await _userManager.AddClaimsAsync(entity, claims);

            if (!userResult.Succeeded || !roleResult.Succeeded || !claimResult.Succeeded)
            {
                throw new InvalidOperationException("Failed to build user and roles");
            }

            await CreateUserProfileAsync(entity);

            // publishing an event

            return _mapper.Map<AppUserViewModel>(entity);
        }

        public async Task<AppUserViewModel> FindByIdAsync(Guid userId)
        {
            var entity = await _identityRepository.FindByIdAsync(userId);

            var model = _mapper.Map<AppUserViewModel>(entity);

            return model;
        }

        public async Task<bool> UserExistsAsync(string userName)
        {
            var user = await FindByNameAsync(userName);

            return user != null;
        }

        public async Task<AppUserViewModel> FindByNameAsync(string userName)
        {
            var user = await _userManager.FindByNameAsync(userName);

            var model = _mapper.Map<AppUserViewModel>(user);

            return model;
        }

        private async Task CreateUserProfileAsync(AppUser entity)
        {
            var profileCreated = await _identityRepository.CreateUserProfileAsync(new UserProfile
            {
                UserId = entity.Id
            });

            if (!profileCreated)
            {
                throw new InvalidOperationException("Failed to build user profile.");
            }


            var userSettingCreated = await _identityRepository.CreateUserSettingAsync(new UserSetting
            {
                UserId = entity.Id,
                LanguageId = "ru",
                AppTimeZoneId = "UTC"
            });

            if (!userSettingCreated)
            {
                throw new InvalidOperationException("Failed to build user profile.");
            }
        }
    }
}
