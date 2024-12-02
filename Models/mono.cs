using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Models
{
    public class mono
    {
        [Required]
        public int id { get; set; }
        [Required]
        public string username { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string password { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Compare("password",ErrorMessage ="the password and confirm password do not match")]
        public string confirm_password { get; set; }
        [Required]
        [EmailAddress(ErrorMessage ="Invalied Email format")]
        public string Email { get; set; }

        [Required]
        [Range(18,100,ErrorMessage ="age must be between the 18 to 100")]
        public int age { get; set; }

    }
}
