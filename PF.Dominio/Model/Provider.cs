namespace PF.Dominio.Model
{
    public class Provider: Base
    {
        public int ProviderId { get; set; }
        public string Name { get; set; }
        public double CUIT { get; set; }
        public string Address { get; set; }
    }
}