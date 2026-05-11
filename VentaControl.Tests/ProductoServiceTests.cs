using Moq;
using FluentAssertions;
using VentaControl.Services;
using VentaControl.Repositories.interfaces;
using VentaControl.Models;
using VentaControl.Models.Dto;

namespace VentaControl.Tests;

public class ProductoServiceTests
{
    private readonly Mock<IProductosRepositories> _repositoryMock;
    private readonly ProductoService _service;

    public ProductoServiceTests()
    {
        _repositoryMock = new Mock<IProductosRepositories>();
        _service = new ProductoService(_repositoryMock.Object);
    }

    [Fact]
    public async Task ObtenerTodos_DebeRetornarListaDeProductos()
    {
        // Arrange
        var productosEsperados = new List<Producto>
        {
            new Producto { Id = 1, Nombre = "Laptop", Precio = 45000, Stock = 10 },
            new Producto { Id = 2, Nombre = "Mouse", Precio = 1200, Stock = 35 }
        };
        _repositoryMock.Setup(r => r.ObtenerTodos()).ReturnsAsync(productosEsperados);

        // Act
        var resultado = await _service.ObtenerTodos();

        // Assert
        resultado.Should().HaveCount(2);
        resultado.Should().BeEquivalentTo(productosEsperados);
    }

    [Fact]
    public async Task Crear_ConPrecioNegativo_DebeLanzarExcepcion()
    {
        // Arrange
        var dto = new ProductoDto { Nombre = "Test", Precio = -100, Stock = 5 };

        // Act
        var accion = async () => await _service.Crear(dto);

        // Assert
        await accion.Should().ThrowAsync<Exception>()
            .WithMessage("El precio debe ser mayor que 0");
    }
}