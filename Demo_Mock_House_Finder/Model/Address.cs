using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Demo_Mock_House_Finder.Model
{
    [Table("Address")]
    public class Address
    {
        [Key] 
        public int AddressID {  get; set; }
        public string? AddressName { get; set; }
        public string? GoogleMapLocation {  get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? LastModifiedDate { get; set; }

        public int? HouseID { get; set; }
        //[ForeignKey("HosueID")]
        public House? House { get; set; }
        public ICollection<User>? Users { get; set; }
        public ICollection<Campus>? Campuses { get; set; }
    }
}
