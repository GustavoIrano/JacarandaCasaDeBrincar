using JacarandaCasaDeBrincar.Business.Interfaces;
using JacarandaCasaDeBrincar.Data.Context;

namespace JacarandaCasaDeBrincar.Data.Repository
{
    public class CaptureRepository : Repository<JacarandaCasaDeBrincar.Business.Models.Capture>, ICaptureRepository
    {
        public CaptureRepository(JacarandaDbContext context) : base(context) { }
    }
}
