using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Demo_Mock_House_Finder.Model
{
    [Table("RoomType")]
    public class RoomType
    {
        [Key]
        public int RoomTypeID { get; set; }
        public string? RoomTypeName { get; set;}
        public DateTime? CreatedDate {  get; set; }
        public ICollection<Room>? Rooms { get; set; }    

    }
}
