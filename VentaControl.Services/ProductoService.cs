using VentaControl.Services.interfaces;
using VentaControl.Models;
using VentaControl.Models.Dto;
using VentaControl.Repositories;
using VentaControl.Repositories.interfaces;

namespace VentaControl.Services;

public class ProductoService : IProductoService{
    private readonly IProductosRepositories _repository;

    public ProductoService(IProductosRepositories repository){
        _repository = repository;
    }
    public async Task<List<Producto>> ObtenerTodos(){
        
        return await _repository.ObtenerTodos();
    }
    public async Task<Producto> ObtenerPorId(int Id){
        
        return await _repository.ObtenerPorId(Id);
    }

    public async Task Crear(ProductoDto ProductoDto){
        if (ProductoDto.Precio < 0){
            throw new Exception("El precio debe ser mayor que 0");
        };
        var producto = new Producto{
            Nombre = ProductoDto.Nombre,
            Descripcion = ProductoDto.Descripcion,
            Precio = ProductoDto.Precio,
            Stock = ProductoDto.Stock,
            ImagenUrl = ProductoDto.ImagenUrl

        };
        await _repository.Crear(producto);
    }
    public async Task Actualizar(int Id,ProductoDto productoDto){

        var producto = await _repository.ObtenerPorId(Id);
        if (producto == null){
            throw new Exception("Producto no encontrado.");
        };

        producto.Nombre = productoDto.Nombre;
        producto.Descripcion = productoDto.Descripcion;
        producto.Precio = productoDto.Precio;
        producto.Stock = productoDto.Stock;
        producto.ImagenUrl = productoDto.ImagenUrl;


        await _repository.Actualizar(Id,producto);
    }
    public async Task Eliminar(int Id){
        var producto = await _repository.ObtenerPorId(Id);
        
        if (producto == null){
            throw new Exception("El producto no existe.");
        };
        await _repository.Eliminar(Id);
    }
}