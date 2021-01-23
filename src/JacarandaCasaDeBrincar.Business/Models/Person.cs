using System;

namespace JacarandaCasaDeBrincar.Business.Models
{
    public class Person : Entity
    {
        public string Name { get; set; }
        public string Cpf { get; set; }
        public string Rg { get; set; }
        public DateTime BirthDay { get; set; }
    }
}
