namespace AS_Taranenko_lab1_gr1.Models
{
    public enum Status
    {
        New = 0,
        Paid = 1,
        Pending = 2,
        Shipped = 3,
        InTrasit = 4,
        Delivered = 5,
        Completed = 6
    }
    public class OrderStatus
    {
        public int Id {  get; set; }
        public Status Status { get; set; }
        public virtual ICollection<Order>? Orders { get; set; }
        public int OrderId { get; set; }
        public int OrderStatusId { get; set; }
        public virtual ICollection<OrderStatusHistory>? OrderStatusHistories { get; set; }
    }
}
