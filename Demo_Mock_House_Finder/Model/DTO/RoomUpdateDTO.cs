using System.ComponentModel.DataAnnotations.Schema;

namespace Demo_Mock_House_Finder.Model.DTO
{
    public class RoomUpdateDTO
    {
        public int RoomID { get; set; }
        public string? RoomName { get; set; }
        public double? Price { get; set; }
        public string? Information { get; set; }
        public int? Area { get; set; }
        public bool? Airon { get; set; }
        public int? MaxAmountOfPeople { get; set; }
        public int? CurrentAmountOfPeople { get; set; }
        public int? BuildingNumber { get; set; }
        public int? FloorNumber { get; set; }

        public int? StatusID { get; set; }
        [ForeignKey("StatusID")]
        public Status? Status { get; set; }

        public int? RoomTypeID { get; set; }
        [ForeignKey("RoomTypeID")]
        public RoomType? RoomType { get; set; }
        public int? HouseID { get; set; }
        [ForeignKey("HouseID")]
        public House? House { get; set; }

        public int? CreatedBy { get; set; }
        [ForeignKey("CreatedBy")]
        public User? UserCreated { get; set; }



        public int? LastModifiedBy { get; set; }
        [ForeignKey("LastModifiedBy")]
        public User? UserLastModified { get; set; }

        public ICollection<RoomImage>? Roomimages { get; set; }
        public ICollection<RoomHistory>? RoomHistories { get; set; }
    }
}
