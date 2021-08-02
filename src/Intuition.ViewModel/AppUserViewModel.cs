using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intuition.ViewModels
{
    public class AppUserViewModel
    {
        //
        // Summary:
        //     Gets or sets the date and time, in UTC, when any user lockout ends.
        //
        // Remarks:
        //     A value in the past means the user is not locked out.
        public DateTimeOffset? LockoutEnd { get; set; }

        /// <summary>
        ///  Gets or sets a flag indicating if two factor authentication is enabled for this 
        ///  user.
        /// </summary>
        public bool TwoFactorEnabled { get; set; }

        /// <summary>
        ///  Gets or sets a flag indicating if a user has confirmed their telephone address.
        /// </summary>
        public bool PhoneNumberConfirmed { get; set; }

        /// <summary>
        ///  Gets or sets a telephone number for the user.
        /// </summary>
        public string PhoneNumber { get; set; }

        ///// <summary>
        /////  A random value that must change whenever a user is persisted to the store
        ///// </summary>
        //public string ConcurrencyStamp { get; set; }

        ///  A random value that must change whenever a users credentials change (password
        ///  changed, login removed)
        /// </summary>
        // public string SecurityStamp { get; set; }


        ///// <summary>
        /////  Gets or sets a salted and hashed representation of the password for this user.
        ///// </summary>
        //public virtual string PasswordHash { get; set; }

        /// <summary>
        ///  Gets or sets a flag indicating if a user has confirmed their email address.
        /// </summary>
        // public virtual bool EmailConfirmed { get; set; }

        ///// <summary>
        /////  Gets or sets the normalized email address for this user.
        ///// </summary>
        //public virtual string NormalizedEmail { get; set; }

        ///// <summary>
        /////  Gets or sets the email address for this user.
        ///// </summary>
        //public virtual string Email { get; set; }

        ///// <summary>
        /////  Gets or sets the normalized user name for this user.
        ///// </summary>
        //public virtual string NormalizedUserName { get; set; }


        /// <summary>
        /// Gets or sets the user name for this user.
        /// </summary>
        public virtual string UserName { get; set; }

        /// <summary>
        ///  Gets or sets the primary key for this user.
        /// </summary>
        public virtual Guid Id { get; set; }

        /// <summary>
        ///  Gets or sets a flag indicating if the user could be locked out.
        /// </summary>
        public virtual bool LockoutEnabled { get; set; }

        /// <summary>
        ///  Gets or sets the number of failed login attempts for the current user.
        /// </summary>
        public virtual int AccessFailedCount { get; set; }

        /// <summary>
        ///  Gets or sets unique id of the status associated with this user.
        /// </summary>
        public short StatusId { get; set; }

        /// <summary>
        ///  Gets or sets an instance of UserStatus class.
        /// </summary>
        public UserStatusViewModel UserStatus { get; set; }

        /// <summary>
        ///  Gets or sets date and when this user logged in to the system.
        /// </summary>
        public DateTime LastSignedInOn { get; set; } = DateTime.MinValue;

        /// <summary>
        ///  Gets or sets a telephone number for the user.
        /// </summary>
        // [ProtectedPersonalData]
        [MaxLength(50)]
        public virtual string ReservedPhoneNumber { get; set; }

        public UserProfileViewModel UserProfile { get; set; }

        public UserSettingViewModel UserSetting { get; set; }
    }
}
