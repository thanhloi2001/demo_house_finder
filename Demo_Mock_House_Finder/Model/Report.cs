using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Demo_Mock_House_Finder.Model
{
    [Table("Report")]
    public class Report
    {
        [Key]
        public int ReportID { get; set; }
        public string? ReportContent { get; set; }
        public int? HouseID { get; set; }
        [ForeignKey("HouseID")]
        public House? House { get; set; }

        public int? StudentID { get; set; }
        [ForeignKey("StudentID")]
        public User? UserStudent { get; set; }

        public DateTime? CreatedDate { get; set; }
        public DateTime? LastModifiedDate { get; set; }

        public int? CreatedBy { get; set; }
        [ForeignKey("CreatedBy")]
        public User? UserCreated { get; set; }

        public int? LastModifiedBy { get; set; }
        [ForeignKey("LastModifiedBy")]
        public User? UserLastModified { get; set; }
    }
}
