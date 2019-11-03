using System.Collections.Generic;

namespace PF.Dominio.Model
{
    public class Activity: Base
    {
        #region Constructor
        public Activity()
        {
            Items = new HashSet<Item>();
        }
        #endregion

        #region Properties
        public string Name { get; set; }
        public double Cost { get; set; }
        public virtual ICollection<Item> Items { get; set; }
        #endregion
    }
}