using System;
using System.Collections.Generic;

namespace PF.Dominio.Model
{
    public class Construction: Base
    {
        #region Constructor
        public Construction()
        {
            Activities = new HashSet<Activity>();
        }
        #endregion

        #region Properties
        public string Nombre { get; set; }
        public double Cost { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public virtual ICollection<Activity> Activities { get; set; }
        #endregion
    }
}