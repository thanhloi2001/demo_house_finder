using Azure;
using Demo_Mock_House_Finder.Model;
using Demo_Mock_House_Finder.Service.IService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Demo_Mock_House_Finder.Controllers
{
    public class StudentController : Controller
    {
        protected APIResponse _response;
        private readonly IStudentService _studentService;
        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
            this._response = new();
        }

        [Authorize(Roles = "Student")]
        [Route("ReportViolatedHouse")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> ReportViolatedHouse(int houseID, string reportContent)
        {
            try
            {
                await _studentService.ReportViolatedHouse(houseID, reportContent);
                _response.IsSuccess = true;
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
