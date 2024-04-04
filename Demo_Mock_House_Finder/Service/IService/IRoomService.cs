using Demo_Mock_House_Finder.Model.DTO;

namespace Demo_Mock_House_Finder.Service.IService
{
    public interface IRoomService
    {
        Task<List<RoomDTO>> GetAllRoomByHouseID(int id);
        Task<List<RateDTO>> GetRateRoomByHouseID(int id);
        //Task<List<HouseDTO>> GetHouseByName(string Name);
        //Task<List<HouseDTO>> GetHouseByGoogleMapLocation(string googleMapLocation);
        //Task<HouseDTO> GetHouseDetailByID(int id);
        //Task<List<RateDTO>> GetRateByHouseID(int id);
        //Task<LandlordDTO> GetLandlordByHouseID(int id);
    }
}
