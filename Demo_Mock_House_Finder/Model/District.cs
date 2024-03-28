using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Demo_Mock_House_Finder.Model
{
    [Table("District")]
    public class District
    {
        [Key]
        public int DistrictID { get; set; }
        public string? DistricName { get; set; }
        public DateTime? CreatedDate { get; set; }
        public ICollection<Commune>? Communes { get; set; }
    }
}
