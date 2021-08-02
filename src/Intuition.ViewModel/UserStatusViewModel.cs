using System.ComponentModel.DataAnnotations;

namespace Intuition.ViewModels
{
    public class UserStatusViewModel
    {
        /// <summary>
        ///  Gets or sets id of this user status.
        /// </summary>
        public short Id { get; set; }

        /// <summary>
        ///  Gets or sets name of this status.
        /// </summary>
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }

        [Required]
        [MaxLength(50)]
        /// <summary>
        ///  Gets or sets native name of this status.
        /// </summary>
        public string DisplayName { get; set; }

        /// <summary>
        ///  Gets or sets short description of the status.
        /// </summary>
        [Required]
        [MaxLength(150)]
        public string Description { get; set; }
    }
}
