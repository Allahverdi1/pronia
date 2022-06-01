namespace proniaTask.Models
{
    public class ProductImage
    {
        public int Id { get; set; }
        public string ImgUrl { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsActive { get; set; }
        public Product  Product { get; set; }
        public int ProductId { get; set; }
    }
}
