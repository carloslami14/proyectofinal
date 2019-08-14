using System;
using System.Collections.Generic;

namespace PF.Dominio.Modelo
{
    public class Item
    {
        public Item()
        {
            Productos = new HashSet<Producto>();
        }
        public int ItemId { get; set; }
        public string Nombre { get; set; }
        public double Precio { get; set; }
        public virtual ICollection<Producto> Productos { get; set; }
    }
}