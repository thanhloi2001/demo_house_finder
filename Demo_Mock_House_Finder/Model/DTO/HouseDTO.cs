using System.ComponentModel.DataAnnotations.Schema;

namespace Demo_Mock_House_Finder.Model.DTO
{
    public class HouseDTO
    {
        public int HouseID { get; set; }
        public string? HouseName { get; set; }
        public string? Information { get; set; }
        public double? PowerPrice { get; set; }
        public double? WarerPrice { get; set; } 

        public int? AddressID { get; set; }
        public Address? Address { get; set; }

        public int? VillageID { get; set; }

        public Village? Village { get; set; }


        public int? LandlordID { get; set; }

        public User Landlord { get; set; }

        public int? CampusID { get; set; }
 
        public Campus Campus { get; set; }

        public int? CreatedBy { get; set; }
   
        public User UserCreated { get; set; }

        public int? LastModifiedBy { get; set; }
    
        public User UserLastModified { get; set; }

        public ICollection<Room>? Rooms { get; set; }
        public ICollection<Rate>? Rates { get; set; }
        public ICollection<HouseImage>? HouseImages { get; set; }
        public ICollection<Report>? Reports { get; set; }
    }
}
