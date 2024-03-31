using Demo_Mock_House_Finder.Model;
using Demo_Mock_House_Finder.Model.DTO;
using Demo_Mock_House_Finder.Repository.GenericRepository;

namespace Demo_Mock_House_Finder.Repository.IRepository
{
    public interface IUserRepository : IGenericRepository<User>
    {
        bool IsUniqueUser(string username);
        Task<LoginResponseDTO> Login(LoginRequestDTO loginRequestDTO);
        Task<User> Register(RegisterationRequestDTO registerationRequestDTO);
    }
}
