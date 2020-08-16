using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Backend.Dtos
{
    public class PointItemReadDto
    {
        public int Id { get; set; }

        public string Image { get; set; }

        public string ImageUrl
        {
            get
            {
                return $"http://localhost:5000/Uploads/{Image}";
            }
        }

        public string Name { get; set; }

        public string Whatsapp { get; set; }

        public decimal Latitude { get; set; }

        public decimal Longitude { get; set; }

        public string City { get; set; }

        public string Uf { get; set; }

        [JsonPropertyName("items")]
        public IEnumerable<ItemIntoPointReadDto> ItemsIntoPoint { get; set; }
    }

    public class ItemIntoPointReadDto
    {
        public string Title { get; set; }
    }
}
