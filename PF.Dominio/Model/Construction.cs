using System;
using System.Collections.Generic;

namespace PF.Dominio.Model
{
    public class Construction: Base
    {
        #region Constructor
        public Construction()
        {
            ItemsDetalle = new HashSet<ItemDetalle>();
        }
        #endregion

        #region Properties
        public string Name { get; set; }
        public double Cost { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public virtual ICollection<ItemDetalle> ItemsDetalle { get; set; }
        #endregion
    }
}