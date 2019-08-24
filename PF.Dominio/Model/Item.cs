using System.Collections.Generic;

namespace PF.Dominio.Model
{
    public class Item: Base
    {
        public Item()
        {
            Materials = new HashSet<Material>();
        }
        public int ItemId { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public virtual ICollection<Material> Materials { get; set; }
    }
}