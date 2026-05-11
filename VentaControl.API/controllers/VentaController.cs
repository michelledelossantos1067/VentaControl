using VentaControl.Services.interfaces;
using VentaControl.Models.Dto;
using VentaControl.Models;
using VentaControl.Services;
using Microsoft.AspNetCore.Mvc;
using VentaControl.Repositories.interfaces;
using Microsoft.AspNetCore.Authorization;
namespace VentaControl.Api.Controllers;
[ApiController]
[Route("api/[controller]")]
[Authorize]
public class VentaController : ControllerBase{
    private readonly IVentaService _services;

    public VentaController(IVentaService services){
        _services = services;
    }
    [HttpGet]
    public async Task<IActionResult> ObtenerTodos(){
        var venta = await _services.ObtenerTodos();
        return Ok(venta);
    }
    [HttpGet("{Id}")]
    public async Task<IActionResult> ObtenerPorId(int Id){
        var venta = await _services.ObtenerPorId(Id);
        if (venta == null){
            return NotFound();
        }
        return Ok(venta);
    }
    [HttpPost]
    public async Task<IActionResult> Crear([FromBody] VentasCrearDto ventaDto){
        var id = await _services.Crear(ventaDto);
        return Created("", new { id });
    }
    [HttpPut("{Id}")]
    public async Task<IActionResult> Actualizar([FromRoute] int Id, [FromBody]VentasCrearDto ventaDto){
        await _services.Actualizar(Id,ventaDto);
        return NoContent();
    }
    [HttpDelete("{Id}")]
    public async Task<IActionResult> Eliminar(int Id){
        await _services.Eliminar(Id);
        return NoContent();
    }
    [HttpGet("conCliente")]
    public async Task<IActionResult> ObtenerTodosConCliente(){
        var ventas = await _services.ObtenerTodosConCliente();
        return Ok(ventas);
    }
}