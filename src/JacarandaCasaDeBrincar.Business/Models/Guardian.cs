﻿using System.Collections.Generic;

namespace JacarandaCasaDeBrincar.Business.Models
{
    public class Guardian : Person
    {
        public string Cpf { get; set; }
        public string Rg { get; set; }
        public string Kinship { get; set; }
        public string Occupation { get; set; }
        public string CompanyName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public ICollection<Student> Students { get; } = new List<Student>();
    }
}
