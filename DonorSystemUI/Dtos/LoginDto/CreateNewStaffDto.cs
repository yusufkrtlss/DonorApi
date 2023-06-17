using System.ComponentModel.DataAnnotations;

namespace DonorSystemUI.Dtos.LoginDto
{
    public class CreateNewStaffDto
    {
        [Display(Name = "Username")]
        [Required(ErrorMessage = "Please Enter your Username")]
        public string UserName { get; set; }
        [Display(Name = "Mail")]
        [Required(ErrorMessage = "Please Enter your E-mail")]
        public string Mail { get; set; }
        [Display(Name = "Password")]
        [Required(ErrorMessage = "Please Enter your Password")]
        public string Password { get; set; }

        [Display(Name = "Confirm Password")]
        [Compare("Password", ErrorMessage = "Passwords don't match")]
        public string ConfirmPassword { get; set; }
        
        [Required(ErrorMessage = "Please Enter your Phone")]
        public string Phone { get; set; }
        [Required(ErrorMessage = "Please Select whether you are staff or client")]
        public bool StaffOrClient { get; set; }
        
    }
}
