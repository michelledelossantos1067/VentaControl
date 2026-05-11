using VentaControl.Repositories.interfaces;
using VentaControl.Models;
using VentaControl.Models.Dto;
using Microsoft.EntityFrameworkCore;

namespace VentaControl.Repositories;

public class VentaRepositories: IVentaRepositories {
    private readonly AppDbContext _context;
    
    public VentaRepositories(AppDbContext context){
        _context = context;
    }

    public async Task<List<Venta>> ObtenerTodos(){
        return await _context.Ventas.ToListAsync();
    }
    public async Task<List<VentasVerDto>> ObtenerTodosConCliente(){
        return await _context.Ventas
            .Include(v => v.Cliente)
            .Select(v => new VentasVerDto {
                Fecha = v.Fecha,
                ClienteNombre = v.Cliente.Nombre,
                Total = v.Total
            })
            .ToListAsync();
    }
    public async Task<Venta> ObtenerPorId(int Id){
        return await _context.Ventas.FindAsync(Id);
    }
    public async Task Crear(Venta venta){
        _context.Ventas.AddAsync(venta);
        await _context.SaveChangesAsync();
    }
    public async Task Actualizar(int Id,Venta venta){
        _context.Ventas.Update(venta);
        await _context.SaveChangesAsync();
    }
    public async Task Eliminar(int Id){
        var venta = await _context.Ventas.FindAsync(Id);
        _context.Ventas.Remove(venta);
        await _context.SaveChangesAsync();
    }
    
}