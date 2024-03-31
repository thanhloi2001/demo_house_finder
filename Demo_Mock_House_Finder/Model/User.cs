using Demo_Mock_House_Finder.Model.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Demo_Mock_House_Finder.Model
{
    [Table("User")]
    public class User
    {
        [Key]
        public int UserID { get; set; }
        public string? UserName { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? DisplayName { get; set; }
        public EnumActive? Active { get; set; }

        public string? ProfileImageLink { get; set; }
        public string? PhoneNumber { get; set; }

        
        public string? FacebookURL { get; set; }
        
        
        public int? AddressID {  get; set; }
        
        [ForeignKey("AddressID")]
        public Address? Address { get; set; }
        
        
        public int? RoleID { get; set; }

        //[JsonIgnore]
        [ForeignKey("RoleID")]
        public UserRole? UserRole { get; set; }

        
        public DateTime? CreatedDate { get; set; }

        
        public DateTime? LastModifiedDate { get; set; }

        public int? CreatedBy { get; set; }
        //[JsonIgnore]
        [ForeignKey("CreatedBy")]
        public User? CreatedUser { get; set; }

        public int? LastModifiedBy { get; set; }
        //[JsonIgnore]
        [ForeignKey("LastModifiedBy")]
        public User? LastModifiedUser { get; set; }
        //[JsonIgnore]
        [InverseProperty("UserStudent")]
        public ICollection<Rate>? RatesStudent { get; set; }
        //[JsonIgnore]
        [InverseProperty("UserLastModified")]
        public ICollection<Rate>? RatesModified { get; set; }
        //[JsonIgnore]
        [InverseProperty("UserStudent")]   
        public ICollection<Report>? ReportsStudent { get; set; }
        //[JsonIgnore]
        [InverseProperty("UserLastModified")]
        public ICollection<Report>? ReportsModified { get; set; }
        //[JsonIgnore]
        [InverseProperty("Landlord")]
        public ICollection<House>? HousesLandlord { get; set; }
        //[JsonIgnore]
        [InverseProperty("UserLastModified")]
        public ICollection<House>? HousesModified { get; set; }


        
    }
}
