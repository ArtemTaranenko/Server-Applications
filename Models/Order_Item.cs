using System.ComponentModel.DataAnnotations.Schema;

namespace AS_Taranenko_lab1_gr1.Models
{
    public class Order_Item
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }

        [Column(TypeName = "decimal(18,4)")]
        public decimal UnitPrice { get; set; }
    }
}
