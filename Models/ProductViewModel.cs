namespace AS_Taranenko_lab1_gr1.Models
{
    public class ProductViewModel
    {
        public ICollection<Category> Categories { get; set; } = null!;
        public ICollection<Tag> Tags { get; set; } = null!;
        public ICollection<Product> Products { get; set; } = null!;
        public int? SelectedCategoryId { get; set; }
    }
}
