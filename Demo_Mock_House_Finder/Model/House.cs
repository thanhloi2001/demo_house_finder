using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Demo_Mock_House_Finder.Model
{
    [Table("House")]
    public class House
    {
        [Key]
        public int HouseID { get; set; }
        public string? HouseName { get; set; } 
        public string? Information {  get; set; }    
        public double? PowerPrice { get; set; }
        public double? WarerPrice { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? LastModifiedDate { get; set; }

        public int? AddressID { get; set; }
        [ForeignKey("AddressID")]
        public Address? Address { get; set; }

        public int? VillageID { get; set; }
        [ForeignKey("VillageID")]
        public Village? Village { get; set; }

        
        public int? LandlordID { get; set; }
        [ForeignKey("LandlordID")]
        public User Landlord { get; set; }

        public int? CampusID { get; set; }
        [ForeignKey("CampusID")]
        public Campus Campus { get; set; }

        public int? CreatedBy { get; set; }
        [ForeignKey("CreatedBy")]
        public User UserCreated { get; set; }

        public int? LastModifiedBy { get; set; }
        [ForeignKey("LastModifiedBy")]
        public User UserLastModified { get; set; }
        
        public ICollection<Room>? Rooms { get; set; }

        public ICollection<Rate>? Rates { get; set; }
        public ICollection<HouseImage>? HouseImages { get; set; }
        public ICollection<Report>? Reports { get; set; }

        //internal object Include(Func<object, object> value)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
