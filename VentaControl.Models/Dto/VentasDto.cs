namespace VentaControl.Models.Dto;

public class VentasCrearDto {

    public DateTime Fecha {get;set;}
    public int ClienteId {get;set;}
    public decimal Total {get;set;}

}
public class VentasVerDto {

    public DateTime Fecha {get;set;}
    public string ClienteNombre {get;set;}
    public decimal Total {get;set;}

}