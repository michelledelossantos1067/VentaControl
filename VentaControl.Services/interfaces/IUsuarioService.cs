using VentaControl.Models;
using VentaControl.Models.Dto;

namespace VentaControl.Services.interfaces;

public interface IUsuarioService{
    Task Crear(UsuarioDto usuarioDto);
    Task<List<UsuarioDto>> ObtenerTodos();
    Task<UsuarioDto> ObtenerPorId(int Id);
    Task Actualizar (int Id,UsuarioDto usuarioDto);
    Task Eliminar(int Id);

}