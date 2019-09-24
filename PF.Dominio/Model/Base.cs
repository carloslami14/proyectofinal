using System;

namespace PF.Dominio.Model
{
    public class Base
    {
        public int Id { get; set; }
        public DateTime ModificationDate { get; set; }
        public State State { get; set; }
    }
}