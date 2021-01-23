namespace JacarandaCasaDeBrincar.Business.Models
{
    public class Address : Entity
    {
        public string Street { get; set; }
        public string Complement { get; set; }
        public string Cep { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Neighborhood { get; set; }
        public int Number { get; set; }
        
    }
}
