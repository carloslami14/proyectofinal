using System.Collections.Generic;

namespace PF.Dominio.Model
{
    public class Activity: Base
    {
        #region Constructor
        public Activity()
        {
            Items = new HashSet<ItemActivity>();
        }
        #endregion

        #region Properties
        public string Name { get; set; }
        public double Cost { get; set; }
        public int ConstructionId { get; set; }
        public virtual Construction Construction { get; set; }
        public virtual ICollection<ItemActivity> Items { get; set; }
        #endregion
    }
}