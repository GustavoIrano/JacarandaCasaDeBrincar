using System;
using System.ComponentModel.DataAnnotations;

namespace JacarandaCasaDeBrincar.Api.ViewModels
{
    public class CaptureViewModel
    {
        [Key]
        public Guid Id { get; set; }

        public DateTime DateOfCapture { get; set; }

        public CampaignViewModel Campaign { get; set; }

        public HowDidYouknowViewModel HowDidYouknow { get; set; }

        public string Period { get; set; }

        public FrequencyPackageViewModel FrequencyPackage { get; set; }

        public InitialContactViewModel InitialContact { get; set; }

        public NextContactViewModel NextContact { get; set; }
    }
}
