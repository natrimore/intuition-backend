using Intuition.Domains.References;
using System;

namespace Intuition.Domains
{
    public class UserSetting
    {
        /// <summary>
        ///  Gets or sets unique identifier.
        /// </summary>
        public Guid UserId { get; set; }

        /// <summary>
        ///  Gets or sets an instance of <see cref="Domain.AppUser"/> class.
        /// </summary>
        public AppUser AppUser { get; set; }

        /// <summary>
        ///  Gets or sets unique idenifier of related <see cref="Shared.Domain.Language"/> class.
        /// </summary>
        public string LanguageId { get; set; }

        /// <summary>
        ///  Gets or sets an instance of related <see cref="Shared.Domain.Language"/> class.
        /// </summary>
        public Language Language { get; set; }

        /// <summary>
        ///  Gets or sets unique idenifier of related <see cref="Domain.AppTimeZone"/> class.
        /// </summary>
        public string AppTimeZoneId { get; set; }

        /// <summary>
        ///  Gets or sets an instance of related <see cref="Domain.AppTimeZone"/> class.
        /// </summary>
        public AppTimeZone AppTimeZone { get; set; }

        /// <summary>
        ///  Gets or sets a boolean value that indicates whether two factor authentication enabled or not.
        /// </summary>
        public bool TwoFactorAuthenticationEnabled { get; set; }

        /// <summary>
        ///  Gets or sets a boolean value that indicates whether push notification enabled or not.
        /// </summary>
       // public bool PushNotificationEnabled { get; set; }
    }
}
