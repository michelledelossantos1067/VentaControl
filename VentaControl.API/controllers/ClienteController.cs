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
public class ClienteController : ControllerBase{
    private readonly IClienteService _services;
    
    public ClienteController(IClienteService services){
        _services = services;
    }

    [HttpGet]
    public async Task<IActionResult> ObtenerTodos(){
        var cliente = await _services.ObtenerTodos();
        return Ok(cliente);

    }
    [HttpGet("{Id}")]
    public async Task<IActionResult> ObtenerPorId(int Id){
        var cliente = await _services.ObtenerPorId(Id);
        if (cliente == null){
            return NotFound();
        }
        return Ok(cliente);
    }
    [HttpGet("porEmail/{email}")]
public async Task<IActionResult> ObtenerPorEmail(string email)
{
    var cliente = await _services.ObtenerPorEmail(email);
    if (cliente == null)
        return NotFound();
    return Ok(cliente);
}
    [HttpPost]
    public async Task<IActionResult> Crear([FromBody]ClienteCrearDto clienteDto){
        await _services.Crear(clienteDto);
        return Created("",null);

    }
    [HttpPut("{Id}")]
    public async Task<IActionResult> Actualizar([FromRoute] int Id, [FromBody] ClienteCrearDto clienteDto){
        await _services.Actualizar(Id,clienteDto);
        return NoContent();

    }
    [HttpDelete]
    public async Task<IActionResult> Eliminar(int Id){
        await _services.Eliminar(Id);
        return NoContent();
    }
}