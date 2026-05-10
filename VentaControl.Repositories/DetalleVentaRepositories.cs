using VentaControl.Repositories.interfaces;
using VentaControl.Models;
using Microsoft.EntityFrameworkCore;

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