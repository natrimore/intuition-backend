using AutoMapper;
using Intuition.Domains;
using Intuition.Domains.References;
using Intuition.Infrastructures;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Intuition.API.Helpers
{
    public class IdentityAppInitializer
    {
        private readonly RoleManager<AppRole> _roleManager;
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;
        private readonly IdentityContext _context;
        private readonly ReferenceContext _referenceContext;

        public IdentityAppInitializer(RoleManager<AppRole> roleMgr,
            IMapper mapper,
            IdentityContext context,
            ReferenceContext referenceContext,
            UserManager<AppUser> userManager)
        {
            _roleManager = roleMgr ??
                throw new ArgumentNullException(nameof(roleMgr));

            _mapper = mapper ??
                throw new ArgumentNullException(nameof(mapper));

            _context = context ??
                throw new ArgumentNullException(nameof(context));

            _referenceContext = referenceContext ??
                throw new ArgumentNullException(nameof(referenceContext));

            _userManager = userManager ??
                throw new ArgumentNullException(nameof(userManager));
        }

        public async Task SeedAsync()
        {
            IdentityResult identityResult;

            // adding admin role to db
            if (!(await _roleManager.RoleExistsAsync("Admin")))
            {
                var adminRole = new AppRole
                {
                    Name = "Admin"
                };

                identityResult = await _roleManager.CreateAsync(adminRole);

                if (!identityResult.Succeeded)
                {
                    throw new InvalidOperationException("Cannot create admin role");
                }
                await _roleManager.AddClaimAsync(adminRole, new Claim("IsAdmin", "True"));
            }

            // adding customer role to db
            if (!(await _roleManager.RoleExistsAsync("Customer")))
            {
                var customerRole = new AppRole
                {
                    Name = "Customer"
                };

                identityResult = await _roleManager.CreateAsync(customerRole);

                if (!identityResult.Succeeded)
                {
                    throw new InvalidOperationException("Cannot create customer role");
                }
                await _roleManager.AddClaimAsync(customerRole, new Claim("IsCustomer", "True"));
            }

            // ading basic admin role to db
            if (!(await _roleManager.RoleExistsAsync("BasicAdmin")))
            {
                var basicAdminRole = new AppRole
                {
                    Name = "BasicAdmin"
                };

                identityResult = await _roleManager.CreateAsync(basicAdminRole);

                if (!identityResult.Succeeded)
                {
                    throw new InvalidOperationException("Cannot create basic admin role");
                }
            }

            await SeedLanguagesAsync();

            await SeedGendersAsync();

            await SeedAppTimeZonesAsync();

            await SeedUserStatusesAsync();
        }

        private async Task SeedLanguagesAsync()
        {
            var fileName = Path.Combine(Directory.GetCurrentDirectory(), "References", "languages.csv");

            var languages = (await File.ReadAllLinesAsync(fileName));

            var entities = languages.Select(w =>
            {
                var splitted = w.Split("|", StringSplitOptions.RemoveEmptyEntries);

                if (splitted.Length == 3)
                {
                    return new Language
                    {
                        Id = splitted[0].Trim(),
                        Name = splitted[1].Trim(),
                        DisplayName = splitted[2].Trim()
                    };
                }
                return null;
            }).Where(w => w != null);


            if (!(await _referenceContext.Languages.AnyAsync()))
            {
                _referenceContext.Languages.AddRange(entities);

                if (!(await _referenceContext.SaveChangesAsync() > 0))
                {
                    throw new InvalidOperationException($"Cannot create avaliable languages.");
                }
            }
        }

        private async Task SeedAppTimeZonesAsync()
        {
            var fileName = Path.Combine(Directory.GetCurrentDirectory(), "References", "time_zones.csv");

            var timeZones = (await File.ReadAllLinesAsync(fileName));

            var entities = timeZones.Select(w =>
            {
                var splitted = w.Split("|", StringSplitOptions.RemoveEmptyEntries);

                if (splitted.Length == 4)
                {
                    var offset = splitted[3].Split(":");

                    return new AppTimeZone
                    {
                        Id = splitted[0],
                        DisplayName = splitted[1].Trim(),
                        StandartName = splitted[2].Trim(),
                        BaseUtcOffsetHours = int.Parse(offset[0]),
                        BaseUtcOffsetMinutes = int.Parse(offset[1]),
                        BaseUtcOffsetSeconds = int.Parse(offset[2]),
                    };
                }
                return null;
            }).Where(w => w != null);

            if (!(await _referenceContext.AppTimeZones.AnyAsync()))
            {
                _referenceContext.AppTimeZones.AddRange(entities);

                if (!((await _referenceContext.SaveChangesAsync() > 0)))
                {
                    throw new InvalidOperationException($"Cannot create app time zones.");
                }
            }
        }

        private async Task SeedGendersAsync()
        {
            var fileName = Path.Combine(Directory.GetCurrentDirectory(), "References", "genders.csv");

            var genders = (await File.ReadAllLinesAsync(fileName));

            var entities = genders.Select(w =>
            {
                var splitted = w.Split("|", StringSplitOptions.RemoveEmptyEntries);

                if (splitted.Length == 3)
                {
                    return new Gender
                    {
                        Id = short.Parse(splitted[0]),
                        Name = splitted[1].Trim(),
                        DisplayName = splitted[2].Trim(),
                    };
                }
                return null;
            }).Where(w => w != null);

            if (!(await _referenceContext.Genders.AnyAsync()))
            {
                _referenceContext.Genders.AddRange(entities);

                if (!((await _referenceContext.SaveChangesAsync() > 0)))
                {
                    throw new InvalidOperationException($"Cannot create genders.");
                }
            }


        }

        private async Task SeedUserStatusesAsync()
        {
            // User statuses

            var fileName = Path.Combine(Directory.GetCurrentDirectory(), "References", "user_statuses.csv");

            var userStatuses = (await File.ReadAllLinesAsync(fileName));

            var entities = userStatuses.Select(w =>
            {
                var splitted = w.Split("|", StringSplitOptions.RemoveEmptyEntries);

                if (splitted.Length == 4)
                {
                    return new UserStatus
                    {
                        Id = short.Parse(splitted[0]),
                        Name = splitted[1].Trim(),
                        DisplayName = splitted[2].Trim(),
                        Description = splitted[3].Trim()
                    };
                }
                return null;
            }).Where(w => w != null);

            if (!(await _context.UserStatuses.AnyAsync()))
            {
                _context.UserStatuses.AddRange(entities);

                if (!((await _context.SaveChangesAsync() > 0)))
                {
                    throw new InvalidOperationException($"Cannot create user statuses.");
                }
            }

            //fileName = Path.Combine(Directory.GetCurrentDirectory(), "References", "localized_user_statuses.csv");

            //var localizedUserStatuses = (await File.ReadAllLinesAsync(fileName));

            //var statuses = localizedUserStatuses.Select(w =>
            //{
            //    var splitted = w.Split("|", StringSplitOptions.RemoveEmptyEntries);

            //    if (splitted.Length == 5)
            //    {
            //        return new LocalizedUserStatus
            //        {
            //            Id = short.Parse(splitted[0]),
            //            LanguageId = splitted[1].Trim(),
            //            Name = splitted[2].Trim(),
            //            DisplayName = splitted[3].Trim(),
            //            Description = splitted[4].Trim()
            //        };
            //    }
            //    return null;
            //}).Where(w => w != null);

            //if (!(await _context.LocalizedUserStatuses.AnyAsync()))
            //{
            //    _context.LocalizedUserStatuses.AddRange(statuses);

            //    if (!((await _context.SaveChangesAsync() > 0)))
            //    {
            //        throw new InvalidOperationException($"Cannot create localized user statuses.");
            //    }
            //}

            var sysUser = await _userManager.FindByNameAsync("dotnet.developer@mail.ru");

            if (sysUser == null)
            {
                //var activeStatus = await _context.UserStatuses.SingleOrDefaultAsync(w => w.Name == "Active");

                sysUser = new AppUser
                {
                    PhoneNumberConfirmed = true,
                    PhoneNumber = "998000000000",
                    ReservedPhoneNumber = "998974489889",
                    Email = "dotnet.developer@mail.ru",
                    EmailConfirmed = true,
                    UserName = "dotnet.developer@mail.ru",
                    StatusId = 1
                };

                var userResult = await _userManager.CreateAsync(sysUser, "F810F6A1-D75B-40BE-8ECF-8ED98936421D");

                var roleResult = await _userManager.AddToRoleAsync(sysUser, "Admin");

                var claims = new[]
                       {
                            //new Claim("EmailConfirmed", "True"),
                            new Claim("PhoneNumberConfirmed", "True")
                       };

                var claimsResult = await _userManager.AddClaimsAsync(sysUser, claims);

                if (!userResult.Succeeded || !roleResult.Succeeded || !claimsResult.Succeeded)
                {
                    throw new InvalidOperationException("An error occured while creating system user.");
                }

                var profile = new UserProfile
                {
                    UserId = sysUser.Id,
                    FirstName = "Ravshan",
                    LastName = "Ergashov",
                    GenderId = 1,
                    BirthDate = new DateTime(1987, 3, 10)
                };

                _context.UserProfiles.Add(profile);

                var succeded = (await _context.SaveChangesAsync()) > 0;

                if (!succeded)
                {
                    throw new InvalidOperationException("An error occured while creating profile the system user.");
                }

                var userSetting = new UserSetting
                {
                    UserId = sysUser.Id,
                    LanguageId = "ru",
                    AppTimeZoneId = "UTC"
                };

                _context.UserSettings.Add(userSetting);

                succeded = (await _context.SaveChangesAsync()) > 0;

                if (!succeded)
                {
                    throw new InvalidOperationException("An error occured while creating settings the system user.");
                }
            }
        }

        //private async Task SeedErrorsAsync()
        //{
        //    // TO DO here
        //    var fileName = Path.Combine(Directory.GetCurrentDirectory(), "References", "errors.csv");

        //    var errors = (await File.ReadAllLinesAsync(fileName));

        //    var entities = errors.Select(w =>
        //    {
        //        var splitted = w.Split("|", StringSplitOptions.RemoveEmptyEntries);

        //        if (splitted.Length == 4)
        //        {
        //            return new Error
        //            {
        //                Code = Convert.ToInt16(splitted[0].Trim()),
        //                LanguageId = splitted[1].Trim(),
        //                HttpStatusCode = Convert.ToInt16(splitted[2].Trim()),
        //                Message = splitted[3].Trim()
        //            };
        //        }
        //        return null;
        //    }).Where(w => w != null);

        //    if (!(await _context.Errors.AnyAsync()))
        //    {
        //        _context.Errors.AddRange(entities);

        //        if (!((await _context.SaveChangesAsync() > 0)))
        //        {
        //            throw new InvalidOperationException($"Identity: Cannot seed error messages.");
        //        }
        //    }

        //}
    }
}
