using System.Collections.Generic;
using AS_Taranenko_lab1_gr1.Controllers;
using AS_Taranenko_lab1_gr1.Models;
using Microsoft.EntityFrameworkCore;


namespace AS_Taranenko_lab1_gr1
{
    public class MyDbContext: DbContext
    {
        public virtual DbSet<Category> Categories { get; set; } = null!;
        public virtual DbSet<Tag> Tags { get; set; } = null!;
        public virtual DbSet<Adress> Adresses { get; set; } = null!;
        public virtual DbSet<Product> Products { get; set; } = null!;
        public virtual DbSet<Order> Orders { get; set; } = null!;
        public virtual DbSet<OrderStatus> OrderStatuses { get; set; } = null!;
        public virtual DbSet<OrderStatusHistory> OrderStatusHistories { get; set; } = null!;

        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseLazyLoadingProxies();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .HasIndex(c => c.Name)
                .IsUnique();
            modelBuilder.Entity<Customer>()
                .HasOne(c => c.CustomerProfile)
                .WithOne(c => c.Customer)
                .HasForeignKey<CustomerProfile>(c => c.CustomerId);
        }
    }
}
