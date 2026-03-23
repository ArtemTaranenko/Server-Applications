namespace AS_Taranenko_lab1_gr1.Models
{
    public class CustomerProfile
    {

        public int Id { get; set; }
        
        public string Phone {  get; set; }
        public DateTime DateOfBirth { get; set; }
        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; } = null!;
    }
}
