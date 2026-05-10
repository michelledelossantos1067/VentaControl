using VentaControl.Models;
using VentaControl.Models.Dto;

namespace VentaControl.Services.interfaces;

public interface IVentaService{
    Task<List<Venta>> ObtenerTodos();
    Task<Venta> ObtenerPorId(int Id);
    Task<int> Crear(VentasCrearDto ventasCrearDto);
    Task Actualizar(int Id, VentasCrearDto ventasCrearDto);
    Task Eliminar(int Id);
}