using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Demo_Mock_House_Finder.Model
{
    [Table("Status")]
    public class Status
    {
        [Key]
        public int StatusID { get; set; }
        public string? StatusName { get; set; }
        public DateTime? CreateDate { get; set; }
        public ICollection<Room>? Rooms { get; set; }
    }
}
