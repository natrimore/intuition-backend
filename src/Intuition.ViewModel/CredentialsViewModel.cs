using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intuition.ViewModels
{
    public class CredentialsViewModel
    {
        /// <summary>
        ///  Gets or sets user name.
        /// </summary>
        [Required]
        [MaxLength(15)]
        public virtual string UserName { get; set; }

        [Required]
        /// <summary>
        ///  Gets or sets password.
        /// </summary>
        public string Password { get; set; }
    }
}
