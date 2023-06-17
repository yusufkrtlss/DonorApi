using System.ComponentModel.DataAnnotations;

namespace DonorApi.ViewModel
{
    public class AddBloodDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Enter a Full name")]
        [StringLength(100, ErrorMessage = "Fullname should not be exceed 100 characters.")]
        public string Fullname { get; set; }
        [Required(ErrorMessage = "Enter a Blood Type")]
        public string BloodType { get; set; }
        [Required(ErrorMessage = "Enter a Town")]
        public string Town { get; set; }
        [Required(ErrorMessage = "Enter a City")]
        public string City { get; set; }

        [Required(ErrorMessage = "Enter a Unit")]
        [Range(0, int.MaxValue, ErrorMessage = "Unit must be a positive number")]
        public int Unit { get; set; }
    }
}
