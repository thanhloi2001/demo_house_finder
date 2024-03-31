using System.ComponentModel.DataAnnotations;

namespace Demo_Mock_House_Finder.Model.DTO
{
    public class LoginRequestDTO
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
