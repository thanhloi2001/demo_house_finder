using Demo_Mock_House_Finder.Model;
using Demo_Mock_House_Finder.Model.DTO;

namespace Demo_Mock_House_Finder.Service.IService
{
    public interface IHouseService
    {
        Task<List<HouseDTO>> GetAllHouse();
        Task<List<HouseDTO>> GetHouseByName(string Name);
        Task<List<HouseDTO>> GetHouseByGoogleMapLocation(string googleMapLocation);
        Task<HouseDTO> GetHouseDetailByID(int id);
        Task<List<RateDTO>> GetRateByHouseID(int id);
        Task<LandlordDTO> GetLandlordByHouseID(int id);
    }
}