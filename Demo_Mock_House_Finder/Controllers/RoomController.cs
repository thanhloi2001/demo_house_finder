using AutoMapper;
using Azure;
using Demo_Mock_House_Finder.Model;
using Demo_Mock_House_Finder.Service.IService;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Demo_Mock_House_Finder.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : Controller
    {
        protected APIResponse _response;
        private readonly IRoomService _roomService;
        public RoomController(IRoomService roomService)
        {
            _roomService = roomService;
            this._response = new();
        }
        //[Authorize(Roles = "Admin")]
        [Route("GetAllRoomByHouseID")]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> GetAllRoomByHouseID(int id)
        {
            try
            {
                _response.Result = await _roomService.GetAllRoomByHouseID(id);
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
        //[Authorize(Roles = "Admin")]
        [Route("GetRateRoomByHouseID")]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> GetRateRoomByHouseID(int id)
        {
            try
            {
                _response.Result = await _roomService.GetRateRoomByHouseID(id);
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
