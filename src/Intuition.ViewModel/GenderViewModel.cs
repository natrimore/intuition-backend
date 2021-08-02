using System.ComponentModel.DataAnnotations;

namespace Intuition.ViewModels
{
    public class GenderViewModel
    {
        public short Id { get; set; }

        [MaxLength(15)]
        [Required]
        public string Name { get; set; }

        [MaxLength(30)]
        [Required]
        public string DisplayName { get; set; }
    }
}
