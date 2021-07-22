using Intuition.Domains.Base;
using Microsoft.AspNetCore.Identity;
using System;

namespace Intuition.Domains
{
    public class AppUser : IdentityUser<Guid>, IEntity<Guid>
    {
    }
}
