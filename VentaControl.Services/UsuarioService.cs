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
    public async Task<List<UsuarioDto>> ObtenerTodos(){
        var usuarios = await _repository.ObtenerTodos();
        return usuarios.Select(u => new UsuarioDto {
            Id = u.Id,
            Email = u.Email,
            Rol = u.Rol
        }).ToList();
    }

    public async Task<UsuarioDto> ObtenerPorId(int Id){
        var usuario = await _repository.ObtenerPorId(Id);
        if (usuario == null) return null;
        return new UsuarioDto {
            Id = usuario.Id,
            Email = usuario.Email,
            Rol = usuario.Rol
        };
    }
    public async Task Actualizar(int Id,UsuarioDto usuarioDto){
        var usuario = await _repository.ObtenerPorId(Id);
        if (usuario == null){
            throw new Exception("El usuario no existe.");
        }
        usuario.Email = usuarioDto.Email;
        usuario.Rol = usuarioDto.Rol;

        await _repository.Actualizar(Id,usuario);
    }
    public async Task Eliminar(int Id){
        var usuario = await _repository.ObtenerPorId(Id);
        if (usuario == null){
            throw new Exception("El usuario no existe.");
        };
        await _repository.Eliminar(Id);
    }
}