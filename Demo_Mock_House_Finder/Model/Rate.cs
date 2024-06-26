﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Demo_Mock_House_Finder.Model
{
    [Table("Rate")]
    public class Rate
    {
        [Key]
        public int RateID { get; set; }
        public int? Star {  get; set; }
        public string? Comment {  get; set; }
        public string? LandlordReply {  get; set; }
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
