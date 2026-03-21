using System.ComponentModel.DataAnnotations;

namespace AS_Taranenko_lab1_gr1.Models

{ 
    public class Customer
    {
        [Key]
        public int Id {  get; set; }
        public string Name { get; set; }
        public Customer_Profile CustomerProfile { get; set; } 
        public ICollection<Adress> Adresses { get; set; } = new List<Adress>();
        public List<Order> Orders { get; set; }
        public List<Review> Reviews { get; set; }

    }
}
