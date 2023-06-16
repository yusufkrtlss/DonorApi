using System.ComponentModel.DataAnnotations;

namespace DonorSystemUI.Dtos.LoginDto
{
    public class CreateNewStaffDto
    {

        [Required(ErrorMessage = "Enter a Username")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Enter a Password")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Enter the Password again")]
        [Compare("Password", ErrorMessage = "Password did not match !")]
        public string ConfirmPassword { get; set; }
    }
}
