using Intuition.Domains;
using Intuition.Services.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Intuition.Infrastructures.Repositories
{
    public class IdentityRepository : IIdentityRepository
    {
        public Task<bool> CreateUserProfileAsync(UserProfile profile)
        {
            throw new NotImplementedException();
        }

        public Task<bool> CreateUserSettingAsync(UserSetting entity)
        {
            throw new NotImplementedException();
        }

        public Task<AppUser> FindByIdAsync(Guid userId)
        {
            throw new NotImplementedException();
        }

        public Task<AppUser> FindByNameAsync(string userName)
        {
            throw new NotImplementedException();
        }

        public Task<AppUser> FindUserByPhoneAsync(string phoneNumber)
        {
            throw new NotImplementedException();
        }

        public Task<UserProfile> FindUserProfileByIdAsync(Guid userId)
        {
            throw new NotImplementedException();
        }

        public Task<UserSetting> FindUserSettingByIdAsync(Guid userId)
        {
            throw new NotImplementedException();
        }

        public List<AppUser> Get(Expression<Func<AppUser, bool>> predicate, int? skip = null, int? take = null)
        {
            throw new NotImplementedException();
        }

        public Task<List<AppUser>> GetAsync(Expression<Func<AppUser, bool>> predicate, int? skip = null, int? take = null)
        {
            throw new NotImplementedException();
        }

        public IDbContextTransaction GetCurrentTransaction()
        {
            throw new NotImplementedException();
        }

        public Task<bool> SaveChangesAsync()
        {
            throw new NotImplementedException();
        }
    }
}
