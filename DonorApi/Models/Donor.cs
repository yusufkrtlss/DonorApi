using System.ComponentModel.DataAnnotations.Schema;

namespace DonorApi.Models
{
    public class Donor
    {
        public int Id { get; set; }
        public string Fullname { get; set; }
        public string BloodType { get; set; }
        public string Town { get; set; }
        public string City { get; set; }
        public string PhoneNo { get; set; }
        public string? PhotoUrl { get; set; }
        public AddBlood AddBlood { get; set; }
        [ForeignKey("AddBlood")]
        public int AddBloodId { get; set; }
    }
}
