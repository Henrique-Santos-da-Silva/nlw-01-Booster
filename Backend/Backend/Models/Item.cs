using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Backend.Models
{
    public class Item
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Image { get; set; }

        public string ImageUrl { get; set; }

        public ICollection<PointItem> PointsItems { get; set; }
    }
}
