using System.ComponentModel.DataAnnotations;

namespace EFCORE.Models
{
    public class Province
    {
        [Key]
        public int ProvinceID { get; set; }
        public string? ProvinceName { get; set; }
        public string? Code { get; set; }
        public IList<District>? Districts { get; set; }
    }
}
