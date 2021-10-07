using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace DL
{
    public class P1DBContext : DbContext
    {
        public P1DBContext() : base() { }
        //public P1DBContext(DbContextOptions<P1DBContext> options) : base(options) { }
        public P1DBContext(DbContextOptions options) : base(options) { }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Inventory> Inventory { get; set; }
        public DbSet<LineItem> LineItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<StoreFront> StoreFronts { get; set; }

        // protected virtual void OnModelingCreating(System.Data.Entity.DbModelBuilder modelBuilder);
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        // base.OnModelCreating(modelBuilder);



        //}
        //public virtual Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder P1DBContext.Ignore(string Product, Inventory.Name); 

        private class NotMappedAttribute : Attribute
        {
        }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Inventory>(entity =>
            {
                entity.ToTable("Inventory");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Inventory)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK__Inventory__Produ__57A801BA");

                entity.HasOne(d => d.Store)
                    .WithMany(p => p.Inventory)
                    .HasForeignKey(d => d.StoreId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__Inventory__Store__56B3DD81");
            });

            modelBuilder.Entity<LineItem>(entity =>
            {
                entity.Property(e => e.ItemQuantity).HasColumnName("Item_Quantity");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.LineItems)
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("FK__LineItems__Order__66EA454A");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.LineItems)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK__LineItems__Produ__65F62111");

                //entity.HasOne(d => d.Store)
                    //.WithMany(p => p.LineItems)
                    //.HasForeignKey(d => d.StoreId)
                    //.HasConstraintName("FK__LineItems__Store__67DE6983");
            });
        }
    }
}

