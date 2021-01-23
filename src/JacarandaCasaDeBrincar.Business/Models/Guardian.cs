using System.Collections.Generic;

namespace JacarandaCasaDeBrincar.Business.Models
{
    public class Guardian : Person
    {
        public string Kinship { get; set; }
        public string Occupation { get; set; }
        public string CompanyName { get; set; }
        public bool IsResponsable { get; set; }
        public Contact Contact { get; set; }
        public Address Address { get; set; }
        public ICollection<Student> Students { get; } = new List<Student>();
    }
}
