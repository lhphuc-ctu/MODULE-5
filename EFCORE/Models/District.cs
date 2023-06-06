using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCORE.Models
{
    public class District
    {
        [Key]
        public int DistrictID { get; set; }
        public string? DistrictName { get; set; }
        public int ProvinceID { get; set; }
        [ForeignKey(nameof(ProvinceID))]
        public Province? Province { get; set; }
    }
}
