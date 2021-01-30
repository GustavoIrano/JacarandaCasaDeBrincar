using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace JacarandaCasaDeBrincar.Business.Models
{
    public class Student : Person
    {
        public string BloodType { get; set; }
        public string Picture { get; set; }
        public string Gender { get; set; }
        public ICollection<FoodRestriction> FoodRestrictions { get; } = new List<FoodRestriction>();

        //[ForeignKey("AllergiesId")]
        public ICollection<Allergie> Allergies { get; } = new List<Allergie>();
        public ICollection<Guardian> Guardians { get; } = new List<Guardian>();
        public ICollection<UnauthorizedPerson> UnauthorizedPeople { get; } = new List<UnauthorizedPerson>();
    }
}
