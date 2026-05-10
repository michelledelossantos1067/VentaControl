using VentaControl.Models;
using VentaControl.Models.Dto;

namespace VentaControl.Services.interfaces;

public interface IUsuarioService{
    Task Crear(UsuarioDto usuarioDto);

}