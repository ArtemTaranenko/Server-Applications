namespace AS_Taranenko_lab1_gr1.Models
{
    public class Tag
    {
        public int Id {  get; set; }
        public string Name { get; set; }
        public virtual ICollection<Product>? Products { get; set; } = null!;
    }
}
