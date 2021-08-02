using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intuition.ViewModels
{
    public class UserProfileViewModel
    {
        [MaxLength(50)]
        // [ProtectedPersonalData]
        //[AllowUpdate]
        /// <summary>
        ///  Gets or sets this user's full name.
        /// </summary>
        public string FirstName { get; set; }

        [MaxLength(50)]
        // [ProtectedPersonalData]
        //[AllowUpdate]
        /// <summary>
        ///  Gets or sets this user's full name.
        /// </summary>
        public string LastName { get; set; }

        //[AllowUpdate]
        /// <summary>
        ///  Gets or sets user's birthdate.
        /// </summary>
        public DateTime? BirthDate { get; set; }

        /// <summary>
        ///  Gets or sets user profile image url.
        /// </summary>
        [MaxLength(150)]
        //[AllowUpdate]
        public string LogoUrl { get; set; }

        //[AllowUpdate]
        public GenderViewModel Gender { get; set; }

        //[AllowUpdate]
        public short? GenderId { get; set; }

        public Guid UserId { get; set; }
    }
}
