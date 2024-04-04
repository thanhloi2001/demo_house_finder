using System.ComponentModel.DataAnnotations.Schema;

namespace Demo_Mock_House_Finder.Model.DTO
{
    public class RoomDTO
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

        public int? RoomTypeID { get; set; }
        public int? HouseID { get; set; }

        public ICollection<RoomImage>? Roomimages { get; set; }
        public ICollection<RoomHistory>? RoomHistories { get; set; }
    }
}
