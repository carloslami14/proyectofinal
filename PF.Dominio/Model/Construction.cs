using System;
using System.Collections.Generic;

namespace PF.Dominio.Model
{
    public class Construction: Base
    {
        public Construction()
        {
            Activities = new HashSet<Activity>();
        }
        public int ConstructionId { get; set; }
        public string Nombre { get; set; }
        public double Cost { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public virtual ICollection<Activity> Activities { get; set; }
    }
}