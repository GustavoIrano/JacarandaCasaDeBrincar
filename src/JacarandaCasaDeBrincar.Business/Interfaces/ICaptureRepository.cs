using JacarandaCasaDeBrincar.Business.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JacarandaCasaDeBrincar.Business.Interfaces
{
    public interface ICaptureRepository : IRepository<JacarandaCasaDeBrincar.Business.Models.Capture>
    {
        Task<List<Capture>> GetAllWithAllIncluds();
    }
}
