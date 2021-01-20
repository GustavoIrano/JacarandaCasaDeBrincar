using System.Collections.Generic;

namespace JacarandaCasaDeBrincar.Business.Models
{
    public class Student : Person
    {
        public string BloodType { get; set; }
        public string Picture { get; set; }
        public string Gender { get; set; }
        public ICollection<Guardian> Guardians { get; } = new List<Guardian>();
    }
}
