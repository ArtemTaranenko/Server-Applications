using System.ComponentModel.DataAnnotations;
using MathNet.Numerics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.EntityFrameworkCore;

namespace AS_Taranenko_lab1_gr1.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        [Precision(18, 4)]
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
        //public ICollection<Order_Item> Order_Items{ get; set; }
        public virtual ICollection<Tag>? Tags { get; set; }
        //public ICollection<Review> Reviews { get; set; }
        [ValidateNever]
        public virtual Category? Category { get; set; }
    }
}
