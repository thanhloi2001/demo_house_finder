using Microsoft.AspNetCore.Mvc;
using Demo_Mock_House_Finder.Model;
using Microsoft.AspNetCore.JsonPatch;
using AutoMapper;
using Demo_Mock_House_Finder.Data;
using Demo_Mock_House_Finder.Repository.GenericRepository;
using Microsoft.AspNetCore.Authorization;
using System.Net;
using Demo_Mock_House_Finder.Model.DTO;
using Demo_Mock_House_Finder.UOW;

namespace Demo_Mock_House_Finder.Controllers
{
    [Route("api/AddressAPI")]
    [ApiController]
    public class AddressAPIController : ControllerBase
    {
        protected APIResponse _response;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public AddressAPIController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            this._response = new();
        }
        //public AddressAPIController(IGenericRepository<Address> dbAddress, IMapper mapper)
        //{
        //    _dbAddres = dbAddress;
        //    _mapper = mapper;
        //    this._response = new();
        //}

        [HttpGet]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<APIResponse>> GetAllAddress()
        {
            try
            {
                IEnumerable<Address> addressList = await _unitOfWork.Addresses.GetAllAsync();
                _response.Result = _mapper.Map<List<AddressDTO>>(addressList);
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
        [HttpGet("{id:int}", Name = "GetAddressByID")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> GetAddressByID(int id)
        {
            try
            {
                if (id == 0)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }
                var address = await _unitOfWork.Addresses.GetByIDAsync(u => u.AddressID == id);
                if (address == null)
                {
                    _response.StatusCode = HttpStatusCode.NotFound;
                    return NotFound(_response);
                }
                _response.Result = _mapper.Map<AddressDTO>(address);
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
        [HttpPost]
        [Authorize(Roles = "admin")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<APIResponse>> CreateAddress([FromBody] AddressCreateDTO createDTO)
        {
            try
            {                
                if (await _unitOfWork.Addresses.GetByIDAsync(u => u.AddressName.ToLower() == createDTO.AddressName.ToLower()) != null)
                {
                    ModelState.AddModelError("CustomError", "Address already Exists!");
                    return BadRequest(ModelState);
                }
                if (createDTO == null)
                {
                    return BadRequest(createDTO);
                }
                
                Address model = _mapper.Map<Address>(createDTO);
                
                await _unitOfWork.Addresses.CreateAsync(model);
                _response.StatusCode = HttpStatusCode.Created;
                _response.IsSuccess = true;
                return CreatedAtAction(nameof(GetAddressByID), new { id = model.AddressID }, model);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                    = new List<string> { ex.ToString() };
            }
            return _response;
        }
        [HttpDelete("{id:int}", Name = "DeleteAddress")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Authorize(Roles = "CUSTOM")]
        public async Task<ActionResult<APIResponse>> DeleteAddressByID(int id)
        {
            try
            {
                if (id == 0)
                {
                    return BadRequest();
                }
                var address = await _unitOfWork.Addresses.GetByIDAsync(u => u.AddressID == id);
                if (address == null)
                {
                    return NotFound();
                }
                await _unitOfWork.Addresses.RemoveAsync(address);
                _response.StatusCode = HttpStatusCode.NoContent;
                _response.IsSuccess = true;
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
        [HttpPut("id:int", Name = "UpdateAddress")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<APIResponse>> UpdateAddress(int id, [FromBody] AddressUpdateDTO updateDTO)
        {
            try
            {
                if (updateDTO == null || id != updateDTO.AddressID)
                {
                    return BadRequest();
                }                

                Address model = _mapper.Map<Address>(updateDTO);

                await _unitOfWork.Addresses.UpdateAsync(model);
                _response.StatusCode = HttpStatusCode.NoContent;
                _response.IsSuccess = true;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                    = new List<string>() { ex.ToString() };
            }
            return _response;
        }
        [HttpPatch("id:int", Name = "UpdatePartialAddress")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<APIResponse>> UpdatePartialAddress(int id, JsonPatchDocument<AddressUpdateDTO> patchDTO)
        {
            try
            {
                if (patchDTO == null || id == 0)
                {
                    return BadRequest();
                }
           
                var address = await _unitOfWork.Addresses.GetByIDAsync(u => u.AddressID == id, tracked: false);
                AddressUpdateDTO addressDTO = _mapper.Map<AddressUpdateDTO>(address);
                
                if (address == null)
                {
                    return BadRequest();
                }
                patchDTO.ApplyTo(addressDTO, ModelState);
                Address model = _mapper.Map<Address>(addressDTO);

                await _unitOfWork.Addresses.UpdateAsync(model);
                _response.StatusCode = HttpStatusCode.NoContent;
                _response.IsSuccess = true;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                    = new List<string>() { ex.ToString() };
            }
            return _response;
        }
    }
}
