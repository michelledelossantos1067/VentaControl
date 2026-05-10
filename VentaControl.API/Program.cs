using VentaControl.Repositories.interfaces;
using VentaControl.Repositories;
using Microsoft.EntityFrameworkCore;
using VentaControl.Services;
using VentaControl.Services.interfaces; 

using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<LoginServices>();

builder.Services.AddScoped<IProductoService, ProductoService>();
builder.Services.AddScoped<IProductosRepositories, ProductoRepositories>();

builder.Services.AddScoped<IClienteService, ClienteService>();
builder.Services.AddScoped<IClientesRepositories, ClienteRepositories>();

builder.Services.AddScoped<IDetalleVentaService, DetalleVentaService>();
builder.Services.AddScoped<IDetalleVentaRepositories, DetalleVentaRepositories>();

builder.Services.AddScoped<IVentaService, VentaService>();
builder.Services.AddScoped<IVentaRepositories, VentaRepositories>();

builder.Services.AddScoped<IUsuarioService, UsuarioService>();
builder.Services.AddScoped<IUsuarioRepositories, UsuarioRepositories>();


var app = builder.Build();

app.UseHttpsRedirection();

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
{
    var forecast = Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
})
.WithName("GetWeatherForecast");
app.MapControllers();

app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
