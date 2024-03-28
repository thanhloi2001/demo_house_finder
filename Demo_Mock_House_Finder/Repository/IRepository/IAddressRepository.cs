using Demo_Mock_House_Finder.Model;
using Demo_Mock_House_Finder.Repository.GenericRepository;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Demo_Mock_House_Finder.Repository.IRepository
{
    public interface IAddressRepository : IGenericRepository<Address>
    {
        
    }
}
