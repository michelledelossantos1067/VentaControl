using VentaControl.Models;

namespace VentaControl.Repositories.interfaces;

public interface IDetalleVentaRepositories{
    Task <List<DetalleVenta>> ObtenerTodos();
    Task <DetalleVenta> ObtenerPorId(int Id);
    Task Crear(DetalleVenta detalleVenta);
    Task Actualizar(int Id, DetalleVenta detalleVenta);
    Task Eliminar(int Id);
}