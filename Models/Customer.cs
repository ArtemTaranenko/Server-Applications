using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AS_Taranenko_lab1_gr1.Models

{ 
    public class Customer
    {
        public int Id {  get; set; }
        public string? Name { get; set; }
        public virtual CustomerProfile CustomerProfile { get; set; } = null!;

        public virtual ICollection<Adress> Adresses { get; set; } = null!;
        public virtual ICollection<Order> Orders { get; set; } = null!;
        //public virtual ICollection<Review> Reviews { get; set; } = null!;

    }
}
