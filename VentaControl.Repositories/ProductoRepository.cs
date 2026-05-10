using VentaControl.Repositories.interfaces;
using VentaControl.Models;
using Microsoft.EntityFrameworkCore;


namespace VentaControl.Repositories;

public class ProductoRepositories: IProductosRepositories{
    private readonly AppDbContext _context;

    public ProductoRepositories(AppDbContext context){
        _context = context;
    }
    public async Task<List<Producto>> ObtenerTodos(){
        return await _context.Productos.ToListAsync();
    }
    public async Task<Producto> ObtenerPorId(int Id){
        return await _context.Productos.FindAsync(Id);
    }
    public async Task Crear(Producto producto){
        await _context.Productos.AddAsync(producto);
        await _context.SaveChangesAsync();
    }
    public async Task Actualizar(int Id,Producto producto){
        _context.Productos.Update(producto);
        await _context.SaveChangesAsync();
    }
    public async Task Eliminar(int Id){
        var producto = await _context.Productos.FindAsync(Id);
        _context.Productos.Remove(producto);
        await _context.SaveChangesAsync();
    }
    
}