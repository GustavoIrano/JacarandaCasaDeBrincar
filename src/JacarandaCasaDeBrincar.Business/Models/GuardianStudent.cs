namespace JacarandaCasaDeBrincar.Business.Models
{
    public class GuardianStudent
    {
        public int GuardianId { get; set; }
        public Guardian Guardian { get; set; }
        public int StudentId { get; set; }
        public Student Student { get; set; }
    }
}
