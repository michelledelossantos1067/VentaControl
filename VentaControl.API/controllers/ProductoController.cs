using VentaControl.Services.interfaces;
using VentaControl.Models.Dto;
using VentaControl.Models;
using VentaControl.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
namespace VentaControl.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class ProductoController : ControllerBase{
    private readonly IProductoService _service;

    public ProductoController(IProductoService services){
        _service = services;
    }
    [HttpGet]
    public async Task<IActionResult> ObtenerTodos(){
        var productos = await _service.ObtenerTodos();
        return Ok(productos);
    }
    [HttpGet("{Id}")]
    public async Task<IActionResult> ObtenerPorId(int Id){
        var productos = await _service.ObtenerPorId(Id);
        if (productos == null){
            return NotFound();
        };
        return Ok(productos);
    }

    [HttpPost]
    public async Task<IActionResult> Crear([FromBody] ProductoDto productoDto){
        await _service.Crear(productoDto);
        return Created("",null);
    }

    [HttpPut("{Id}")]
    public async Task<IActionResult> Actualizar(int Id,[FromBody] ProductoDto productoDto){
        await _service.Actualizar(Id, productoDto);
        return NoContent();
    }

    [HttpDelete]
    public async Task<IActionResult> Eliminar(int Id){
        await _service.Eliminar(Id);
        return NoContent();
    }
}