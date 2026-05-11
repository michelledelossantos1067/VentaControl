using Microsoft.EntityFrameworkCore;
using VentaControl.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
namespace VentaControl.Services;

public class JwtService{
    private readonly IConfiguration _config;

    public JwtService(IConfiguration config) => _config = config;

    public string GenerateToken(string email,string rol){
        var claims = new[]{
            new Claim(ClaimTypes.Email, email),
            new Claim(ClaimTypes.Role, rol)
        };
        var key= new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]!));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
    issuer: _config["Jwt:Issuer"],
    audience: _config["Jwt:Audience"],
    expires: DateTime.UtcNow.AddMinutes(60),
    claims: claims,
    signingCredentials: creds
);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }

}