using Azure;
using Demo_Mock_House_Finder.Model;
using Demo_Mock_House_Finder.Model.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Net;
using Demo_Mock_House_Finder.UOW;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch.Internal;
using Demo_Mock_House_Finder.Service.IService;
using System.Linq;

namespace Demo_Mock_House_Finder.Service
{
   
    public class HouseService : IHouseService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public HouseService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<HouseDTO>> GetAllHouse()
        {
            IEnumerable<House> houseList = await _unitOfWork.Houses.GetAllAsync();
            //List<HouseDTO> a = _mapper.Map<List<HouseDTO>>(houseList);
            return _mapper.Map<List<HouseDTO>>(houseList);
        }

        public async Task<List<HouseDTO>> GetHouseByName(string Name)
        {
            try
            {
                // Tạo biểu thức Lambda để lọc theo tên của nhà
                Expression<Func<House, bool>> filterExpression = house => house.HouseName.Contains(Name);

                // Sử dụng Generic Repository để lấy danh sách các nhà dựa trên biểu thức lọc
                List<House> filteredHouses = await _unitOfWork.Houses.GetAllAsync(filterExpression);
                List<HouseDTO> filteredHousesDTO = _mapper.Map<List<HouseDTO>>(filteredHouses);

                if (filteredHousesDTO == null || !filteredHouses.Any())
                {
                    throw new Exception("No houses found with the provided name.");
                }
                return filteredHousesDTO;
            }
            catch (Exception ex)
            {
                // Xử lý ngoại lệ nếu có
                throw new Exception("Error occurred while filtering houses.", ex);
            }
        }

        public async Task<List<HouseDTO>> GetHouseByGoogleMapLocation(string googleMapLocation)
        {
            try
            {
                Expression<Func<House, bool>> filterExpression = house => house.Address.GoogleMapLocation == googleMapLocation;
                List<House> filteredHouses = await _unitOfWork.Houses.GetAllAsync(filterExpression, h=>h.Address);
                List<HouseDTO> filteredHousesDTO = _mapper.Map<List<HouseDTO>>(filteredHouses);

                if (filteredHousesDTO == null || !filteredHouses.Any())
                {
                    throw new Exception("No houses found with the provided Google Map Location.");
                }

                return filteredHousesDTO;
            }
            catch (Exception ex)
            {
                throw new Exception("Error occurred while filtering houses by Google Map Location.", ex);
            }
        }

        public void savechange()
        {
            _unitOfWork.Commit();
        }
       

    }
}
