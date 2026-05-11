using VentaControl.Models;
using VentaControl.Models.Dto;

namespace VentaControl.Services.interfaces;

public interface IClienteService{
    Task<List<Cliente>> ObtenerTodos();
    Task<Cliente> ObtenerPorId(int Id);
    Task<Cliente> ObtenerPorEmail(string email);
    Task Crear(ClienteCrearDto clienteCrearDto);
    Task Actualizar (int Id,ClienteCrearDto clienteCrearDto);
    Task Eliminar(int Id);
}