using System;
using System.Collections.Generic;

namespace PF.Dominio.Modelo
{
    public class Pedido
    {
        public Pedido()
        {
            Items = new HashSet<Item>();
        }
        public int PedidoId { get; set; }
        public DateTime FechaPedido { get; set; }
        public double Total { get; set; }
        public virtual ICollection<Item> Items { get; set; }
    }
}