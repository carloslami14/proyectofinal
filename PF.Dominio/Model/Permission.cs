namespace PF.Dominio.Model
{
    public class Permission: Base
    {
        public int PermissionId { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
    }
}