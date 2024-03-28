using Demo_Mock_House_Finder.Data;
using Demo_Mock_House_Finder.Model;
using Demo_Mock_House_Finder.Repository.GenericRepository;
using Demo_Mock_House_Finder.Repository.IRepository;

namespace Demo_Mock_House_Finder.Repository
{
    public class CampusRepository : GenericRepository<Campus>, ICampusRepository
    {
        public CampusRepository(ApplicationDbContext db) : base(db)
        {

        }
    }
}
