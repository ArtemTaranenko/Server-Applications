namespace AS_Taranenko_lab1_gr1.Models
{
    public class Customer_Profile
    {

        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string Phone {  get; set; }
        public DateTime DateOfBirth { get; set; }
        public virtual Customer Customer { get; set; }
    }
}
