using System.Collections.Generic;

namespace PF.Dominio.Model
{
    public class Activity: Base
    {
        public Activity()
        {
            Items = new HashSet<Item>();
        }
        public int ActivityId { get; set; }
        public string Name { get; set; }
        public double Cost { get; set; }
        public virtual ICollection<Item> Items { get; set; }
    }
}