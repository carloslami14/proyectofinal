using System;
using System.Collections.Generic;
using System.Text;

namespace PF.Dominio.Model
{
    public class ItemConstruction : Base
    {
        #region Properties
        public int ConstructionId { get; set; }
        public virtual Construction Construction { get; set; }
        public int ItemId { get; set; }
        public virtual Item Item { get; set; }
        public int Quantity { get; set; }
        #endregion

    }
}
