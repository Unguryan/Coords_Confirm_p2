namespace ConfirmCoords.Domain.Models
{
    public class CoordDetails
    {
        public int Id { get; set; }

        public decimal Longitude { get; set; }

        public decimal Latitude { get; set; }

        public string Details { get; set; }

        public DateTime Created { get; set; }

        public string PhoneNumber { get; set; }

    }
}
