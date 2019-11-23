using System.Collections.Generic;

namespace PF.Dominio.Model
{
    public class Item : Base
    {
        #region Constructor
        public Item()
        {
            Materials = new HashSet<ItemMaterial>();
            Activities = new HashSet<ItemActivity>();
            //Items = new HashSet<ItemItem>();
        }
        #endregion

        #region Properties
        public string Name { get; set; }
        public double Price { get; set; }
        public virtual ICollection<ItemMaterial> Materials { get; set; }
        public virtual ICollection<ItemActivity> Activities { get; set; }
        //public virtual ICollection<ItemItem> Items { get; set; }
        #endregion
    }
}