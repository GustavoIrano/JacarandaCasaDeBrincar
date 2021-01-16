using JacarandaCasaDeBrincar.Business.Interfaces;
using JacarandaCasaDeBrincar.Business.Models;
using JacarandaCasaDeBrincar.Data.Context;

namespace JacarandaCasaDeBrincar.Data.Repository
{
    public class GuardianRepository : Repository<Guardian>, IGuardianRepository
    {
        public GuardianRepository(JacarandaDbContext context) : base(context){}
    }
}
