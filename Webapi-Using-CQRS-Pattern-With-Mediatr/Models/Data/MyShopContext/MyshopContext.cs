using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Webapi_Using_CQRS_Pattern_With_Mediatr.Models.Data.MyShopContext;

public partial class MyshopContext : DbContext
{
    public MyshopContext()
    {
    }

    public MyshopContext(DbContextOptions<MyshopContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Product> Products { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>(entity =>
        {
            entity.ToTable("Product");

            entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.ProductDescription)
                .IsRequired()
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.ProductName)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
