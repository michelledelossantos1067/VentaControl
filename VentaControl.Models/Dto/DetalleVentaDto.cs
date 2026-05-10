namespace VentaControl.Models.Dto;

public class DetalleVentaCrearDto{

    public int VentaId {get;set;}
    public int ProductoId {get;set;}
    public int Cantidad {get;set;}
    public decimal Precio {get;set;}
}

public class DetalleVentaVerDto{

    public string ProductoNombre {get;set;}
    public string ClienteNombre {get;set;}
    public int Cantidad {get;set;}
    public decimal Precio {get;set;}
    public decimal Total => Cantidad * Precio;

}