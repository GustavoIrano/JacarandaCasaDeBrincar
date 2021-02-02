using JacarandaCasaDeBrincar.Business.Interfaces;
using JacarandaCasaDeBrincar.Business.Models;
using JacarandaCasaDeBrincar.Data.Context;

namespace JacarandaCasaDeBrincar.Data.Repository
{
    public class AllergieRepository : Repository<Allergie>, IAllergieRepository
    {
        public AllergieRepository(JacarandaDbContext context) : base(context) {}
    }
}
