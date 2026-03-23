namespace AS_Taranenko_lab1_gr1.Models
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime CreatedAt {  get; set; }
        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; } = null!;
        public virtual ICollection<Order_Item> Items { get; set; } = null!;
        public virtual OrderStatus OrderStatus { get; set; } = null!;
    }
}
