using Intuition.Domains.Base;
using Microsoft.AspNetCore.Identity;
using System;

namespace Intuition.Domains
{
    public class AppUser : IdentityUser<Guid>, IEntity<Guid>
    {
        /// <summary>
        ///  Gets or sets status id of this user.
        /// </summary>
        public short StatusId { get; set; }

        /// <summary>
        ///  Gets or sets an instance of UserStatus class.
        /// </summary>
        public UserStatus UserStatus { get; set; }

        /// <summary>
        ///  Gets or sets a date and time when this user is created.
        /// </summary>
        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;

        /// <summary>
        ///  Gets or sets date and when this user logged in to the system.
        /// </summary>
        public DateTime LastSignedInOn { get; set; } = DateTime.MinValue;

        /// <summary>
        ///  Gets or sets a telephone number for the user.
        /// </summary>
        [ProtectedPersonalData]
        public virtual string ReservedPhoneNumber { get; set; }

        // public Guid UserProfileId { get; set; }

        public UserProfile UserProfile { get; set; }

        // public Guid UserSettingId { get; set; }
        public UserSetting UserSetting { get; set; }
    }
}
