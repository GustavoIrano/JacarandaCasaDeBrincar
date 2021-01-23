using JacarandaCasaDeBrincar.Business.Interfaces;
using JacarandaCasaDeBrincar.Business.Models;
using JacarandaCasaDeBrincar.Data.Context;

namespace JacarandaCasaDeBrincar.Data.Repository
{
    public class HowDidYouknowRepository : Repository<HowDidYouknow>, IHowDidYouknowRepository
    {
        public HowDidYouknowRepository(JacarandaDbContext context) : base(context) { }
    }
}
