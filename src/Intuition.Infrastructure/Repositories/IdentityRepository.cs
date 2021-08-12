using Intuition.Domains;
using Intuition.Services.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Intuition.Infrastructures.Repositories
{
    public class IdentityRepository : IIdentityRepository
    {
        private readonly IdentityContext _context;
        public IdentityRepository(IdentityContext context)
        {
            _context = context;
        }

        public Task<bool> CreateUserProfileAsync(UserProfile profile)
        {
            _context
                .UserProfiles
                .Add(profile);

            return SaveChangesAsync();
        }

        public Task<bool> CreateUserSettingAsync(UserSetting entity)
        {
            _context
                .UserSettings
                .Add(entity);

            return SaveChangesAsync();
        }

        public Task<AppUser> FindByIdAsync(Guid userId)
        {
            return _context
                .Users
                    .Include(w => w.UserProfile.Gender)
                    .Include(w => w.UserStatus)
                    .Include(w => w.UserSetting.AppTimeZone)
                    .Include(w => w.UserSetting.Language)
                    .SingleOrDefaultAsync(w => w.Id == userId);
        }

        public Task<AppUser> FindByNameAsync(string userName)
        {
            return _context
                .Users
                    .Include(w => w.UserProfile.Gender)
                    .Include(w => w.UserStatus)
                    .Include(w => w.UserSetting.AppTimeZone)
                    .Include(w => w.UserSetting.Language)
                .SingleOrDefaultAsync(w => w.UserName == userName);
        }

        public Task<AppUser> FindUserByPhoneAsync(string phoneNumber)
        {
            throw new NotImplementedException();
        }

        public Task<UserProfile> FindUserProfileByIdAsync(Guid userId)
        {
            return _context
                .UserProfiles
                .Include(w => w.Gender)
                .SingleOrDefaultAsync(w => w.UserId == userId);
        }

        public Task<UserSetting> FindUserSettingByIdAsync(Guid userId)
        {
            return _context.UserSettings.SingleOrDefaultAsync(w => w.UserId == userId);
        }

        public List<AppUser> Get(Expression<Func<AppUser, bool>> predicate, int? skip = null, int? take = null)
        {
            var query = _context.AppUsers
                        .Where(predicate);

            if (skip.HasValue)
            {
                query = query.Skip(skip.Value);
            }

            if (take.HasValue)
            {
                query = query.Take(take.Value);
            }

            var entities = query.ToList();

            return entities;
        }

        public Task<List<AppUser>> GetAsync(Expression<Func<AppUser, bool>> predicate, int? skip = null, int? take = null)
        {
            var query = _context.AppUsers
                    .Where(predicate);

            if (skip.HasValue)
            {
                query = query.Skip(skip.Value);
            }

            if (take.HasValue)
            {
                query = query.Take(take.Value);
            }

            return query.ToListAsync();
        }

        public IDbContextTransaction GetCurrentTransaction()
        {
            return _context.Database.CurrentTransaction;
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }
    }
}
