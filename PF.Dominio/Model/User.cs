namespace PF.Dominio.Model
{
    public class User: Base
    {
        #region Properties
        public string Name { get; set; }
        public string Mail { get; set; }
        public string Password { get; set; }
        #endregion
    }
}