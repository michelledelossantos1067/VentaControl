using VentaControl.Models;
using VentaControl.Models.Dto;

namespace VentaControl.Services.interfaces;

public interface IDetalleVentaService {
    Task<List<DetalleVenta>> ObtenerTodos();
    Task<DetalleVenta> ObtenerPorId(int Id);
    Task Crear(DetalleVentaCrearDto detalleVentaCrearDto);
    Task Actualizar(int Id, DetalleVentaCrearDto detalleVentaCrearDto);
    Task Eliminar(int Id);
}
