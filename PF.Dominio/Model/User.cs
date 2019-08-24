namespace PF.Dominio.Model
{
    public class User: Base
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Mail { get; set; }
        public string Password { get; set; }
    }
}