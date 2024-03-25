using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Demo_Mock_House_Finder.Model
{
    [Table("Village")]
    public class Village
    {
        [Key]
        public int VillageID { get; set; }
        public string? VillageName { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? CommuneID { get; set; }
        [ForeignKey("CommuneID")]
        public Commune? Commune { get; set; }

        public ICollection<House>? Houses { get; set; }
    }
}
