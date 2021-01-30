using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace JacarandaCasaDeBrincar.Business.Models
{
    public class Allergie : Entity
    {
        public string Name { get; set; }

        public ICollection<Student> Students { get; } = new List<Student>();
    }
}
