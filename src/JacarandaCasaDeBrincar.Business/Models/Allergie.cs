using System.Collections;
using System.Collections.Generic;

namespace JacarandaCasaDeBrincar.Business.Models
{
    public class Allergie : Entity
    {
        public string Name { get; set; }

        public ICollection<Student> Students { get; } = new List<Student>();
    }
}
