using System.Collections.Generic;

namespace JacarandaCasaDeBrincar.Business.Models
{
    public class Student : Person
    {
        public string BloodType { get; set; }
        public string Picture { get; set; }
        public IEnumerable<Guardian> Guardians { get; set; }
    }
}
