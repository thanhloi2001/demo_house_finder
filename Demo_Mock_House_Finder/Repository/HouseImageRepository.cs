using Demo_Mock_House_Finder.Data;
using Demo_Mock_House_Finder.Model;
using Demo_Mock_House_Finder.Repository.GenericRepository;
using Demo_Mock_House_Finder.Repository.IRepository;

namespace Demo_Mock_House_Finder.Repository
{
    public class HouseImageRepository: GenericRepository<HouseImage>, IHouseImageRepository
    {
        public HouseImageRepository(ApplicationDbContext db) : base(db)
        {

        }
    }
}
