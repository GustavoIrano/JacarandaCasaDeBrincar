using System.Collections.Generic;

namespace JacarandaCasaDeBrincar.Api.ViewModels
{
    public class GuardianStudentViewModel
    {
        public List<GuardianViewModel> Guardians { get; set; }
        public List<StudentViewModel> Students { get; set; }
    }
}
