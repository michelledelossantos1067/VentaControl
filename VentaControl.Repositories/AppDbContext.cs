using Microsoft.EntityFrameworkCore;
using VentaControl.Models;
namespace VentaControl.Repositories;


public class AppDbContext: DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
    : base(options){ }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    modelBuilder.Entity<DetalleVenta>()
        .HasOne(d => d.Venta)
            .WithMany(v => v.DetallesVenta)
            .HasForeignKey(d => d.VentaId)
            .OnDelete(DeleteBehavior.NoAction);

    modelBuilder.Entity<DetalleVenta>()
        .HasOne(d => d.Producto)
        .WithMany()
        .HasForeignKey(d => d.ProductoId)
        .OnDelete(DeleteBehavior.NoAction);
        
    modelBuilder.Entity<Producto>()
            .Property(p => p.Precio)
            .HasPrecision(18, 2);
        modelBuilder.Entity<DetalleVenta>()
            .Property(d => d.Precio)
            .HasPrecision(18, 2);
        modelBuilder.Entity<Venta>()
            .Property(v => v.Total)
            .HasPrecision(18, 2);
            modelBuilder.Entity<Usuario>()
            .Property(v => v.Email)
            .HasPrecision(18, 2);
}

    public DbSet<Producto> Productos {get;set;}
    public DbSet<Usuario> Usuarios {get;set;}
    public DbSet<Cliente>  Clientes {get;set;}
    public DbSet<Venta> Ventas {get;set;}
    public DbSet<DetalleVenta> DetalleVentas {get;set;}
}
