using AutoMapper;
using Demo_Mock_House_Finder.Model.DTO;
using Demo_Mock_House_Finder.Model;
using Demo_Mock_House_Finder.UOW;
using System.Linq.Expressions;
using Demo_Mock_House_Finder.Service.IService;
using System.Security.Claims;

namespace Demo_Mock_House_Finder.Service
{
    public class StudentService : IStudentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public StudentService(IUnitOfWork unitOfWork, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task ReportViolatedHouse(int houseID, string reportContent)
        {
            try
            {
                var userId = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
                var house = await _unitOfWork.Houses.GetByIDAsync(h => h.HouseID == houseID);
                if(house == null)
                {
                    throw new Exception("House does not exist.");
                }
                var report = new Report
                {
                    ReportContent = reportContent,
                    HouseID = houseID,
                    //StudentID = int.Parse(userId),
                    CreatedDate = DateTime.Now,
                };
                await _unitOfWork.Reports.CreateAsync(report);
                await _unitOfWork.Save();
            }
            catch (Exception ex) 
            {
                throw new Exception("An error occurred while reporting violated house.", ex);
            }
           
        }
        

        public void savechange()
        {
            _unitOfWork.Commit();
        }
    }
}
