using VentaControl.Repositories.interfaces;
using VentaControl.Models;
using Microsoft.EntityFrameworkCore;
using VentaControl.Models.Dto;

namespace VentaControl.Repositories;

public class DetalleVentaRepositories : IDetalleVentaRepositories{
    private readonly AppDbContext _context;

    public DetalleVentaRepositories(AppDbContext context){
        _context = context;
    }

    public async Task<List<DetalleVenta>> ObtenerTodos(){
        return await _context.DetalleVentas.ToListAsync();
    }
    public async Task<DetalleVenta> ObtenerPorId(int Id){
        return await _context.DetalleVentas.FindAsync();
    }
    public async Task<List<DetalleVentaVerDto>> ObtenerTodosConDetalle(){
        return await _context.DetalleVentas
            .Include(d => d.Producto)
            .Include(d => d.Venta)
                .ThenInclude(v => v.Cliente)
            .Select(d => new DetalleVentaVerDto {
                ProductoNombre = d.Producto.Nombre,
                ClienteNombre = d.Venta.Cliente.Nombre,
                Cantidad = d.Cantidad,
                Precio = d.Precio
            })
            .ToListAsync();
    }

    public async Task Crear(DetalleVenta detalleVenta){
        _context.DetalleVentas.AddAsync(detalleVenta);
        await _context.SaveChangesAsync();
    }

    public async Task Actualizar(int Id,DetalleVenta detalleVenta){
        _context.DetalleVentas.Update(detalleVenta);
        await _context.SaveChangesAsync();
    }

    public async Task Eliminar(int Id){
        var detalle = await _context.DetalleVentas.FindAsync(Id);
        _context.DetalleVentas.Remove(detalle);
        await _context.SaveChangesAsync();
    }
}