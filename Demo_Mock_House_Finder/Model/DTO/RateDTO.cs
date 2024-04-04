using System.ComponentModel.DataAnnotations.Schema;

namespace Demo_Mock_House_Finder.Model.DTO
{
    public class RateDTO
    {
        public int RateID { get; set; }
        public int? Star { get; set; }
        public string? Comment { get; set; }
        public string? LandlordReply { get; set; }
    }
}
