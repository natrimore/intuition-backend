using Intuition.Domains.Base;
using Microsoft.AspNetCore.Identity;
using System;

namespace Intuition.Domains
{
    public class AppRole : IdentityRole<Guid>, IEntity<Guid>
    {
    }
}
