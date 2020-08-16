namespace Backend.Models
{
    public class PointItem
    {
        public int PointId { get; set; }
        public int ItemId { get; set; }

        public Point Point { get; set; }
        public Item Item { get; set; }
    }
}