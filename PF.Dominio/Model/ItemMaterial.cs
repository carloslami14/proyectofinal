using System;
using System.Collections.Generic;
using System.Text;

namespace PF.Dominio.Model
{
    public class ItemMaterial: Base
    {
        #region Properties
        public int ItemId { get; set; }
        public int MaterialId { get; set; }
        public int Quantity { get; set; }
        public virtual Item Item { get; set; }
        public virtual Material Material { get; set; }
        #endregion
    }
}
