using System;
using System.Collections.Generic;
using System.Text;

namespace PF.Dominio.Model
{
    public class ItemActivity: Base
    {
        #region Constructors
        public ItemActivity()
        {
        }
        #endregion

        #region Properties
        public int ItemId { get; set; }
        public int ActivityId { get; set; }
        public int Quantity { get; set; }
        public virtual Item Item { get; set; }
        public virtual Activity Activity { get; set; }
        #endregion
    }
}
