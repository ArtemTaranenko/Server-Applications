namespace AS_Taranenko_lab1_gr1.Models
{
    public class Adress
    {
        public int Id { get; set; }
        public string City { get; set; } = null!;
        public string PostalCode { get; set; } = null!;
        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; } = null!;
    }
}
