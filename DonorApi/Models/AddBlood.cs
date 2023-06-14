using System.ComponentModel.DataAnnotations.Schema;

namespace DonorApi.Models
{
    public class AddBlood
    {
        public int Id { get; set; }
        public int Unit { get; set; }
        [ForeignKey("Donor")]
        public int DonorId { get; set; }
    }
}
