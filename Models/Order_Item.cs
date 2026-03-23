using System.ComponentModel.DataAnnotations.Schema;

namespace AS_Taranenko_lab1_gr1.Models
{
    public class Order_Item
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public virtual Order Order { get; set; } = null!;
        public int ProductId { get; set; }
        public virtual Product Product { get; set; } = null!;
        public int Quantity { get; set; }

        [Column(TypeName = "decimal(18,4)")]
        public decimal UnitPrice { get; set; }
    }
}
