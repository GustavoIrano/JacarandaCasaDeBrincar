using System.Collections.Generic;

namespace JacarandaCasaDeBrincar.Business.Models
{
    public class UnauthorizedPerson : Entity
    {
        public string Name { get; set; }

        public int StudentId { get; set; }
        public Student Student { get; set; }
    }
}
