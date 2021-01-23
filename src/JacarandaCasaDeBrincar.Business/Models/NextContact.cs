﻿using System;

namespace JacarandaCasaDeBrincar.Business.Models
{
    public class NextContact : Entity
    {
        public Employee ResponsibleEmployee { get; set; }
        public ContactType ContactType { get; set; }
        public string Informations { get; set; }
        public DateTime DateAndHourFromContact { get; set; }
    }
}
