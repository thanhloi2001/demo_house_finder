using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Demo_Mock_House_Finder.Model
{
    [Table("UserRole")]
    public class UserRole
    {
        [Key]
        public int RoleID { get; set; }
        public string? RoleName { get; set; }
        public DateTime? CreatedDate { get; set; }

        [JsonIgnore]
        public ICollection<User>? Users { get; set; }
    }
}
