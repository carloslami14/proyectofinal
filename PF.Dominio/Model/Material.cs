using System.Collections.Generic;

namespace PF.Dominio.Model
{
    public class Material: Base
    {
        #region Constructor
        public Material()
        {
            Items = new HashSet<ItemMaterial>();
        }
        #endregion

        #region Properties
        public string Name { get; set; }
        public double Price { get; set; }
        public int UnitId { get; set; }
        public virtual Unit Unit { get; set; }
        public int CategoryId { get; set; }
        public int ProviderId { get; set; }
        public virtual Category Category { get; set; }
        public virtual Provider Provider { get; set; }
        public virtual ICollection<ItemMaterial> Items { get; set; }
        #endregion
    }
}