using System.ComponentModel.DataAnnotations;
using MathNet.Numerics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.EntityFrameworkCore;

namespace AS_Taranenko_lab1_gr1.Models
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public int CustomerId { get; set; }
        [ValidateNever]
        public virtual Customer Customer { get; set; } = null!;
        public virtual ICollection<Order_Item> Items { get; set; } = null!;
        public int OrderStatusId { get; set; }
        [ValidateNever]
        public virtual OrderStatus OrderStatus { get; set; } = null!;
        public virtual ICollection<OrderStatusHistory>? OrderStatusHistories { get; set; }
    }
}
