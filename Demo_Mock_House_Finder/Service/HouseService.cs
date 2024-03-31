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
                List<HouseDTO> filteredHousesDTO =  _mapper.Map<List<HouseDTO>>(filteredHouses);

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

        //public async Task<List<HouseDTO>> GetHouseByID(int ID)
        //{
        //    throw new NotImplementedException();
        //}

        //Task<List<HouseDTO>> IHouseService.GetAllHouseByName(string Name)
        //{
        //    throw new NotImplementedException();
        //}

        //Task<House> IHouseService.GetHouseDetailAsync(int houseId)
        //{
        //    throw new NotImplementedException();
        //}

        //Task<string> IHouseService.GetHousePositionOnMapAsync(int houseId)
        //{
        //    throw new NotImplementedException();
        //}

        //Task<List<House>> IHouseService.GetListOfAvailableHousesAsync()
        //{
        //    throw new NotImplementedException();
        //}


        //public async Task<List<HouseDTO>> GetAllHouse()
        //{
        //    IEnumerable<House> houseList = await _unitOfWork.Houses.GetAllAsync();
        //    //List<HouseDTO> a = _mapper.Map<List<HouseDTO>>(houseList);
        //    return _mapper.Map<List<HouseDTO>>(houseList);
        //}

        //public async Task<List<HouseDTO>> GetAllHouseByName(string Name)
        //{
        //    IEnumerable<House> houseList = await _unitOfWork.Houses.GetAllAsync();
        //    List<HouseDTO> houseListDTO = _mapper.Map<List<HouseDTO>>(houseList);

        //    try
        //    {
        //        if (Name == "")
        //        {
        //            _response.StatusCode = HttpStatusCode.BadRequest;
        //            return BadRequest(_response);
        //        }
        //        var address = await _unitOfWork.Houses.GetByIDAsync(u => u.HouseName == Name);
        //        if (address == null)
        //        {
        //            _response.StatusCode = HttpStatusCode.NotFound;
        //            return NotFound(_response);
        //        }
        //        _response.Result = _mapper.Map<AddressDTO>(address);
        //        _response.StatusCode = HttpStatusCode.OK;
        //        return Ok(_response);
        //    }
        //    catch (Exception ex)
        //    {
        //        _response.IsSuccess = false;
        //        _response.ErrorMessages
        //            = new List<string> { ex.ToString() };
        //    }
        //    return _response;
        //}

    }
}
