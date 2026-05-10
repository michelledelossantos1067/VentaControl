using VentaControl.Repositories.interfaces;
using VentaControl.Models;
using Microsoft.EntityFrameworkCore;
namespace VentaControl.Repositories;

public class ClienteRepositories: IClientesRepositories {
    private readonly AppDbContext _context;
    
    public ClienteRepositories(AppDbContext context){
        _context = context;
    }

    public async Task<List<Cliente>> ObtenerTodos(){
        return await _context.Clientes.ToListAsync();
    }
    public async Task<Cliente> ObtenerPorId(int Id){
        return await _context.Clientes.FindAsync(Id);
    }
    public async Task<Cliente> ObtenerPorEmail(string Email){
    return await _context.Clientes
        .FirstOrDefaultAsync(c => c.Email == Email);
        }
    public async Task Actualizar(int Id,Cliente cliente){
        _context.Clientes.Update(cliente);
        await _context.SaveChangesAsync();
    }
    public async Task Crear(Cliente cliente){
        _context.Clientes.AddAsync(cliente);
        await _context.SaveChangesAsync();
    }
    public async Task Eliminar(int Id){
        var producto = await _context.Clientes.FindAsync(Id);
        _context.Clientes.Remove(producto);
        await _context.SaveChangesAsync();
    }

}