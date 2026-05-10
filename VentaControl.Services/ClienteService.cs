using VentaControl.Services.interfaces;
using VentaControl.Models;
using VentaControl.Models.Dto;
using VentaControl.Repositories;
using VentaControl.Repositories.interfaces;

namespace VentaControl.Services;

public class ClienteService : IClienteService{
    private readonly IClientesRepositories _repository;

    public ClienteService (IClientesRepositories repository){
        _repository = repository;
    }

    public async Task<List<Cliente>> ObtenerTodos(){
        return await _repository.ObtenerTodos();
    }

    public async Task<Cliente> ObtenerPorId(int Id){
        return await _repository.ObtenerPorId(Id);
    }
    public async Task<Cliente> ObtenerPorEmail(string email){
    return await _repository.ObtenerPorEmail(email);
}

    public async Task Crear(ClienteCrearDto clienteCrearDto){
        var cliente = new Cliente{
            Nombre = clienteCrearDto.Nombre,
            Email = clienteCrearDto.Email,
            Telefono = clienteCrearDto.Telefono,
        };
        await _repository.Crear(cliente);
    }
    public async Task Actualizar(int Id,ClienteCrearDto clienteCrearDto){
        var cliente = await _repository.ObtenerPorId(Id);
        if (cliente == null){
            throw new Exception("El usuario no existe.");
        }
        cliente.Nombre = clienteCrearDto.Nombre;
        cliente.Email = clienteCrearDto.Email;
        cliente.Telefono = clienteCrearDto.Telefono;

        await _repository.Actualizar(Id,cliente);
    }
    public async Task Eliminar(int Id){
        var cliente = await _repository.ObtenerPorId(Id);
        if (cliente == null){
            throw new Exception("El usuario no existe.");
        };
        await _repository.Eliminar(Id);
    }
}