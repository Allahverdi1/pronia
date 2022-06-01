using System.Collections.Generic;

namespace proniaTask.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Raiting { get; set; }
        public Category Category { get; set; }
        public List<ProductImage> productImages { get; set; }
        public int CategoryId { get; set; }
        public float Price { get; set; }
    }
}
