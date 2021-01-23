using System;

namespace JacarandaCasaDeBrincar.Business.Models
{
    public class Capture : Entity 
    {
        public DateTime DateOfCapture { get; set; }
        public Campaign Campaign { get; set; }
        public HowDidYouknow HowDidYouknow{ get; set; }
        public string Period { get; set; }
        public FrequencyPackage FrequencyPackage { get; set; }
        public InitialContact InitialContact { get; set; }
        public NextContact NextContact { get; set; }
    }
}
