using System.ComponentModel.DataAnnotations;

namespace AS_Taranenko_lab1_gr1.Models
{
    public class Category
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Tytuł obowiązkowy")]
        [StringLength(100, ErrorMessage = "Zbyt długa nazwa")]
        public string Name { get; set; } = null!;
        public virtual ICollection<Product>? Products { get; set; }
    }
}
