namespace Backend.Dtos
{
    public class PointReadDto
    {
        public int Id { get; set; }
        public string Image { get; set; }

        public string Name { get; set; }
        public string Email { get; set; }
        public string Whatsapp { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string City { get; set; }
        public string Uf { get; set; }
    }
}
