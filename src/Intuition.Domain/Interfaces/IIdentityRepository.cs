using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Intuition.Domains.Interfaces
{
    public interface IIdentityRepository
    {
        Task<AppUser> FindUserByPhoneAsync(string phoneNumber);

        IDbContextTransaction GetCurrentTransaction();

        Task<UserProfile> FindUserProfileByIdAsync(Guid userId);

        Task<bool> CreateUserProfileAsync(UserProfile profile);

        Task<bool> CreateUserSettingAsync(UserSetting entity);

        Task<UserSetting> FindUserSettingByIdAsync(Guid userId);

        Task<bool> SaveChangesAsync();

        Task<AppUser> FindByIdAsync(Guid userId);

        Task<AppUser> FindByNameAsync(string userName);

        List<AppUser> Get(Expression<Func<AppUser, bool>> predicate, int? skip = null, int? take = null);

        Task<List<AppUser>> GetAsync(Expression<Func<AppUser, bool>> predicate, int? skip = null, int? take = null);
    }
}
