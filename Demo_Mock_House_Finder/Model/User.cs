using Demo_Mock_House_Finder.Model.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Demo_Mock_House_Finder.Model
{
    [Table("User")]
    public class User
    {
        [Key]
        public int UserId { get; set; }
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

        [ForeignKey("RoleID")]
        public UserRole? UserRole { get; set; }

        public DateTime? CreatedDate { get; set; }
        public DateTime? LastModifiedDate { get; set; }

        public int? CreatedBy { get; set; }

        [ForeignKey("CreatedBy")]
        public User? UserCreatedBy { get; set; }

        public int? LastModifiedBy { get; set; }

        [ForeignKey("LastModifiedBy")]
        public User? UserLastModifiedBy { get; set; }

        public ICollection<Rate>? Rates { get; set; }
        public ICollection<Report>? Reports { get; set; }
        public ICollection<House>? Houses { get; set; }
        
    }
}
