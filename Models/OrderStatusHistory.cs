namespace AS_Taranenko_lab1_gr1.Models
{
    public partial class OrderStatusHistory
    {
        public int Id { get; set; }
        public DateTime ChangedAt { get; set; }
        public int OrderId { get; set; }
        public virtual Order? Order { get; set; }
        public int OrderStatusId { get; set; }
        public virtual OrderStatus? OrderStatus { get; set; }

    }

    public partial class OrderStatusHistory
    {
        private readonly OrderStatusHistoryFluentInterface _set;

        public OrderStatusHistory()
        {
            _set = new OrderStatusHistoryFluentInterface(this);
        }

        public OrderStatusHistoryFluentInterface Set
        {
            get { return _set; }
        }
    }

    public class OrderStatusHistoryFluentInterface
    {
        private readonly OrderStatusHistory _history;

        public OrderStatusHistoryFluentInterface(OrderStatusHistory history)
        {
            _history = history;
        }

        public OrderStatusHistoryFluentInterface Order (Order order)
        {
            _history.Order = order;
            return this;
        }
        public OrderStatusHistoryFluentInterface OrderStatusId(int id)
        {
            _history.OrderStatusId = id;
            return this;
        }

        public OrderStatusHistoryFluentInterface ChangedAt(DateTime date)
        {
            _history.ChangedAt = date;
            return this;
        }
    }
}
