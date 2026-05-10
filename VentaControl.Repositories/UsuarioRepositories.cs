using VentaControl.Models;

namespace VentaControl.Repositories.interfaces;

public class UsuarioRepositories: IUsuarioRepositories {
    private readonly AppDbContext _context;
    
    public UsuarioRepositories(AppDbContext context){
        _context = context;
    }
    public async Task Crear(Usuario usuario){
        _context.Usuarios.AddAsync(usuario);
        await _context.SaveChangesAsync();
    }
}