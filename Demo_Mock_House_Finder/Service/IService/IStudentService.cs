using Demo_Mock_House_Finder.Model;

namespace Demo_Mock_House_Finder.Service.IService
{
    public interface IStudentService
    {
        //Task<Report> SendOrderAccommondation();
        Task ReportViolatedHouse(int HouseID, string reportContent);

    }
}
