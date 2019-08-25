namespace PF.Dominio.Model
{
    public class Material: Base
    {
        public int MaterialId { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public Unity Unity { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }
}