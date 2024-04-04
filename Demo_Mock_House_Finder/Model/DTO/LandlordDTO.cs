using Demo_Mock_House_Finder.Model.Enum;
using System.ComponentModel.DataAnnotations.Schema;

namespace Demo_Mock_House_Finder.Model.DTO
{
    public class LandlordDTO
    {
        public int UserID { get; set; }
        public string? DisplayName { get; set; }
        public EnumActive? Active { get; set; }

        public string? ProfileImageLink { get; set; }
        public string? PhoneNumber { get; set; }


        public string? FacebookURL { get; set; }
    }
}
