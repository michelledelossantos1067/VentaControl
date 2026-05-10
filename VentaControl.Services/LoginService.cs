using VentaControl.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.EntityFrameworkCore;


namespace VentaControl.Services;

public class LoginServices{
    private readonly JwtService _jwtService;
    private readonly AppDbContext _db;

    public LoginServices(JwtService jwtService, AppDbContext db){
        _db = db;
        _jwtService = jwtService;
    }
    public async Task<object?> LoginAsync(string email, string password){
        var usuario = await _db.Usuarios.FirstOrDefaultAsync(u=>u.Email == email);
        if (usuario== null || !BCrypt.Net.BCrypt.Verify(password, usuario.PasswordHash)){
            return null;
        };
        var token = _jwtService.GenerateToken(usuario.Email,usuario.Rol);
        return new {token, rol = usuario.Rol };
    }
}