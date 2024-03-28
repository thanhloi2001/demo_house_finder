using Demo_Mock_House_Finder.Model.DTO;
using Demo_Mock_House_Finder.Model;

namespace Demo_Mock_House_Finder.Repository.IRepository
{
    public interface IUserAuthenticationRepository
    {
        bool IsUniqueUser(string username);
        Task<LoginResponseDTO> Login(LoginRequestDTO loginRequestDTO);
        Task<LocalUser> Register(RegisterationRequestDTO registerationRequestDTO);
    }
}
