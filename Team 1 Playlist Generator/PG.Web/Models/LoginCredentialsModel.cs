using System.ComponentModel.DataAnnotations;

namespace PG.Web.Models
{
    public class LoginCredentialsModel
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}