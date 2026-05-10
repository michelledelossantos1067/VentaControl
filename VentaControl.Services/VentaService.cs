using VentaControl.Services.interfaces;
using VentaControl.Models;
using VentaControl.Models.Dto;
using VentaControl.Repositories;
using VentaControl.Repositories.interfaces;


namespace VentaControl.Services;

public class VentaService: IVentaService{
    private readonly IVentaRepositories _repository;
    
    public VentaService(IVentaRepositories repository){
        _repository = repository;
    }
    public async Task<List<Venta>> ObtenerTodos(){
        return await _repository.ObtenerTodos();
    }
    
    public async Task<Venta> ObtenerPorId(int Id){
        return await _repository.ObtenerPorId(Id);
    }
    public async Task<int> Crear(VentasCrearDto ventasCrearDto){
        var venta = new Venta{

            Fecha = ventasCrearDto.Fecha,
            Total = ventasCrearDto.Total,
            ClienteId = ventasCrearDto.ClienteId,
        };
        await _repository.Crear(venta);
        return venta.Id;
    }
    public async Task Actualizar(int Id, VentasCrearDto ventasCrearDto){
        var venta = await _repository.ObtenerPorId(Id);
        if(venta == null){
            throw new Exception("No existe este registro.");
        };
        venta.Fecha = ventasCrearDto.Fecha;
        venta.Total = ventasCrearDto.Total;
        venta.ClienteId = ventasCrearDto.ClienteId;

        await _repository.Actualizar(Id,venta);
    }
    public async Task Eliminar(int Id){
        var venta = await _repository.ObtenerPorId(Id);
        if (venta == null){
            throw new Exception("No existe este registro.");
        };
        await _repository.Eliminar(Id);
    }
}