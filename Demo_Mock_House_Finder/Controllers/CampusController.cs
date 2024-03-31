using AutoMapper;
using Demo_Mock_House_Finder.Model.DTO;
using Demo_Mock_House_Finder.Model;
using Demo_Mock_House_Finder.Repository.GenericRepository;
using Demo_Mock_House_Finder.UOW;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Demo_Mock_House_Finder.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CampusController : ControllerBase
    {
        protected APIResponse _response;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public CampusController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            this._response = new();
        }
        //public CampusController(IGenericRepository<Campus> dbCampus, IMapper mapper)
        //{
        //    _dbCampus = dbCampus;
        //    _mapper = mapper;
        //    this._response = new();
        //}

        [HttpGet]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<APIResponse>> GetAllCampus()
        {
            try
            {
                IEnumerable<Campus> CampusList = await _unitOfWork.Campuses.GetAllAsync();
                _response.Result = _mapper.Map<List<CampusDTO>>(CampusList);
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
        [HttpGet("{id:int}", Name = "GetCampusByID")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> GetCampusByID(int id)
        {
            try
            {
                if (id == 0)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }
                var Campus = await _unitOfWork.Campuses.GetByIDAsync(u => u.CampusID == id);
                if (Campus == null)
                {
                    _response.StatusCode = HttpStatusCode.NotFound;
                    return NotFound(_response);
                }
                _response.Result = _mapper.Map<CampusDTO>(Campus);
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
        public async Task<ActionResult<APIResponse>> CreateCampus([FromBody] CampusCreateDTO createDTO)
        {
            try
            {
                if (await _unitOfWork.Campuses.GetByIDAsync(u => u.CampusName.ToLower() == createDTO.CampusName.ToLower()) != null)
                {
                    ModelState.AddModelError("CustomError", "Campus already Exists!");
                    return BadRequest(ModelState);
                }
                if (createDTO == null)
                {
                    return BadRequest(createDTO);
                }

                Campus model = _mapper.Map<Campus>(createDTO);

                await _unitOfWork.Campuses.CreateAsync(model);
                _response.StatusCode = HttpStatusCode.Created;
                _response.IsSuccess = true;
                return CreatedAtAction(nameof(GetCampusByID), new { id = model.CampusID }, model);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                    = new List<string> { ex.ToString() };
            }
            return _response;
        }
        [HttpDelete("{id:int}", Name = "DeleteCampus")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Authorize(Roles = "CUSTOM")]
        public async Task<ActionResult<APIResponse>> DeleteCampusByID(int id)
        {
            try
            {
                if (id == 0)
                {
                    return BadRequest();
                }
                var Campus = await _unitOfWork.Campuses.GetByIDAsync(u => u.CampusID == id);
                if (Campus == null)
                {
                    return NotFound();
                }
                await _unitOfWork.Campuses.RemoveAsync(Campus);
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
        [HttpPut("id:int", Name = "UpdateCampus")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<APIResponse>> UpdateCampus(int id, [FromBody] CampusUpdateDTO updateDTO)
        {
            try
            {
                if (updateDTO == null || id != updateDTO.CampusID)
                {
                    return BadRequest();
                }

                Campus model = _mapper.Map<Campus>(updateDTO);

                await _unitOfWork.Campuses.UpdateAsync(model);
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
        [HttpPatch("id:int", Name = "UpdatePartialCampus")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<APIResponse>> UpdatePartialCampus(int id, JsonPatchDocument<CampusUpdateDTO> patchDTO)
        {
            try
            {
                if (patchDTO == null || id == 0)
                {
                    return BadRequest();
                }

                var Campus = await _unitOfWork.Campuses.GetByIDAsync(u => u.CampusID == id, tracked: false);
                CampusUpdateDTO CampusDTO = _mapper.Map<CampusUpdateDTO>(Campus);

                if (Campus == null)
                {
                    return BadRequest();
                }
                patchDTO.ApplyTo(CampusDTO, ModelState);
                Campus model = _mapper.Map<Campus>(CampusDTO);

                await _unitOfWork.Campuses.UpdateAsync(model);
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
