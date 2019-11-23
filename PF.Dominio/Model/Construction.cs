using System;
using System.Collections.Generic;

namespace PF.Dominio.Model
{
    public class Construction: Base
    {
        #region Constructor
        public Construction()
        {
            Items = new HashSet<ItemConstruction>();
            Activities = new HashSet<Activity>();
        }
        #endregion

        #region Properties
        public string Name { get; set; }
        public double Cost { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public virtual ICollection<ItemConstruction> Items { get; set; }
        public virtual ICollection<Activity> Activities { get; set; }
        #endregion
    }
}