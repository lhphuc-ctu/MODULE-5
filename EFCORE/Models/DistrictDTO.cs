using System.ComponentModel.DataAnnotations;

namespace EFCORE.Models
{
    public class DistrictDTO
    {
        [Required]
        [MaxLength(100)]
        public string? DistrictName { get; set; }
    }
}
