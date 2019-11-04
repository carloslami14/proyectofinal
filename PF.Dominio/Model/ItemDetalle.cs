using System;
using System.Collections.Generic;
using System.Text;

namespace PF.Dominio.Model
{
    public class ItemDetalle : Base
    {
        #region Properties
        public int ContructionId { get; set; }
        public virtual Construction Construction { get; set; }
        public int ItemId { get; set; }
        public virtual Item Item { get; set; }
        public int Quantity { get; set; }
        #endregion

    }
}
