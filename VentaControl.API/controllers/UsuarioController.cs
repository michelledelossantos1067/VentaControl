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
}