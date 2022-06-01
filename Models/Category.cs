using System.Collections.Generic;

namespace proniaTask.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsDeleted { get; set; }
        public List<Product> Product { get; set; }
    }
}
