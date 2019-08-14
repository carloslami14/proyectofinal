using System;
using System.Collections.Generic;

namespace PF.Dominio.Modelo
{
    public class Obra
    {
        public Obra()
        {
            Actividades = new HashSet<Actividad>();
        }
        public int ObraId { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaFin { get; set; }
        public double Costo { get; set; }
        public virtual ICollection<Actividad> Actividades { get; set; }
    }
}