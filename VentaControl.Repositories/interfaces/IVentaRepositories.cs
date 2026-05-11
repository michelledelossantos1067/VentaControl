using VentaControl.Models;
using VentaControl.Models.Dto;

namespace VentaControl.Repositories.interfaces;

public interface IVentaRepositories{
    Task<List<Venta>> ObtenerTodos();
    Task<Venta> ObtenerPorId(int Id);
    Task Crear(Venta venta);
    Task Actualizar(int Id, Venta venta);
    Task Eliminar(int Id);
    Task<List<VentasVerDto>> ObtenerTodosConCliente();

}