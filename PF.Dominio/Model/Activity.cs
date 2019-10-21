using System.Collections.Generic;

namespace PF.Dominio.Model
{
    public class Activity: Base
    {
        public Activity()
        {
            Items = new HashSet<Item>();
        }
        public string Name { get; set; }
        public double Cost { get; set; }
        public virtual ICollection<Item> Items { get; set; }
    }
}