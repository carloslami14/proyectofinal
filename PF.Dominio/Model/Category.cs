namespace PF.Dominio.Model
{
    public class Category: Base
    {
        public string Name { get; set; }
        public int FamilyId { get; set; }
        public virtual Family Family { get; set; }
    }
}