using System.ComponentModel.DataAnnotations;

namespace Demo_Mock_House_Finder.Model.DTO
{
    public class RegisterationRequestDTO
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public int RoleID { get; set; }

    }
}
