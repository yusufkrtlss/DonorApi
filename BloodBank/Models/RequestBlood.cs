namespace BloodBank.Models
{
    public class RequestBlood
    {
        // Requester hospital, city, town, blood type, units
        public int Id { get; set; }
        public string Requester { get; set; }
        public string City { get; set; }
        public string Town { get; set; }
        public string BloodType { get; set; }
        public int Unit { get; set; }
    }
}
