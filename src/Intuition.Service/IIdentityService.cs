using Intuition.ViewModels;
using System;
using System.Threading.Tasks;

namespace Intuition.Services
{
    public interface IIdentityService
    {
        Task<AppUserViewModel> CreateUserAsync(CredentialsViewModel model);

        Task<AppUserViewModel> FindByIdAsync(Guid userId);

        Task<bool> UserExistsAsync(string userName);

        Task<AppUserViewModel> FindByNameAsync(string userName);
    }
}
