using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace CoffeeShop.Models;

public partial class Up03Context : DbContext
{
    public Up03Context()
    {
    }
    public Up03Context(DbContextOptions<Up03Context> options)
        : base(options)
    {
    }
    public virtual DbSet<Client> Clients { get; set; }
    public virtual DbSet<Good> Goods { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseMySQL("Server=127.0.0.1;User=root;Database=up03");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Client>(entity =>
        {
            entity.HasKey(e => e.ClientId).HasName("PRIMARY");

            entity.ToTable("Client");

            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.Surname).HasMaxLength(100);
        });

        modelBuilder.Entity<Good>(entity =>
        {
            entity.HasKey(e => e.GoodsId).HasName("PRIMARY");

            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.Price).HasMaxLength(100);
        });

        OnModelCreatingPartial(modelBuilder);
    }
    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
