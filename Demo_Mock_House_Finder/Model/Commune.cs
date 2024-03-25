using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Demo_Mock_House_Finder.Model
{
    [Table("Commune")]
    public class Commune
    {
        [Key]
        public int CommuneID { get; set; }
        public string? CommuneName { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? DistrictID { get; set; }

        [ForeignKey("DistrictID")]
        public District? District { get; set; }

        public ICollection<Village>? Villages { get; set; }
    } 
}
