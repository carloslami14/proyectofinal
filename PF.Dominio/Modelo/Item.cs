using System;

namespace PF.Dominio.Modelo
{
    public class Item
    {
        public int ItemId { get; set; }
        public string Nombre { get; set; }
        public double Precio { get; set; }
        public int ProveedorId { get; set; }
        public virtual Proveedor Proveedor { get; set; }
        public int RubroId { get; set; }
        public virtual Rubro Rubro { get; set; }
    }
}