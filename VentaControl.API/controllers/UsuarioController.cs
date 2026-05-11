using VentaControl.Services.interfaces;
using VentaControl.Models.Dto;
using VentaControl.Models;
using VentaControl.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace VentaControl.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsuarioController : ControllerBase{
    private readonly IUsuarioService _service;

    public UsuarioController(IUsuarioService services){
        _service = services;
    }
    [HttpPost]
    public async Task<IActionResult> Crear([FromBody] UsuarioDto usuarioDto){
        await _service.Crear(usuarioDto);
        return Created("",null);
    }
    
    [HttpGet]
    public async Task<IActionResult> ObtenerTodos(){
        var usuario = await _service.ObtenerTodos();
        return Ok(usuario);

    }
    [HttpGet("{Id}")]
    public async Task<IActionResult> ObtenerPorId(int Id){
        var usuario = await _service.ObtenerPorId(Id);
        if (usuario == null){
            return NotFound();
        }
        return Ok(usuario);
    }
    [HttpPut("{Id}")]
    public async Task<IActionResult> Actualizar([FromRoute] int Id, [FromBody] UsuarioDto usuarioDto){
        await _service.Actualizar(Id,usuarioDto);
        return NoContent();
    }
    
    [HttpDelete("{Id}")]
    public async Task<IActionResult> Eliminar(int Id){
        await _service.Eliminar(Id);
        return NoContent();
    }
}