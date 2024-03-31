using AutoMapper;
using Demo_Mock_House_Finder.Model.DTO;
using Demo_Mock_House_Finder.Model;
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
    public class CommuneController : ControllerBase
    {
        protected APIResponse _response;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public CommuneController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            this._response = new();
        }
        //public CommuneController(IGenericRepository<Commune> dbCommune, IMapper mapper)
        //{
        //    _dbCommune = dbCommune;
        //    _mapper = mapper;
        //    this._response = new();
        //}

        [HttpGet]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<APIResponse>> GetAllCommune()
        {
            try
            {
                IEnumerable<Commune> CommuneList = await _unitOfWork.Communes.GetAllAsync();
                _response.Result = _mapper.Map<List<CommuneDTO>>(CommuneList);
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
        [HttpGet("{id:int}", Name = "GetCommuneByID")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> GetCommuneByID(int id)
        {
            try
            {
                if (id == 0)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }
                var Commune = await _unitOfWork.Communes.GetByIDAsync(u => u.CommuneID == id);
                if (Commune == null)
                {
                    _response.StatusCode = HttpStatusCode.NotFound;
                    return NotFound(_response);
                }
                _response.Result = _mapper.Map<CommuneDTO>(Commune);
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
        public async Task<ActionResult<APIResponse>> CreateCommune([FromBody] CommuneCreateDTO createDTO)
        {
            try
            {
                if (await _unitOfWork.Communes.GetByIDAsync(u => u.CommuneName.ToLower() == createDTO.CommuneName.ToLower()) != null)
                {
                    ModelState.AddModelError("CustomError", "Commune already Exists!");
                    return BadRequest(ModelState);
                }
                if (createDTO == null)
                {
                    return BadRequest(createDTO);
                }

                Commune model = _mapper.Map<Commune>(createDTO);

                await _unitOfWork.Communes.CreateAsync(model);
                _response.StatusCode = HttpStatusCode.Created;
                _response.IsSuccess = true;
                return CreatedAtAction(nameof(GetCommuneByID), new { id = model.CommuneID }, model);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                    = new List<string> { ex.ToString() };
            }
            return _response;
        }
        [HttpDelete("{id:int}", Name = "DeleteCommune")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Authorize(Roles = "CUSTOM")]
        public async Task<ActionResult<APIResponse>> DeleteCommuneByID(int id)
        {
            try
            {
                if (id == 0)
                {
                    return BadRequest();
                }
                var Commune = await _unitOfWork.Communes.GetByIDAsync(u => u.CommuneID == id);
                if (Commune == null)
                {
                    return NotFound();
                }
                await _unitOfWork.Communes.RemoveAsync(Commune);
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
        [HttpPut("id:int", Name = "UpdateCommune")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<APIResponse>> UpdateCommune(int id, [FromBody] CommuneUpdateDTO updateDTO)
        {
            try
            {
                if (updateDTO == null || id != updateDTO.CommuneID)
                {
                    return BadRequest();
                }

                Commune model = _mapper.Map<Commune>(updateDTO);

                await _unitOfWork.Communes.UpdateAsync(model);
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
        [HttpPatch("id:int", Name = "UpdatePartialCommune")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<APIResponse>> UpdatePartialCommune(int id, JsonPatchDocument<CommuneUpdateDTO> patchDTO)
        {
            try
            {
                if (patchDTO == null || id == 0)
                {
                    return BadRequest();
                }

                var Commune = await _unitOfWork.Communes.GetByIDAsync(u => u.CommuneID == id, tracked: false);
                CommuneUpdateDTO CommuneDTO = _mapper.Map<CommuneUpdateDTO>(Commune);

                if (Commune == null)
                {
                    return BadRequest();
                }
                patchDTO.ApplyTo(CommuneDTO, ModelState);
                Commune model = _mapper.Map<Commune>(CommuneDTO);

                await _unitOfWork.Communes.UpdateAsync(model);
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
