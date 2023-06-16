using System.ComponentModel.DataAnnotations;

namespace IdentityApi.ViewModel
{
    public class LoginViewModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
