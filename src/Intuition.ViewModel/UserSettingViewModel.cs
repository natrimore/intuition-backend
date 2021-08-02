using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intuition.ViewModels
{
    public class UserSettingViewModel
    {
        public Guid UserId { get; set; }

        // [ForeignKey(nameof(UserSetting.UserId))]
        [Required]
        //[AllowUpdate]
        [MaxLength(3)]
        public string LanguageId { get; set; }

        public LanguageViewModel Language { get; set; }

        [Required]
        //[AllowUpdate]
        [MaxLength(50)]
        public string AppTimeZoneId { get; set; }

        public AppTimeZoneViewModel AppTimeZone { get; set; }

        [Required]
        //[AllowUpdate]
        public bool TwoFactorAuthenticationEnabled { get; set; }
    }
}
