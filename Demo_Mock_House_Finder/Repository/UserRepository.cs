using Demo_Mock_House_Finder.Data;
using Demo_Mock_House_Finder.Model;
using Demo_Mock_House_Finder.Model.DTO;
using Demo_Mock_House_Finder.Repository.GenericRepository;
using Demo_Mock_House_Finder.Repository.IRepository;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Demo_Mock_House_Finder.Repository
{
    public class UserRepository: GenericRepository<User>, IUserRepository
    {
        private readonly ApplicationDbContext _db;
        private string secretKey;

        public UserRepository(ApplicationDbContext db) : base(db)
        {
            
        }
        public UserRepository(ApplicationDbContext db, IConfiguration configuration) : base(db)
        {
            _db = db;
            secretKey = configuration.GetValue<string>("ApiSettings:Secret");
        }
        public bool IsUniqueUser(string username)
        {
            var user = _db.Users.FirstOrDefault(x => x.UserName == username);
            if (user == null)
            {
                return true;
            }
            return false;
        }
        public async Task<User> Register(RegisterationRequestDTO registerationRequestDTO)
        {
            User user = new()
            {
                UserName = registerationRequestDTO.UserName,
                Password = registerationRequestDTO.Password,
                DisplayName = registerationRequestDTO.Name,
                RoleID = registerationRequestDTO.RoleID
            };
            _db.Users.Add(user);
            await _db.SaveChangesAsync();
            user.Password = "";
            return user;
        }
        public async Task<LoginResponseDTO> Login(LoginRequestDTO loginRequestDTO)
        {
            
            var user = _db.Users.FirstOrDefault(u => u.UserName.ToLower() == loginRequestDTO.UserName.ToLower() && u.Password == loginRequestDTO.Password);
            
            if (user == null)
            {
                return new LoginResponseDTO()
                {
                    Token = "",
                    User = null
                };
            }
            var userRole = _db.UserRoles.FirstOrDefault(u => u.RoleID == user.RoleID);


            //if user was found generate JWT Token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(secretKey);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.UserID.ToString()),
                    new Claim(ClaimTypes.Role, userRole.RoleName)
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            LoginResponseDTO loginResponseDTO = new LoginResponseDTO()
            {
                Token = tokenHandler.WriteToken(token),
                User = user
            };
            return loginResponseDTO;
        }
    }
}
