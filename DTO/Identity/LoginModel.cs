using System.ComponentModel.DataAnnotations;

namespace SmartSence.DTO.Identity
{
    public class LoginModel
    {
       
        public string? Username { get; set; }

       
        public string? Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string? Password { get; set; }
    }
}