using VentaControl.Models;

namespace VentaControl.Repositories.interfaces;

public interface IClientesRepositories{
    Task<List<Cliente>> ObtenerTodos();
    Task<Cliente> ObtenerPorId(int Id);
    Task<Cliente> ObtenerPorEmail(string email);
    Task Crear(Cliente cliente);
    Task Actualizar(int Id,Cliente cliente);
    Task Eliminar(int Id);

}