using Demo_Mock_House_Finder.Model.DTO;

namespace Demo_Mock_House_Finder.Service.IService
{
    public interface IHouseService
    {
        Task<List<HouseDTO>> GetAllHouse();
        Task<List<HouseDTO>> GetHouseByName(string Name);
        //Task<List<HouseDTO>> GetHouseByID(int ID);
        //Task<List<HouseDTO>> FilterHousesAsync(string criteria);
        //Task<HouseDTO> GetHouseDetailAsync(int houseId);
        //Task<string> GetHousePositionOnMapAsync(int houseId);
        //Task<List<RateAndComment>> GetRateAndCommentsAsync(int houseId);
        //Task<LandlordInformation> GetLandlordInformationAsync(int houseId);

    }
}