using Moq;
using FluentAssertions;
using VentaControl.Services;
using VentaControl.Repositories.interfaces;
using VentaControl.Models;
using VentaControl.Models.Dto;

namespace VentaControl.Tests;

public class ClienteServiceTests
{
    private readonly Mock<IClientesRepositories> _repositoryMock;
    private readonly ClienteService _service;

    public ClienteServiceTests()
    {
        _repositoryMock = new Mock<IClientesRepositories>();
        _service = new ClienteService(_repositoryMock.Object);
    }

    [Fact]
    public async Task ObtenerTodos_DebeRetornarListaDeClientes()
    {
        // Arrange
        var clientesEsperados = new List<Cliente>
        {
            new Cliente { Id = 1, Nombre = "María", Email = "maria@gmail.com", Telefono = "809-000-0000" },
            new Cliente { Id = 2, Nombre = "Juan", Email = "juan@gmail.com", Telefono = "809-111-1111" }
        };
        _repositoryMock.Setup(r => r.ObtenerTodos()).ReturnsAsync(clientesEsperados);

        // Act
        var resultado = await _service.ObtenerTodos();

        // Assert
        resultado.Should().HaveCount(2);
        resultado.Should().BeEquivalentTo(clientesEsperados);
    }

    [Fact]
    public async Task Eliminar_ClienteNoExiste_DebeLanzarExcepcion()
    {
        // Arrange
        _repositoryMock.Setup(r => r.ObtenerPorId(99)).ReturnsAsync((Cliente)null);

        // Act
        var accion = async () => await _service.Eliminar(99);

        // Assert
        await accion.Should().ThrowAsync<Exception>()
            .WithMessage("El usuario no existe.");
    }
}