using System.ComponentModel.DataAnnotations;

namespace DonorSystemUI.Dtos.LoginDto
{
    public class LoginDto
    {
        [Required(ErrorMessage = "Kullanıcı Adını Giriniz")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Şifreyi Giriniz")]
        public string Password { get; set; }
    }
}
