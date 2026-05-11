using VentaControl.Services.interfaces;
using VentaControl.Models;
using VentaControl.Models.Dto;
using VentaControl.Repositories;
using VentaControl.Repositories.interfaces;

namespace VentaControl.Services;

public class UsuarioService : IUsuarioService{
    private readonly IUsuarioRepositories _repository;

    public UsuarioService(IUsuarioRepositories repository){
        _repository = repository;
    }
     public async Task Crear(UsuarioDto usuarioDto){
        var usuario = new Usuario{
            Email = usuarioDto.Email,
            PasswordHash = BCrypt.Net.BCrypt.HashPassword(usuarioDto.Password),
            Rol = usuarioDto.Rol,
        };
        await _repository.Crear(usuario);
    }
}