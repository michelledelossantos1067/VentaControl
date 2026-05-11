namespace VentaControl.Models.Dto;

public class UsuarioDto {
    public int Id {get;set;}
    public string Email {get;set;}
    public string Password {get;set;}
    public string Rol {get;set;} = "cliente";

}
