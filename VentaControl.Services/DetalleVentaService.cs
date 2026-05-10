using VentaControl.Services.interfaces;
using VentaControl.Models;
using VentaControl.Models.Dto;
using VentaControl.Repositories;
using VentaControl.Repositories.interfaces;

namespace VentaControl.Services;

public class DetalleVentaService: IDetalleVentaService{
    private readonly IDetalleVentaRepositories _repository;

    public DetalleVentaService (IDetalleVentaRepositories repository){
        _repository = repository;
    }
    public async Task<List<DetalleVenta>> ObtenerTodos(){
        return await _repository.ObtenerTodos();
    }
    public async Task<DetalleVenta> ObtenerPorId(int Id){
        return await _repository.ObtenerPorId(Id);

    }
    public async Task Crear(DetalleVentaCrearDto detalleVentaCrearDto){
        
        var detalleventa = new DetalleVenta{
            Precio = detalleVentaCrearDto.Precio,
            VentaId= detalleVentaCrearDto.VentaId,
            ProductoId= detalleVentaCrearDto.ProductoId,
            Cantidad= detalleVentaCrearDto.Cantidad,
        };
        await _repository.Crear(detalleventa);
    }
    public async Task Actualizar(int Id,DetalleVentaCrearDto detalleVentaCrearDto){
        var detalle = await _repository.ObtenerPorId(Id);
        if (detalle == null){
            throw new Exception("El Detalle de Venta no existe.");
        };
        detalle.VentaId= detalleVentaCrearDto.VentaId;
        detalle.ProductoId= detalleVentaCrearDto.ProductoId;
        detalle.Cantidad= detalleVentaCrearDto.Cantidad;
        detalle.Precio = detalleVentaCrearDto.Precio;
        await _repository.Actualizar(Id,detalle);
    }
    public async Task Eliminar(int Id){
        var detalle = await _repository.ObtenerPorId(Id);
        if (detalle == null){
            throw new Exception("El detalle de venta no existe.");
        }
        await _repository.Eliminar(Id);
    }
}