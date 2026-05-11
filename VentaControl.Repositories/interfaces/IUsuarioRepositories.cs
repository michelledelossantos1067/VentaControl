using VentaControl.Models;

namespace VentaControl.Repositories.interfaces;

public interface IUsuarioRepositories{
    Task Crear(Usuario usuario);
}