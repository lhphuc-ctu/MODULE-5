using System.ComponentModel.DataAnnotations;

namespace EFCORE.Models
{
    public class ProvinceDTO
    {
        [Required]
        [MaxLength(100)]
        public string? ProvinceName { get; set; }
        [Required]
        [MaxLength(5)]
        public string? Code { get; set; }
    }
}
