using System.ComponentModel.DataAnnotations;

namespace Demo_Mock_House_Finder.Model.DTO
{
    public class AddressCreateDTO
    {
        [Required]
        public string AddressName { get; set; }
        public string GoogleMapLocation { get; set; }
        public int? HouseID { get; set; }
        //[ForeignKey("HosueID")]
        public House? House { get; set; }
        public ICollection<User>? Users { get; set; }
        public ICollection<Campus>? Campuses { get; set; }
    }
}
