using PF.Dominio.Enumerations;

namespace PF.Dominio.Model
{
    public class Material: Base
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public Unit Unity { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }
}