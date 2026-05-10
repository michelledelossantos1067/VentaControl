using VentaControl.Models;
using VentaControl.Models.Dto;
namespace VentaControl.Services.interfaces;

public interface IProductoService
{
    Task<List<Producto>> ObtenerTodos();
    Task<Producto> ObtenerPorId(int Id);
    Task Crear(ProductoDto productoDto);
    Task Actualizar(int Id, ProductoDto productoDto);
    Task Eliminar(int Id);

}
