using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Demo_Mock_House_Finder.Model
{
    [Table("RoomHistory")]
    public class RoomHistory
    {
        [Key]
        public int RoomHistoryID { get; set; }
        public string? CustomerName {  get; set; }
        public int? RoomID { get; set; }
        [ForeignKey("RoomID")]
        public Room? Room { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? LastModifiedDate { get; set; }

        public int? CreatedBy { get; set; }
        [ForeignKey("CreatedBy")]
        public User? UserCreated { get; set; }

        public int? LastModifiedBy { get; set; }
        [ForeignKey("LastModifiedBy")]
        public User? UserLastModified { get; set; }

    }
}
