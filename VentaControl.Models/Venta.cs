namespace VentaControl.Models;

public class Venta {
    public int Id {get;set;}
    public DateTime Fecha {get;set;}
    public decimal Total {get;set;}

    public int ClienteId {get;set;}
    public Cliente? Cliente {get;set;}
    public List<DetalleVenta> DetallesVenta {get;set;} = new();

}