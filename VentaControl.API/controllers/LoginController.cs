
using Microsoft.AspNetCore.Mvc;
using VentaControl.Models;
using VentaControl.Models.Dto;
using VentaControl.Services;
using VentaControl.Services.interfaces;
[ApiController]
[Route("api/[controller]")]
public class LoginController:  ControllerBase{
    private readonly LoginServices _loginService;
    private readonly IUsuarioService _usuarioService;
    private readonly IClienteService _clienteService;

    public LoginController(LoginServices loginService, IUsuarioService usuarioService, IClienteService clienteService){
        _loginService = loginService;
        _clienteService = clienteService;
        _usuarioService = usuarioService;
    }
    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequest request){
        var result = await _loginService.LoginAsync(request.Email,request.Password);
        if (result == null){
            return Unauthorized("Credenciales incorrectas");
        }
        return Ok(result);
    }
    [HttpPost("registro")]
    public async Task<IActionResult> Registro([FromBody] RegistroDto dto)
    {
        await _usuarioService.Crear(new UsuarioDto { Email = dto.Email, Password = dto.Password, Rol = "cliente" });
        await _clienteService.Crear(new ClienteCrearDto { Nombre = dto.Nombre, Email = dto.Email, Telefono = dto.Telefono });
        return Created("", null);
    }
}