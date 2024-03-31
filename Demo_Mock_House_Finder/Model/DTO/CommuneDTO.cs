using System.ComponentModel.DataAnnotations.Schema;

namespace Demo_Mock_House_Finder.Model.DTO
{
    public class CommuneDTO
    {
        public int CommuneID { get; set; }
        public string? CommuneName { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? DistrictID { get; set; }
        public District? District { get; set; }

        public ICollection<Village>? Villages { get; set; }
    }
}
