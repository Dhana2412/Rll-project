using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CookingAppMVC.Models
{
    public class Register
    {
        public int UserId { get; set; }

        [Required(ErrorMessage = "Please Enter FirstName")]
        public string FirstName { get; set; } = null!;

        [Required(ErrorMessage = "Please Enter LastName")]
        public string LastName { get; set; } = null!;

        [Required(ErrorMessage = "Please Enter UserName")]
        public string Username { get; set; } = null!;

        [Required(ErrorMessage = "Please Enter Email")]
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$", ErrorMessage = "Please enter a valid e-mail adress")]

        public string Email { get; set; } = null!;

        [Required(ErrorMessage = "Please Enter Password")]
        public string Password { get; set; } = null!;
        [Required(ErrorMessage = "Please Enter Confirm Password")]
        [Compare("Password", ErrorMessage = ("Confirm password not matched"))]
        public string ConfirmPassword { get; set; } = null!;
    }
}
