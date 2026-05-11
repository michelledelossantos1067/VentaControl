using VentaControl.Models;
using VentaControl.Repositories.interfaces;
using Microsoft.EntityFrameworkCore;

namespace VentaControl.Repositories.interfaces;

public class UsuarioRepositories : IUsuarioRepositories {
    private readonly AppDbContext _context;
    
    public UsuarioRepositories(AppDbContext context){
        _context = context;
    }

    public async Task Crear(Usuario usuario){
        _context.Usuarios.AddAsync(usuario);
        await _context.SaveChangesAsync();
    }

    public async Task<List<Usuario>> ObtenerTodos(){
        return await _context.Usuarios.ToListAsync();
    }

    public async Task<Usuario> ObtenerPorId(int Id){
        return await _context.Usuarios.FindAsync(Id);
    }
    public async Task Actualizar(int Id,Usuario usuario){
        _context.Usuarios.Update(usuario);
        await _context.SaveChangesAsync();
    }
    public async Task Eliminar(int Id){
        var usuario = await _context.Usuarios.FindAsync(Id);
        _context.Usuarios.Remove(usuario);
        await _context.SaveChangesAsync();
    }
}