namespace AS_Taranenko_lab1_gr1.Models
{
    public class HomeView
    {
        public ICollection<Category> Categories { get; set; } = null!;
        public ICollection<Tag> Tags { get; set; } = null!;
        public ICollection<Adress> Adresses { get; set; } = null!;
    }
}
