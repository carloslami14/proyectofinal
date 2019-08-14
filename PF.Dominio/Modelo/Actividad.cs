using System;
using System.Collections.Generic;

namespace PF.Dominio.Modelo
{
    public class Actividad
    {
        public int ActividadId { get; set; }
        public string Nombre { get; set; }
        public double Avance { get; set; }
        public double Costo { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public ICollection<Item> Items { get; set; }
    }
}