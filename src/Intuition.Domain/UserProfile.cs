using Intuition.Domains.Base;
using Intuition.Domains.References;
using Microsoft.AspNetCore.Identity;
using System;

namespace Intuition.Domains
{
    public class UserProfile : ProtectedReferenceEntityBase<Guid>
    {
        [ProtectedPersonalData]
        /// <summary>
        ///  Gets or sets this user's full name.
        /// </summary>
        public string FirstName { get; set; }

        [ProtectedPersonalData]
        /// <summary>
        ///  Gets or sets this user's full name.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        ///  Gets or sets user's birthdate.
        /// </summary>
        public DateTime? BirthDate { get; set; }

        public Gender Gender { get; set; }

        /// <summary>
        ///  Gets or sets user profile image url.
        /// </summary>
        public string LogoUrl { get; set; }

        public short? GenderId { get; set; }

        public Guid UserId { get; set; }

        public AppUser AppUser { get; set; }
    }
}
