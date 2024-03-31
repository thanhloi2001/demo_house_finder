using AutoMapper;
using Demo_Mock_House_Finder.Model.DTO;
using Demo_Mock_House_Finder.Model;
using Demo_Mock_House_Finder.UOW;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using Demo_Mock_House_Finder.Service;
using Demo_Mock_House_Finder.Service.IService;

namespace Demo_Mock_House_Finder.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HouseController : ControllerBase
    {
        protected APIResponse _response;
        private readonly IHouseService _houseService;
        public HouseController(IHouseService houseService, IMapper mapper)
        {
            _houseService = houseService;
            this._response = new();
        }

        [Route("GetAllHouse")]
        [HttpGet]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<APIResponse>> GetAllHouse()
        {
            try
            {
                _response.Result = _houseService.GetAllHouse();
                _response.StatusCode = HttpStatusCode.OK;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                    = new List<string> { ex.ToString() };
            }
            return _response;
        }

        [Authorize(Roles = "admin")]
        [Route("GetHouseByName")]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> GetHouseByName(string Name)
        {
            try
            {               
                _response.Result = _houseService.GetHouseByName(Name);
                _response.StatusCode = HttpStatusCode.OK;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                    = new List<string> { ex.ToString() };
            }
            return _response;
        }

    }
}
