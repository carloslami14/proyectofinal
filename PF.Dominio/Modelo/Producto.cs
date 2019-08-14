namespace PF.Dominio.Modelo
{
    public class Producto
    {
        public int ProductoId { get; set; }
        public string Nombre { get; set; }
        public double Precio { get; set; }
        public int ProveedorId { get; set; }
        public virtual Proveedor Proveedor { get; set; }
        public int RubroId { get; set; }
        public virtual Rubro Rubro { get; set; }
    }
}