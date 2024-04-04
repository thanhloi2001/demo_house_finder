using AutoMapper;
using Demo_Mock_House_Finder.Model;
using Demo_Mock_House_Finder.Model.DTO;
using Demo_Mock_House_Finder.Service.IService;
using Demo_Mock_House_Finder.UOW;
using System.Linq.Expressions;

namespace Demo_Mock_House_Finder.Service
{
    public class RoomService : IRoomService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public RoomService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<RoomDTO>> GetAllRoomByHouseID(int id)
        {
            try
            {
                Expression<Func<House, bool>> filterExpression = house => house.HouseID == id;
                House house = await _unitOfWork.Houses.GetByIDAsync(filterExpression, includeProperties: h => h.Rooms);
                if (house == null)
                {
                    throw new Exception($"No house found with the provided ID: {id}");
                }
                if (house.Rooms == null)
                {
                    throw new Exception($"No Room found with the provided ID: {id}");

                }
                List<RoomDTO> roomDTO = _mapper.Map<List<RoomDTO>>(house.Rooms);
                return roomDTO;
            }
            catch (Exception ex)
            {
                throw new Exception("Error occurred while getting Room by house ID.", ex);
            }
        }
        public async Task<List<RateDTO>> GetRateRoomByHouseID(int id)
        {
            try
            {
                Expression<Func<Rate, bool>> filterExpression = rate => rate.House.HouseID == id;
                List<Rate> rates = await _unitOfWork.Rates.GetAllAsync(filterExpression);
                List<RateDTO> rateDTOs = _mapper.Map<List<RateDTO>>(rates);
                if (rateDTOs == null || !rateDTOs.Any())
                {
                    throw new Exception("No Rates found for the room of house with ID: {id}.");
                }

                return rateDTOs;
            }
            catch (Exception ex)
            {
                throw new Exception("Error occured while getting rate and comment for the room of House.", ex);
            }
        }

        public void savechange()
        {
            _unitOfWork.Commit();
        }
    }
}
