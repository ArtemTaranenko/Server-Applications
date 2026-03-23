namespace AS_Taranenko_lab1_gr1.Models
{
    public class OrderStatusHistory
    {
        public int Id { get; set; }
        public DateTime ChangedAt { get; set; }
        public int OrderId { get; set; }
        public virtual Order? Order { get; set; }
        public int OrderStatusId { get; set; }
        public virtual OrderStatus? OrderStatus { get; set; }

    }
}
