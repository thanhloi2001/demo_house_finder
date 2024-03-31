using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Demo_Mock_House_Finder.Model.DTO
{
    public class CampusDTO
    {
        public int CampusID { get; set; }
        public string? CampusName { get; set; }
        public int? AddressID { get; set; }
        
        public Address? Address { get; set; }

        public ICollection<House>? Houses { get; set; }

    }
}
