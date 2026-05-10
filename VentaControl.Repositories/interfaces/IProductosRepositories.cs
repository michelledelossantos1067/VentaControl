using VentaControl.Models;

namespace VentaControl.Repositories.interfaces;

public interface IProductosRepositories{
    Task<List<Producto>> ObtenerTodos();
    Task<Producto> ObtenerPorId(int Id);
    Task Crear(Producto producto);
    Task Actualizar(int Id, Producto producto);
    Task Eliminar(int Id);
}