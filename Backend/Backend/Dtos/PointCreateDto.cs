using System.ComponentModel.DataAnnotations;

namespace Backend.Dtos
{
    public class PointCreateDto
    {
        public string ImageUrl { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Whatsapp { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string City { get; set; }
        [MaxLength(2)]
        public string Uf { get; set; }
        public string Items { get; set; }
    }
}
