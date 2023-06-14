using System.ComponentModel.DataAnnotations;

namespace DonorSystemUI.Dtos.DonorDto
{
    public class UpdateDonorDto
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
        [Required(ErrorMessage = "Enter a Phone No")]
        public string PhoneNo { get; set; }
        [Required(ErrorMessage = "Enter a Photo Url")]
        public string PhotoUrl { get; set; }
    }
}
