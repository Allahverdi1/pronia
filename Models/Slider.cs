using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;

namespace proniaTask.Models
{
    public class Slider
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int DiscountPercent { get; set; }
        public string Description { get; set; }
        public string SliderImage { get; set; }
        [NotMapped]
        public IFormFile ImageFile { get; set; }
    }
}
