using VentaControl.Models;

namespace VentaControl.Repositories.interfaces;

public interface IUsuarioRepositories{
    Task Crear(Usuario usuario);
    Task<List<Usuario>> ObtenerTodos();
    Task<Usuario> ObtenerPorId(int Id);
    Task Actualizar(int Id,Usuario usuario);
    Task Eliminar(int Id);
}