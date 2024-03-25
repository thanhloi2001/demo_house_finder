using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Demo_Mock_House_Finder.Model
{
    [Table("Campus")]
    public class Campus
    {
        [Key]
        public int CampusId { get; set; }
        public string? CampusName { get; set; }
        public int? AddressID { get; set; }
        [ForeignKey("AddressID")]
        public Address? Address { get; set; }

        public ICollection<House>? Houses { get; set; }
        public DateTime? CreatedDate { get; set; }    

    }
}
