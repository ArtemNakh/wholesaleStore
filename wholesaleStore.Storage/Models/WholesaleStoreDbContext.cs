//using System;
//using System.Collections.Generic;
//using Microsoft.EntityFrameworkCore;

////Метод для генерації моделей та DbContext на основі
////бази даних в Entity Framework - Scaffold-методом,
////операція — Reverse Engineering.


//namespace wholesaleStore.Storage.Models;

//public partial class WholesaleStoreDbContext : DbContext
//{
//    public WholesaleStoreDbContext()
//    {
//    }

//    public WholesaleStoreDbContext(DbContextOptions<WholesaleStoreDbContext> options)
//        : base(options)
//    {
//    }

//    public virtual DbSet<Address> Addresses { get; set; }

//    public virtual DbSet<Administrator> Administrators { get; set; }

//    public virtual DbSet<CartItem> CartItems { get; set; }

//    public virtual DbSet<Enterprice> Enterprices { get; set; }

//    public virtual DbSet<FieldActivity> FieldActivitys { get; set; }

//    public virtual DbSet<Good> Goods { get; set; }

//    public virtual DbSet<Order> Orders { get; set; }

//    public virtual DbSet<User> Users { get; set; }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=WholeSaleStoreageBD;Connect Timeout=30;Encrypt=False;");

//    protected override void OnModelCreating(ModelBuilder modelBuilder)
//    {
//        modelBuilder.Entity<Administrator>(entity =>
//        {
//            entity.HasIndex(e => e.EnterpriceId, "IX_Administrators_EnterpriceId");

//            entity.HasOne(d => d.Enterprice).WithMany(p => p.Administrators).HasForeignKey(d => d.EnterpriceId);
//        });

//        modelBuilder.Entity<CartItem>(entity =>
//        {
//            entity.HasIndex(e => e.ProductId, "IX_CartItems_ProductId");

//            entity.HasIndex(e => e.UserId, "IX_CartItems_UserId");

//            entity.HasOne(d => d.Product).WithMany(p => p.CartItems).HasForeignKey(d => d.ProductId);

//            entity.HasOne(d => d.User).WithMany(p => p.CartItems).HasForeignKey(d => d.UserId);
//        });

//        modelBuilder.Entity<Enterprice>(entity =>
//        {
//            entity.HasIndex(e => e.AddressesId, "IX_Enterprices_AddressesId");

//            entity.HasIndex(e => e.FieldActivityId, "IX_Enterprices_FieldActivityId");

//            entity.HasOne(d => d.Addresses).WithMany(p => p.Enterprices).HasForeignKey(d => d.AddressesId);

//            entity.HasOne(d => d.FieldActivity).WithMany(p => p.Enterprices).HasForeignKey(d => d.FieldActivityId);
//        });

//        modelBuilder.Entity<Good>(entity =>
//        {
//            entity.HasIndex(e => e.EnterpriceId, "IX_Goods_EnterpriceId");

//            entity.HasOne(d => d.Enterprice).WithMany(p => p.Goods).HasForeignKey(d => d.EnterpriceId);

//            entity.HasMany(d => d.Orders).WithMany(p => p.Goods)
//                .UsingEntity<Dictionary<string, object>>(
//                    "GoodsOrder",
//                    r => r.HasOne<Order>().WithMany().HasForeignKey("OrdersId"),
//                    l => l.HasOne<Good>().WithMany().HasForeignKey("GoodsId"),
//                    j =>
//                    {
//                        j.HasKey("GoodsId", "OrdersId");
//                        j.ToTable("GoodsOrders");
//                        j.HasIndex(new[] { "OrdersId" }, "IX_GoodsOrders_OrdersId");
//                    });
//        });

//        modelBuilder.Entity<Order>(entity =>
//        {
//            entity.HasIndex(e => e.UserId, "IX_Orders_userId");

//            entity.Property(e => e.UserId).HasColumnName("userId");

//            entity.HasOne(d => d.User).WithMany(p => p.Orders).HasForeignKey(d => d.UserId);
//        });

//        OnModelCreatingPartial(modelBuilder);
//    }

//    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
//}
