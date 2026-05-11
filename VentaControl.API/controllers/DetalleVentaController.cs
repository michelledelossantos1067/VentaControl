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
public class DetalleVentaController : ControllerBase{
    private readonly IDetalleVentaService _services;
    
    public DetalleVentaController(IDetalleVentaService services){
        _services = services;
    }

    [HttpGet]
    public async Task<IActionResult> ObtenerTodos(){
        var detalleventa = await _services.ObtenerTodos();
        return Ok(detalleventa);

    }
    [HttpGet("{Id}")]
    public async Task<IActionResult> ObtenerPorId(int Id){
        var detalleventa = await _services.ObtenerPorId(Id);
        if (detalleventa == null){
            return NotFound();
        };
        return Ok(detalleventa);
    }
    [HttpPost]
    public async Task<IActionResult> Crear([FromBody] DetalleVentaCrearDto detalleVentaDto){
        await _services.Crear(detalleVentaDto);
        return Created("",null);

    }
    [HttpPut("{Id}")]
    public async Task<IActionResult>  Actualizar([FromRoute] int Id, [FromBody] DetalleVentaCrearDto detalleVentaDto){
        await _services.Actualizar(Id,detalleVentaDto);
        return NoContent();

    }
    [HttpDelete("{Id}")]
    public async Task<IActionResult> Eliminar(int Id){
        await _services.Eliminar(Id);
        return NoContent();
    }
    [HttpGet("conDetalle")]
    public async Task<IActionResult> ObtenerTodosConDetalle(){
        var detalles = await _services.ObtenerTodosConDetalle();
        return Ok(detalles);
    }
}