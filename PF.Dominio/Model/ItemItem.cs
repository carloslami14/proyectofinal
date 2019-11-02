using System;
using System.Collections.Generic;
using System.Text;

namespace PF.Dominio.Model
{
    public class ItemItem
    {
        #region Properties
        public int FatherItemId { get; set; }
        public virtual Item FatherItem { get; set; }
        public int ChilItemId { get; set; }
        public virtual Item ChildItem { get; set; }
        #endregion
    }
}